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
POST /api/products/page?pageSize=[pageSize]&pageCount=[pageCount]
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
curl -X 'POST' \
  'https://localhost:7292/api/products/page?pageSize=2&pageCount=1'
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

### Change the produrt's manufacturer

```
PATCH   /api/products/manufacturers/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`| GUID | The id of the product |

Example request:

```json
[
  {
     "operationType": "0",
     "path": "ManufacturerId",
     "op": "replace",
     "from": "string",
     "value": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  }
]
```

```bash
curl -X 'PATCH' \
  'https://localhost:7292/api/products/manufacturers/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
        [
             {
                 "operationType": 0,
                 "path": "ManufacturerId",
                 "op": "replace",
                 "from": "string",
                 "value": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
             }
        ]
```

### Delete the role

```
DELETE /api/products/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`| GUID | The id of the product |

```bash
curl -X 'DELETE' \
  'https://localhost:7292/api/products/7200f6a3-132c-46c9-8b9f-27b9b3c2d122'
```

## CategoriesController

### Create a new category

```
POST /api/categories
```

Example request:

```json
  {
     "title": "CategoryTitle"
  }
```

Example response:

```json
  {
     "title": "CategoryTitle"
  }
```

```bash
curl -X 'POST' \
  'https://localhost:7292/api/categories'
```

### Gets the list of category

```
POST /api/categories/page?pageSize=[pageSize]&pageCount=[pageCount]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `pageSize`| int | The page size |
| `pageCount`| int | The page count |

Example response:

```json
"products": [
    {
       "title": "CategoryTitle"
    },
    {
       "title": "CategoryTitle"
    }
  ]
```

```bash
curl -X 'POST' \
  'https://localhost:7292/api/categories/page?pageSize=2&pageCount=1'
```

### Gets the list of category

```
GET /api/categories
```

Example response:

```json
"products": [
    {
       "title": "CategoryTitle"
    },
    {
       "title": "CategoryTitle"
    }
  ]
```

```bash
curl -X 'GET' \
  'https://localhost:7292/api/categories'
```

### Get the category by id

```
GET /api/categories/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`| GUID | The id of the category |

Example response:

```json
  {
     "title": "CategoryTitle"
  }
```

```bash
curl -X 'GET' \
  'https://localhost:7292/api/categories/7200f6a3-132c-46c9-8b9f-27b9b3c2d122'
```

### Change the category's title

```
PATCH   /api/products/categories/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`| GUID | The id of the category |

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
  'https://localhost:7292/api/categories/7200f6a3-132c-46c9-8b9f-27b9b3c2d122
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

### Delete the category

```
DELETE /api/category/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`| GUID | The id of the category |

```bash
curl -X 'DELETE' \
  'https://localhost:7292/api/categories/7200f6a3-132c-46c9-8b9f-27b9b3c2d122'
```
