# SimpleUberWebApi
Example of code

Hey, I'm Dzmitry Kuliashou. I'm .NET developer and this project is example of my code.
Let me provide some description about this project.

1. SimpleUber.Distribution.Host - the start project of solution. It's just a enter point of web service and it contains some basic functions of serivce:
- service configuration in Global.asax.cs and WebApiConfig.cs
- authorisation in SimpleUberAuthorizeAttribute.cs - if service doesn't marked by AllowAnonymousAttribute, service checks, if request has valid Token in its header
- exception logging in DbExceptionLogger.cs - the application logs information about all exceptions to database
- exception handling in SimpleUberExceptionHandler.cs - application handles all exceptions, so never returns to client the exception itself.
- all requests and responses logging - application logs all requests and responses to database. It's possible to mark API controller by IsPartlySupressedLoggingAttribute and all requests to such controller will be logged without request and response body.

2. SimpleUber.Config project has references to all other projects and is used for registration of dependences. Castle Windsor container is used for dependencies resolving.

3. SimpleUber.Distribution.Api contains all services interfaces. SimpleUber.Distribution project contains ApiControllers itself. WebApi solution is designed using Facade pattern. So SimpleUber.Distribution has only definition of services. Each service has a reference to interface of CommandHandler or QueryHandler.

4. SimpleUber.Services.Api contains all interfaces of CommandHandlers and QueryHandlers and also commands and queries classes with input parameters.

5. The implementation of CommnadHandlers and QueryHandlers are in SimpleUber.Services project. Interesting feature here is CommandValidationInterceptor which intercepts all CommandHandler calls and in case when CommandHandler is marked by ValidationRequiredAttribute, calls commnad's validator. FluentValidation library is used for command's parameters validation. Command and QueryHandlers may use each other to retreive and save different information. Thanks of using DI, it becames very simple. For communication with data access layer (DAL) readers and writers are being used.

6. DAL is represented by SimpleUber.DAL.Api project. It contains data trasfer objects (DTO) classes and interfeces of repositories.

7. Repositories are implemented in SimpleUber.DAL project using EntityFramework6 functionality. Code first conception is realized in this solution.

Simple client application for this service you can find here - https://github.com/dzmitry-kuliashou/SimpleUberClient

Also you can find, that each layer has its own classes for data - DTO on DAL, commands and queries on Command and QueryHandlers layer, service contract on distribution layer. And AutoMapper library is used for converting data objects.

So, you can see, that this solution is very simple and contains just some services. But at the same time it has some features, which allows to scale this solution as much as it needed and simply create very large and complex WebApi services application because of using design patterns, SOLID principles and layer desing architecture.
