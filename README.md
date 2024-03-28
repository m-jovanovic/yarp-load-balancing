# YARP Load Balancing

An example project demonstrating how to horizontally scale an application using YARP, and run performance tests with k6.

To start the project:

```
docker-compose up
```

To run performance tests:

```
k6 run api-test.js
```

Performance testing results:

| API Instances      |     Request Duration     |     Request Per Second
|------------------- |------------------------- |---------------------------:
|         1          |         9.68ms           |          2260/s           |
|         2          |         6.57ms           |          2764/s           |
|         3          |         5.62ms           |          3227/s           |
|         5          |         4.65 ms          |          3881/s           |
