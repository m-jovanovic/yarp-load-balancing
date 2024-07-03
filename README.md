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

**Whenever you're ready, there are 2 ways I can help you:**:

1. [**Pragmatic Clean Architecture:**](https://www.milanjovanovic.tech/pragmatic-clean-architecture?utm_source=dev.to&utm_medium=website&utm_campaign=cross-posting) Join 2,900+ students in this comprehensive course that will teach you the system I use to ship production-ready applications using Clean Architecture. Learn how to apply the best practices of modern software architecture.
 
2. [**Modular Monolith Architecture:**](https://www.milanjovanovic.tech/modular-monolith-architecture?utm_source=dev.to&utm_medium=website&utm_campaign=cross-posting) Join 750+ engineers in this in-depth course that will transform the way you build modern systems. You will learn the best practices for applying the Modular Monolith architecture in a real-world scenario.
