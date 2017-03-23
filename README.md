# Microservices.Architecture

Demonstration of possible Microservice Architectures, developed in ASP.Net Core

Some inspiration links:
- http://docs.identityserver.io/en/release/index.html
- https://github.com/zleao/IdentityServer4.Samples
- https://dzone.com/articles/microservices-in-practice-1
- http://microservices.io/patterns/apigateway.html

## Technologies Used
- ASP.Net Core
- IdentityServer4
- EntityFrameworkCore

## Implemented Architectures
### API Gateway with Authentication
**References**
- [http://microservices.io/patterns/apigateway.html](http://microservices.io/patterns/apigateway.html)
- [https://dzone.com/articles/microservices-in-practice-1](https://dzone.com/articles/microservices-in-practice-1)

**Description**

Project consisting on 3 microservices
- *Identity:* Microservice used for providing authentication tokens and authorization for the *ApiGateway*
- *ApiGateway:* Microservice that provides the entry point for the clients
- *DatabaseAsService:* Microservice that exposes the database to be used by the other microservices

**Endpoints**
- Identity: *http://localhost:5001*
  - Token: */connect/token* (POST)
- ApiGateway: *http://localhost:5000*
  - Get all Sessions: */api/Sessions* (GET - requires token)
- DatabaseAsService: *http://localhost:6000*
  - Sessions:
    - *api/Sessions?expand=keyword* (GET - query parameter optional)
    - CRUD operations
  - Keywords:
    - *api/Keywords* (GET)
    - CRUD operations
    
**Client Credentials**
  - Username: client
  - Password: secret
