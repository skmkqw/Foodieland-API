## Foodieland-API
Welcome to the FoodieLand API repository! This backend service powers the FoodieLand web application, enabling users to log in, search, share, and explore recipes from the world's top chefs. The API provides endpoints for managing recipes, user accounts and ratings.

### Overview
This API is the backend component of FoodieLand, a platform designed for food enthusiasts to discover and recreate gourmet dishes at home. The API supports various features such as recipe search, user authentication, and interactions like ratings and reviews.

### Tech Stack
- Framework: .NET 8 Web API
- Database: Microsoft SQL Server (MSSQL)
- Authentication: JWT (JSON Web Tokens)

# Endpoints

# **AuthenticationController**

### Base URL:
`/auth`

### Available Endpoints:

1. **POST /auth/register**
2. **POST /auth/login**

---

### 1. POST /auth/register

### Request:
- **Method**: POST
- **URL**: `/auth/register`

```json
{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "password": "string"
}
```

### Response
```json
{
  "id": "guid",
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "token": "string"
}
```

---

### 1. POST /auth/login

### Request:
- **Method**: POST
- **URL**: `/auth/login`

```json
{
  "email": "string",
  "password": "string"
}
```

### Response
```json
{
  "id": "guid",
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "token": "string"
}
```
---

# **UserController**

### Base URL:
`/users`

### Available Endpoints:

1. **DELETE /users/{userId}**

---

## 1. DELETE /users/{userId}

### Request:
- **Method**: DELETE
- **URL**: `/users/{userId}`
- **Path Parameter**:
  - `userId`: (GUID) The unique identifier of the user to be deleted.

### Response:
- No content is returned when the user is successfully deleted.

---

### Links
[Frontend repoistory](https://github.com/skmkqw/Foodieland) 

### License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
