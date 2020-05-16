# IotHub Agent

A .NET solution to host an MQTT Client as Agent and SignalR Hub. This project make a channel between MQTT Broker and SignalR Hub. SignalR Hub allow admin and other controllers to publish/request to MQTT Broker as MQTT Agent client via SignalR Hub method invoking and can also receive all published message on any topic to MQTT Broker.



<p align="center"><img src="../images/broker_architecture.svg"/></p>
***

## How to Use

Agent project is mainly design to provide admin/control level communication channel (get broker internal information and send commands to broker).

To run IotHub Agent project, IotHub Broker must be in running state, otherwise MQTT Client Agent can't connect with MQTT Broker.

By default IotHub Agent launch settings is

```json
HTTP Port: 4000
HTTPS Port: 4001
```

Launch settings is available in `IotHub.Agent\Properties\launchSettings.json`

**Note** MQTT Broker must run in Port `1883` as MQTT default port.



### Connection

Here is an example how to connect Agent SignalR Hub using JavaScript. Hub connection endpoint is `{HOST}/agenthub`

**Required package**

* `@aspnet/signalr`

  

```javascript
import * as SignalR from "@aspnet/signalr";

let hubConnection = new SignalR.HubConnectionBuilder()
      .withUrl('https://localhost:4001/')
      .build();

hubConnection
      .start()
      .then(() => {
        console.log("agent hub connected")
      })
      .catch((err) => {
        console.error(err);
      });
```



### Events

There are two event method available, one is for track the Agent MQTT Client connection status and another for MQTT Broker Broadcast.

* **`Broadcast(string topic, string payload)`**

  This event will fire on every MQTT broker message publish.

  Here is JavaScript example code

  ```javascript
  hubConnection.on("Broadcast", (topic, payload) => {
     console.log(`${topic}: ${payload}`) 
  });
  ```

  

* **`AgentConnectionStatus(bool isConnected)`**

  This event will fire on connected/disconnected event of Agent MQTT Client.

  Here is JavaScript example code

  ```javascript
  hubConnection.on("AgentConnectionStatus", (isConnected) => {
      let status = isConnected ? "Connected" : "Disconnected"
      console.log(status)
  })
  ```

  

### Invoke

To make a request to MQTT Broker, invoke the method SignalR Hub `RequestMqttBroker` method with `topic` and `payload`, SignalR Hub will publish this message to MQTT Broker by Agent MQTT Client. Then MQTT Broker will take the responsibility of that publishing.

**`RequestMqttBroker(string topic, string payload)`**

Here is JavaScript example code to request MQTT Broker to disconnect a client

```javascript
let remoteMethod = "RequestMqttBroker"
let topic = "$SYS/request/broker/clients/disconnect/command";
let payload = "5abc12345";
hubConnection.invoke(remoteMethod, topic, payload)
```



***

#### An example of [IotHub Dashboard](https://github.com/rafiulgits/iothub-dashboard)

