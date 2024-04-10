# Auth API

## List books

### Get a list of all books

```
GET https://localhost:7046/api/Book
```

Example response:

```json
"books": [
  {
     "ISBN": "note ISBN"
     "Title": "note title"
     "Genre": "note genre"
     "Description": "note description"
     "Author": "note author"
  },
  {
     "ISBN": "ISBN"
     "Title": "title"
     "Genre": "genre"
     "Description": "description"
     "Author": "author"
  }
]
```

```bash
curl -X 'GET' \
  'https://localhost:7046/api/Book'
```

## Get one book

### Get a book by id.

```
GET https://localhost:7046/api/Book/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`      | GUID | The id of the book |

Example response:

```json
{
  "id": "956c5679-7a91-4bdd-b64b-8e22202ca075",
  "isbn": "978-5-4461-0960-9",
  "title": "Clean code",
  "genre": "Programming",
  "description": "Description",
  "author": "Robert Martin",
  "timeReceipt": "2023-12-06T11:42:28.8399078",
  "returnTime": "2023-12-07T00:00:00"
}
```

```bash
curl -X 'GET' \
  'https://localhost:7046/api/Book/956c5679-7a91-4bdd-b64b-8e22202ca075'
```

### Get a book by isbn.

```
GET https://localhost:7046/api/Book/isbn/[isbn]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `isbn`      | string | The isbn of the book |

Example response:

```json
{
  "id": "956c5679-7a91-4bdd-b64b-8e22202ca075",
  "isbn": "978-5-4461-0960-9",
  "title": "Clean code",
  "genre": "Programming",
  "description": "Description",
  "author": "Robert Martin",
  "timeReceipt": "2023-12-06T11:42:28.8399078",
  "returnTime": "2023-12-07T00:00:00"
}
```

```bash
curl -X 'GET' \
  'https://localhost:7046/api/Book/isbn/978-5-4461-0960-9'
```

## Create a new book

### Creates a new book for the given repository with the given isbn, title, genre, description, and author.

```
POST https://localhost:7046/api/Book/
```

Example response:

```json
{
  "isbn": "978-5-4461-0960-9",
  "title": "Clean code",
  "genre": "Programming",
  "description": "Description",
  "author": "Robert Martin"
}
```

```bash
curl -X 'POST' \
  'https://localhost:7046/api/Book'
```

## Delete a book

### Deletes a book by id.

```
DELETE https://localhost:7046/api/Book/[id]
```

| Parameters | Type    | Description           |
| --------- | -------  | --------------------- |
| `id`      | GUID | The id of the book |

```bash
curl -X 'DELETE' \
  'https://localhost:7046/api/Book/956c5679-7a91-4bdd-b64b-8e22202ca075'
```

## Edit an existing book

### Updates an existing book with new title or new isbn, to update, you must specify the existing book id in the request body

```
PUT https://localhost:7046/api/Book/
```

Example response:

```json
{
  "id": "956c5679-7a91-4bdd-b64b-8e22202ca075",
  "isbn": "978-4-4461-0960-9",
  "title": "Clean code part 2",
  "genre": "Programming",
  "description": "Description",
  "author": "Robert Martin"
}
```

```bash
curl -X 'PUT' \
  'https://localhost:7046/api/Book'
```
