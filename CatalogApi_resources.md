# Catalog API

## ProductsController

### Create a new product

```
POST /api/products
```

Example request:

```json
  {
     "title": "producTitle",
     "manufacturerId": "6e513972-8541-4563-01b3-08dc2bd840ff",
     "categoryId": "74c93f5c-3098-4165-b444-262986281df1",
  }
```

Example response:

```json
  {
     "title": "producTitle"
  }
```

```bash
curl -X 'POST' \
  'https://localhost:7292/api/products'
```

### Gets the list of product

```
GET /api/products/page?pageSize=[pageSize]&pageCount=[pageCount]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `pageSize`| int | The page size |
| `pageCount`| int | The page count |

Example response:

```json
"products": [
    {
       "title": "producTitle"
    },
    {
       "title": "producTitle"
    }
  ]
```

```bash
curl -X 'GET' \
  'https://localhost:7292/api/page?pageSize=2&pageCount=1'
```

### Get the product by id

```
GET /api/products/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`| GUID | The id of the product |

Example response:

```json
  {
     "title": "producTitle"
  }
```

```bash
curl -X 'GET' \
  'https://localhost:7292/api/products/7200f6a3-132c-46c9-8b9f-27b9b3c2d122'
```

### Change the produrt's title

```
PATCH   /api/products/title/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`| GUID | The id of the product |

Example request:

```json
[
  {
     "operationType": "0",
     "path": "Title",
     "op": "replace",
     "from": "string",
     "value": "NewTitle",
  }
]
```

```bash
curl -X 'PATCH' \
  'https://localhost:7292/api/products/title/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
        [
             {
                 "operationType": 0,
                 "path": "Title",
                 "op": "replace",
                 "from": "string",
                 "value": "NewTitle"
             }
        ]
```

### Change the produrt's category

```
PATCH   /api/products/category/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`| GUID | The id of the product |

Example request:

```json
[
  {
     "operationType": "0",
     "path": "CategoryId",
     "op": "replace",
     "from": "string",
     "value": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  }
]
```

```bash
curl -X 'PATCH' \
  'https://localhost:7292/api/products/category/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
        [
             {
                 "operationType": 0,
                 "path": "CategoryId",
                 "op": "replace",
                 "from": "string",
                 "value": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
             }
        ]
```

### Delete the role

```
DELETE /api/roles/[roleName]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `roleName`| String | The name of the role |

```bash
curl -X 'DELETE' \
  'https://localhost:7292/api/products/7200f6a3-132c-46c9-8b9f-27b9b3c2d122'
```

## UsersController

### Gets the list of users

```
POST /api/users
```

Example request:

```json
  {
     "pageSize": "10",
     "pageCount": "1",
  }
```

Example response:

```json
  {
  "roles": [
    {
       "Name": "User"
    },
    {
       "Name": "Admin"
    }
  ],  
     "totalUsersCount": "10",
     "pageSize": "10",
     "pageCount": "1",
  }
```

```bash
curl -X 'POST' \
  'https://localhost:7019/api/users'
```

### Get the user by id

```
GET /api/users/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`| GUID | The id of the user |

Example response:

```json
  {
     "id": "46b5821f-944d-48db-87f4-4664039ffb6c",
     "name": "UserName",
     "role": "User",
  }
```

```bash
curl -X 'GET' \
  'https://localhost:7019/api/users/46b5821f-944d-48db-87f4-4664039ffb6c'
```

### Change the user's password

```
PUT /api/users
```

Example request:

```json
  {
     "name": "10",
     "currentPassword": "4454",
     "newPassword": "5483",
  }
```

```bash
curl -X 'PUT' \
  'https://localhost:7019/api/users'
```

### Delete the user

```
DELETE /api/users/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`| GUID | The id of the user |

```bash
curl -X 'DELETE' \
  'https://localhost:7019/api/users/46b5821f-944d-48db-87f4-4664039ffb6c'
```
