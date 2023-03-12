## Setup
copy  `.env.example`  and put as `.env`

## Requirement
* Docker Compose (at least version 3.1)

## Build & Run
To startup the whole solution, execute the following command:

### Linux:
Migration (optional):

Use command when your database does not exist and you can terminate this service after migration done
``` shell
docker-compose up migration
```

Run service :
``` shell
docker-compose up api
```
Browse to http://localhost:8888/swagger/index.html.

---
## Left out
* Use SQL query, but I designed to do with create a new repository that query with raw SQL

## Trade offs
* Infrastructure does not have Model and it used from Domain project so it need configuration to map Entity fields to database column
* Separate logic into projects it make we can do unit test on each logic

## Decisions
* I extract every actions to UseCase because I designed to allow other protocol e.g. queue to used same logic as API
* I used repository pattern to separate datasource logic from application logic
* Api project contain only how to execute and handle response
* I used interface for reduce tight coupling between projects
* I designed UserCrudUseCase to contain multiple actions because at the moment I don't want multiple use case for simple logic

## Will do in the future
* Add logger
* Add authentication and authorization
* Validation phone number on UserEntity
* Add exception middleware for handle error response
* Add domain event
* Change id to value object
* Add integration test for Infrastructure project
* Improve update endpoint to support Under-Posting
* Improve docker migration