# Auth API

## AuthController

### Login user

```
POST /api/login
```
Example request:

```json
  {
     "name": "UserName"
     "password": "UserPass"
  }
```

Example response:

```json
  {
     "name": "UserName"
     "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
     "role": "User"
  }
```

```bash
curl -X 'POST' \
  'https://localhost:7019/api/login'
```

### Register user

```
POST /api/register
```

Example request:

```json
  {
     "name": "UserName"
     "password": "UserPass"
     "confirmPassword": "UserPass"
  }
```

Example response:

```json
  {
     "name": "UserName"
     "role": "UserPass"
  }
```

```bash
curl -X 'POST' \
  'https://localhost:7019/api/register'
```

## RolesController

### Create a new role

```
POST /api/roles
```

Example request:

```json
  {
     "Name": "User"
  }
```

Example response:

```json
  {
     "Name": "User"
  }
```

```bash
curl -X 'POST' \
  'https://localhost:7019/api/roles'
```

### Gets the list of roles

```
GET /api/roles
```

Example response:

```json
"roles": [
  {
     "Name": "User"
  },
  {
     "Name": "Admin"
  }
]
```

```bash
curl -X 'GET' \
  'https://localhost:7019/api/roles'
```

### Get the role by name

```
GET /api/roles/[roleName]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `roleName`| String | The name of the role |

Example response:

```json
  {
     "Name": "User"
  }
```

```bash
curl -X 'GET' \
  'https://localhost:7019/api/roles/User'
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
  'https://localhost:7019/api/roles/User'
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
