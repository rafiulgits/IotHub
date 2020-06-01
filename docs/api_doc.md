
<div class="page-header">
    <a class="btn" href="./api_doc">API Doc</a>
    <a class="btn" href="./broker_doc">Broker Doc</a>
    <a class="btn" href="./agent_doc">Agent Doc</a>
</div>





# IotHub API

A .NET web API project to provide the API support of IotHub Solution. By default this project is hosting on `HTTP 5000` and `HTTPS 5001`. 

Open `/swagger` to view the **Swagger** interface.

***

**Backdoor Admin login**

There is a backdoor in IotHub API to allowed admin to authenticate with custom credentials. These credentials are store in `appSettings.json` of IotHub API project

```json
"InternalAuthSettings": {
    "IsActive" :  true,
    "UserName": "admin",
    "Password": "12345678"
  },
```

There is an option to turned off internal authentication by changing the parameter `isActive` to `false`. Even admin can change this custom credential anytime. This credential has the admin level permission to access any resource in that solution.

***



## Status Codes

| Status Code               | Reason                                                       |
| ------------------------- | ------------------------------------------------------------ |
| 200 OK                    | Successful `GET` ,`PUT` request                              |
| 204 No Content            | Successful `DELETE`, `PATCH` request                         |
| 201 Created               | Success `POST` request                                       |
| 400 Bad Request           | Validation requirements or formation error.                  |
| 401 Unauthorized          | When anonymous user want to access any authenticated endpoint |
| 403 Forbidden             | User doesn't have the permission to access that endpoint     |
| 404 Not Found             | If requested result not found by the system                  |
| 405 Method Not Allowed    | If requested method doesn't support by the endpoint          |
| 406 Not Acceptable        | If requested form (`Content-Type` and `Accept`) doesn't support by the system. See **Content Negotiation** |
| 500 Internal Server Error | Whenever server is failed to execute or finish a task.       |



## Values

### Types

**User Types**

* `Admin` = 1
* `Agent` = 2
* `Actuator` = 3       
* `Sensor` = 4
* `ActuatorAndSensor`  = 5
* `Other` = 6



**Profile Types**

* `Agent` = 1

* `Device` = 2

* `People` = 3



### Authorize Permissions

* **Admin** required admin type user
* **AgentOrAdmin** required admin or agent type user



## Endpoints

***



### Authentication

Any user (including anonymous) can access authentication endpoints



#### POST  `/api/authentication/login`

**Request**

```json
{
  "name": "string",
  "password": "string"
}
```

**Response**

```json
{
  "bearer": "string"
}
```





#### POST  `/api/authentication/internal-login`

**Request**

```json
{
  "name": "string",
  "password": "string"
}
```

**Response**

```json
{
  "bearer": "string"
}
```

***



### Profile

Only authenticated users can access profile endpoints



#### GET  `/api/profiles/{id}`

****

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ------ |
| id   | path       |             | Yes      | string |

**Permission**: `Admin Or Agent`

**Response**

```json
{
  "displayName": "string",
  "userId": "string",
  "type": 1,
  "createdDate": "2020-05-17T11:45:31.978Z",
  "lastModifiedDate": "2020-05-17T11:45:31.978Z",
  "id": "string"
}
```





#### PUT  `/api/profiles/{id}`
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ------ |
| id   | path       |             | Yes      | string |

**Permission:** `Admin`

**Request**

```json
{
  "displayName": "string",
  "userId": "string",
  "type": 1,
  "id": "string"
}
```

**Response**

```json
{
  "displayName": "string",
  "userId": "string",
  "type": 1,
  "createdDate": "2020-05-17T11:45:31.978Z",
  "lastModifiedDate": "2020-05-17T11:45:31.978Z",
  "id": "string"
}
```





#### DELETE  `/api/profiles/{id}`

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ------ |
| id   | path       |             | Yes      | string |

**Permission:** `Admin`

**Response**

> 204 No Content





#### GET  `/api/profiles`

**Permission:** `Admin or Agent`

**Response**

```json
[
  {
    "displayName": "string",
    "userId": "string",
    "type": 1,
    "createdDate": "2020-05-17T11:50:38.102Z",
    "lastModifiedDate": "2020-05-17T11:50:38.102Z",
    "id": "string"
  }
]
```



#### POST  `/api/profiles`

**Permission:** `Admin`

##### Request

```json
{
  "displayName": "string",
  "userId": "string",
  "type": 1
}
```

##### Response

```json
{
  "displayName": "string",
  "userId": "string",
  "type": 1,
  "createdDate": "2020-05-17T11:51:07.857Z",
  "lastModifiedDate": "2020-05-17T11:51:07.857Z",
  "id": "string"
}
```





#### PATCH  `/api/profiles/{id}/subscriptions`
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ------ |
| id   | path       |             | Yes      | string |

**Permission:** `Admin`

##### Request

```json
{
  "profileId": "string",
  "path": "string"
}
```

##### Response

> 204 No Content





#### DELETE  `/api/profiles/{id}/subscriptions`
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ------ |
| id   | path       |             | Yes      | string |

**Permission:** `Admin`

##### Response

> 204 No Content





#### GET  `/api/profiles/{id}/subscriptions`

##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ------ |
| id   | path       |             | Yes      | string |

**Permission:** `Admin or Agent`

##### Response

```json
[
  {
    "profileId": "string",
    "path": "string"
  }
]
```

***



### User

Only authenticated users can access user endpoints



#### GET  `/api/users/{id}`
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ------ |
| id   | path       |             | Yes      | string |

**Permission:** `Admin or Agent`

##### Response

```json
{
  "name": "string",
  "type": 1,
  "isActive": true,
  "isConnected": true,
  "lastConnected": "2020-05-17T13:10:00.245Z",
  "createdDate": "2020-05-17T13:10:00.245Z",
  "lastModifiedDate": "2020-05-17T13:10:00.245Z",
  "id": "string"
}
```



#### POST  `/api/users`

**Permission**: `Admin`

**Request**

```json
{
  "name": "string",
  "password": "string",
  "type": 1,
  "isActive": true,
}
```

##### Response

```json
{
  "name": "string",
  "type": 1,
  "isActive": true,
  "isConnected": true,
  "lastConnected": "2020-05-17T13:11:42.274Z",
  "createdDate": "2020-05-17T13:11:42.274Z",
  "lastModifiedDate": "2020-05-17T13:11:42.274Z",
  "id": "string"
}
```



#### GET  `/api/users`

**Permission:** `Admin or Agent`

##### Response

```json
[
  {
    "name": "string",
    "type": 1,
    "isActive": true,
    "isConnected": true,
    "lastConnected": "2020-05-17T13:12:47.765Z",
    "createdDate": "2020-05-17T13:12:47.765Z",
    "lastModifiedDate": "2020-05-17T13:12:47.765Z",
    "id": "string"
  }
]
```



#### GET  `/api/users/connected`

**Permission:** `Admin or Agent`

##### Response

```json
[
  {
    "name": "string",
    "type": 1,
    "isActive": true,
    "isConnected": true,
    "lastConnected": "2020-05-17T13:12:47.765Z",
    "createdDate": "2020-05-17T13:12:47.765Z",
    "lastModifiedDate": "2020-05-17T13:12:47.765Z",
    "id": "string"
  }
]
```



****

