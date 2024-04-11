# Order API

## Orders controller

### Create a new order

```
POST /api/orders
```

Example request:

```json
  {
     "FirstName": "string",
     "LastName": "string",
     "Email": "string",
     "Address": "string",
     "Town": "string",
     "Comment": "string",
     "ProductIds": [ "string"
            "string"
        ]
  }
```

Example response:

```json
  {
     "id": "74c93f5c-3098-4165-b444-262986281df1"
  }
```

```bash
curl -X 'POST' \
  'https://localhost:7292/api/orders'
```

### Gets the list of order

```
POST /api/orders/page?pageSize=[pageSize]&pageCount=[pageCount]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `pageSize`| int | The page size |
| `pageCount`| int | The page count |

Example response:

```json
"orders": [
    {
       "id": "74c93f5c-3098-4165-b444-262986281df1"
    },
    {
       "id": "74c93f5c-3098-4165-b444-262986281df1"
    }
  ]
```

```bash
curl -X 'POST' \
  'https://localhost:7292/api/orders/page?pageSize=2&pageCount=1'
```

### Get the order by id

```
GET /api/orders/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`| GUID | The id of the order |

Example response:

```json
  {
     "id": "74c93f5c-3098-4165-b444-262986281df1"
  }
```

```bash
curl -X 'GET' \
  'https://localhost:7292/api/orders/7200f6a3-132c-46c9-8b9f-27b9b3c2d122'
```

### Delete the order

```
DELETE /api/orders/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`| GUID | The id of the order |

```bash
curl -X 'DELETE' \
  'https://localhost:7292/api/order/7200f6a3-132c-46c9-8b9f-27b9b3c2d122'
```
