using Bogus;
using Dapper;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Database");
var dataSource = new NpgsqlDataSourceBuilder(connectionString).Build();

builder.Services.AddSingleton(dataSource);

var app = builder.Build();

app.MapPost("users", async (NpgsqlDataSource source) =>
{
    var faker = new Faker();

    await using var connection = await source.OpenConnectionAsync();

    var userId = await connection.ExecuteScalarAsync<int>(
        """
        INSERT INTO users (first_name, last_name, date_of_birth)
        VALUES (@FirstName, @LastName, @DateOfBirth)
        RETURNING id;
        """,
        new User
        {
            FirstName = faker.Name.FirstName(),
            LastName = faker.Name.LastName(),
            DateOfBirth = faker.Date.Past(20).ToUniversalTime()
        });

    connection.Close();

    return Results.CreatedAtRoute("GetUser", new { id = userId }, userId);
});

app.MapGet("users/{id}", async (int id, NpgsqlDataSource source) =>
{
    await using var connection = await source.OpenConnectionAsync();

    var user = await connection.QuerySingleAsync<User>(
        """
        SELECT
            id AS Id,
            first_name AS FirstName,
            last_name AS LastName,
            date_of_birth AS DateOfBirth
        FROM users
        WHERE id = @UserId
        """,
        new { UserId = id });

    connection.Close();

    return Results.Ok(user);
})
.WithName("GetUser");

app.Run();

internal sealed class User
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
}
