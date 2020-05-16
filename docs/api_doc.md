# IotHub API

A .NET web API project to provide the API support of IotHub Solution. By default this project is hosting on `HTTP 5000` and `HTTPS 5001`. 

Open `/swagger` to view the **Swagger** interface.



**Authentication**

* `POST /api/authentication/login`

**Profile**

* `GET /api/profiles/id`
* `GET /api/profiles`
* `POST /api/profiles`
* `PUT /api/profiles/{id}`
* `DELETE /api/profiles/{id}`
* `PATCH /api/profiles/{id}/subscriptions`
* `DELETE /api/profiles/{id}/subscriptions`
* `GET /api/profiles/{id}/subscriptions`

**User**

* `GET /api/users`
* `POST /api/users`
* `GET /api/users/{id}`
* `GET /api/users/connected`