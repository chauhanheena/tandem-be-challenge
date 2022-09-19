# Tandem Backend Challenge

Program for do operation on Users.

## Created 2 APIs:
1. Create User
2. Get User by Email Address

#
## Technologies
- Cosmos DB
- MediatR
- FluentValidation
- AutoMapper
- Swagger

#
APIs
1. Create User

```
POST /api/users
```
**Response 201**
```
{
  "userId": "a1224d8b-29ac-4778-8907-37a31b700f10",
  "name": "Heena M Chauhan",
  "phoneNumber": "7894561235",
  "emailAddress": "heena.chauhan@ajmerainfotech.com"
}
```

2. Get User by Email Address

```
POST /api/users?emailAddress=heena.chauhan@ajmerainfotech.com
```
**Response 200**
```
{
  "userId": "a1224d8b-29ac-4778-8907-37a31b700f10",
  "name": "Heena M Chauhan",
  "phoneNumber": "7894561235",
  "emailAddress": "heena.chauhan@ajmerainfotech.com"
}
```

## Docker

Run the following command on terminal to run Docker container
```
docker build -t tandemchallenge .
```
```
docker run -d -p 8080:80 --name tandem  tandemchallenge
```

## Integration Tests:
![image](https://raw.githubusercontent.com/chauhanheena/tandem-be-challenge/main/tandem-be-challenge/test-cases.png)