# ap-ug-microservices

Technologies used: .NET, Angular, Docker, Kubernetes, RabbitMq

PoC for master thesis which in theory part describe DDD and Event storming.

Did not have enough time to implement all parts.

In implementation I used some old Raw Rabbit lib version, this caused some workarounds
- there was a problem with exchange, because by default it takes namespace from project. The other service tired to get the value from the wrong exchange. Thats why I extracted events/queries/commands to Common project.

In v2 I would use:
- official RabbitMQ library
- when the Event is only for internal usage the communication should be changed on MediatR
