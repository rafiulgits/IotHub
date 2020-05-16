<div>
	<p align="center"><img src="images/logo.svg" /></p>
   	<h2 align="center">A cloud based IoT solution</h2>
</div>





### Solution Structure

* **IotHub.Agent**

  A .NET web project to establish the channel between `MQTT` broker and `SignalR` broker. This agent will publish all `MQTT` broker messages to `SignalR` clients  (dashboard, control panel) and send all commands from `SignalR` clients to `MQTT` clients. Agent is using [MQTTnet](https://github.com/chkr1011/MQTTnet)  `managed client` to connect with `MQTT` broker.

* **IotHub.API**

  A .NET web API project to provide and manage all data sources of the solution. This project use.

* **IotHub.Broker**

  A .NET web project to establish a MQTT broker server. Broker is using [MQTTnet](https://github.com/chkr1011/MQTTnet) `server`.

* **IotHub.Common**

  A .NET classlib project to provide all common models, enums, exceptions and other stuffs. 

* **IotHub.DataTransferObject**

  A .NET classlib project, using to transfer data from service layer to service, controller and other service consumers.

* **IotHub.DB**

  A .NET classlib project, to provide all database context and settings. Solution is using `MongoDB` as primary database. 

* **IotHub.DomianModels**

  A .NET classlib project, to provide domain level models.

* **IotHub.Repositories**

  A .NET classlib project, to communicate with database or data source and response in domain level. Only `IotHub.Services` have the access to use repository to provide a security level to access domain models.

* **IotHub.Services**

  A .NET classlib project, to provide all common services e.g authentication service, user management service, profile management services.






<div>
    <p align="center">
        <img src="images/solution_architecture.svg" />
    </p>
    <br/>
  	<h6 align="center">Solution Architecture</h6>
</div>



***



<div>
    <p align="center">
        <img src="images/broker_architecture.svg" />
    </p>
    <br/>
  	<h6 align="center">Broker Architecture</h6>
</div>



***

### How to use (development)

* Clone the project `git clone https://github.com/rafiulgits/IotHub`
* Make sure .NET core 3.1(min) is installed
* Go to `src` folder and build the solution `dotnet build`
* Start the development server of `src/IotHub.API` by `dotnet watch run` 
* Create some users including agent and admin types
* Put agent credentials in `src/IotHub.Agent/appSettings`
* Start the development server of `src/IotHub.Broker`  by `dotnet watch run`
* Start the development server of `src/IotHub.Agent` by `dotnet watch run`

Development environment is ready to use!



### Docs

* **[IotHub.Agent Doc](./docs/agent_doc.md)**
* **[IotHub.Broker Doc](./docs/broker_doc.md)**
* **[IotHub.API Doc](./docs/api_doc.md)**

