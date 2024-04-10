## API resources

For a list of the available resources, see
[API resources](api_resources.md).

## Basic usage

API requests should be prefixed with `api`.

Example of a valid API request using cURL:

```shell
curl "https://localhost:7046/api/Book"
```

## Installation Guide
* Clone this repository here.
* The master branch is the most stable branch at any given time, ensure you're working from it.
* You can work with the Library.db database via the SwaggerUI interface, or use the Postman program.
* The database will be initiated at the first launch of the web api.
  
## Authentication

All API requests require authentication except for the request to receive an authentication token.

The authentication token can be obtained by making a request:

```shell
curl "https://localhost:7046/api/Book/token"
```

If authentication information is invalid or omitted, an error message will be
returned with status code `401`:

```json
{
  "message": "401 Unauthorized"
}
```

## Status codes

The API is designed to return different status codes according to context and
action. This way, if a request results in an error, the caller is able to get
insight into what went wrong.

The following table gives an overview of how the API functions generally behave.

| Request type | Description |
| ------------ | ----------- |
| `GET`   | Access resources and return the result as JSON. |
| `POST`  | Return `201 Created` if the resource is successfully created and return the id resource as GUID. |
| `GET`  | Return `200 OK` if the resource is created successfully.  |
| `DELETE` / `PUT` | Returns `204 No Content` if the resource was successfully deleted or modified. |

The following table shows the possible return codes for API requests.

| Return values | Description |
| ------------- | ----------- |
| `200 OK` | The `GET`, request was successful, the resource(s) itself is returned as JSON. |
| `204 No Content` | The `PUT` or `DELETE` request was successful and that there is no additional content to send in the response payload body. |
| `201 Created` | The `POST` request was successful and the resource is returned as JSON. |
| `401 Unauthorized` | The user is not authenticated, a valid [user token](#Authentication) is necessary. |
| `404 Not Found` | A resource could not be accessed, e.g., an ID for a resource could not be found. |
| `500 Server Error` | While handling the request something went wrong server-side. |
