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

### 1. DELETE /users/{userId}

### Request:
- **Method**: DELETE
- **URL**: `/users/{userId}`
- **Path Parameter**:
  - `userId`: (GUID) The unique identifier of the user to be deleted.

### Response:
- No content is returned when the user is successfully deleted.

---

# **RecipeController**

### Base URL:
`/recipes`

### Available Endpoints:

1. **GET /recipes/{recipeId}**
2. **GET /recipes**
3. **GET /recipes/users/{userId}**
4. **POST /recipes**
5. **PUT /recipes/{recipeId}**
6. **DELETE /recipes/{recipeId}**

---

### 1. GET /recipes/{recipeId}

### Request:
- **Method**: GET
- **URL**: `/recipes/{recipeId}`
- **Path Parameter**:
  - `recipeId`: (GUID) The unique identifier of the recipe to be fetched.

### Response:
- **Response Body** (JSON format):
```json
{
  "id": "string",
  "name": "string",
  "description": "string",
  "timeToCook": "integer",
  "creatorId": "string",
  "nutritionInformation": {
    "calories": "integer",
    "protein": "float",
    "carbs": "float",
    "fat": "float"
  },
  "directions": [
    {
      "stepNumber": "integer",
      "name": "string",
      "description": "string"
    }
  ],
  "ingredients": [
    {
      "name": "string",
      "quantity": "float",
      "unit": "string"
    }
  ],
  "reviewIds": ["string"],
  "createdDateTime": "datetime",
  "updatedDateTime": "datetime"
}
```

---

### 2. GET /recipes

### Request:
- **Method**: GET
- **URL**: `/recipes/{recipeId}`
- **Query Parameter**:
  - `page`: (int) The page number for pagination (default is 1).
  - `pageSize`: (integer) The number of recipes per page (default is 10).

### Response:
```json
{
  "recipes": [
    {
      "id": "string",
      "name": "string",
      "description": "string",
      "timeToCook": "integer",
      "creatorId": "string",
      "nutritionInformation": {
        "calories": "integer",
        "protein": "float",
        "carbs": "float",
        "fat": "float"
      },
      "directions": [
        {
          "stepNumber": "integer",
          "name": "string",
          "description": "string"
        }
      ],
      "ingredients": [
        {
          "name": "string",
          "quantity": "float",
          "unit": "string"
        }
      ],
      "reviewIds": ["string"],
      "createdDateTime": "datetime",
      "updatedDateTime": "datetime"
    }
  ],
  "paginationResponse": {
    "page": "integer",
    "pageSize": "integer",
    "totalCount": "integer"
  }
}
```
---

### 3. GET /recipes/users/{userId}

### Request:
- **Method**: GET
- **URL**: `/recipes/users/{userId}`
- **Query Parameter**:
  - `page`: (int) The page number for pagination (default is 1).
  - `pageSize`: (integer) The number of recipes per page (default is 10).

### Response:
```json
{
  "recipes": [
    {
      "id": "string",
      "name": "string",
      "description": "string",
      "timeToCook": "integer",
      "creatorId": "string",
      "nutritionInformation": {
        "calories": "integer",
        "protein": "float",
        "carbs": "float",
        "fat": "float"
      },
      "directions": [
        {
          "stepNumber": "integer",
          "name": "string",
          "description": "string"
        }
      ],
      "ingredients": [
        {
          "name": "string",
          "quantity": "float",
          "unit": "string"
        }
      ],
      "reviewIds": ["string"],
      "createdDateTime": "datetime",
      "updatedDateTime": "datetime"
    }
  ],
  "paginationResponse": {
    "page": "integer",
    "pageSize": "integer",
    "totalCount": "integer"
  }
}
```
---

### 4. POST /recipes

### Request:
- **Method**: POST
- **URL**: `/recipes`
- **Request body** (JSON format)
```json
{
  "name": "string",
  "description": "string",
  "timeToCook": "integer",
  "nutritionInformation": {
    "calories": "integer",
    "protein": "float",
    "carbs": "float",
    "fat": "float"
  },
  "directions": [
    {
      "stepNumber": "integer",
      "name": "string",
      "description": "string"
    }
  ],
  "ingredients": [
    {
      "name": "string",
      "quantity": "float",
      "unit": "string"
    }
  ]
}
```
### Response:
```json
{
  "id": "string",
  "name": "string",
  "description": "string",
  "timeToCook": "integer",
  "creatorId": "string",
  "nutritionInformation": {
    "calories": "integer",
    "protein": "float",
    "carbs": "float",
    "fat": "float"
  },
  "directions": [
    {
      "stepNumber": "integer",
      "name": "string",
      "description": "string"
    }
  ],
  "ingredients": [
    {
      "name": "string",
      "quantity": "float",
      "unit": "string"
    }
  ],
  "reviewIds": ["string"],
  "createdDateTime": "datetime",
  "updatedDateTime": "datetime"
}
```

---

### 5. PUT /recipes/{recipeId}

### Request:
- **Method**: GET
- **URL**: `/recipes/{recipeId}`
- **Path Parameter**:
  - `recipeId`: (GUID) The unique identifier of the recipe to be updated.
- **Request body** (JSON format)
```json
{
  "name": "string",
  "description": "string",
  "timeToCook": "integer",
  "nutritionInformation": {
    "calories": "integer",
    "protein": "float",
    "carbs": "float",
    "fat": "float"
  },
  "directions": [
    {
      "stepNumber": "integer",
      "name": "string",
      "description": "string"
    }
  ],
  "ingredients": [
    {
      "name": "string",
      "quantity": "float",
      "unit": "string"
    }
  ]
}
```
### Response:
```json
{
  "id": "string",
  "name": "string",
  "description": "string",
  "timeToCook": "integer",
  "creatorId": "string",
  "nutritionInformation": {
    "calories": "integer",
    "protein": "float",
    "carbs": "float",
    "fat": "float"
  },
  "directions": [
    {
      "stepNumber": "integer",
      "name": "string",
      "description": "string"
    }
  ],
  "ingredients": [
    {
      "name": "string",
      "quantity": "float",
      "unit": "string"
    }
  ],
  "reviewIds": ["string"],
  "createdDateTime": "datetime",
  "updatedDateTime": "datetime"
}
```

---

### 6. DELETE /recipes/{recipeId}

### Request:
- **Method**: DELETE
- **URL**: `/recipes/{recipeId}`
- **Path Parameter**:
  - `recipeId`: (GUID) The unique identifier of the recipe to be deleted.
  
### Response:
No content is returned when the recipe is successfully deleted.

### Links
[Frontend repoistory](https://github.com/skmkqw/Foodieland) 

### License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
