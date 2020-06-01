<div class="page-header">
    <a class="btn" href="./api_doc">API Doc</a>
    <a class="btn" href="./broker_doc">Broker Doc</a>
    <a class="btn" href="./agent_doc">Agent Doc</a>
</div>






# IotHub Broker

A .NET web project to host [MQTT Server](https://github.com/chkr1011/MQTTnet). Broker is responsible to receive all messages publish by clients on particular topics, filter them, send clients who are subscribed on that topics. IotHub solution is using [MQTTnet](https://github.com/chkr1011/MQTTnet) library.



### Overview MQTT

>  **©** https://mosquitto.org/

**MQTT** is a lightweight publish/subscribe messaging protocol. It is useful for use with low power sensors, but is applicable to many scenarios.

This manual describes some of the features of MQTT version 3.1.1/3.1, to assist end users in getting the most out of the protocol. For more complete information on MQTT, see `http://mqtt.org/`.



#### Publish/Subscribe

The MQTT protocol is based on the principle of publishing messages and subscribing to topics, or "pub/sub". Multiple clients connect to a broker and subscribe to topics that they are interested in. Clients also connect to the broker and publish messages to topics. Many clients may subscribe to the same topics and do with the information as they please. The broker and MQTT act as a simple, common interface for everything to connect to. 



#### Topics/Subscriptions

Messages in MQTT are published on topics. There is no need to configure a topic, publishing on it is enough. Topics are treated as a hierarchy, using a slash (/) as a separator. This allows sensible arrangement of common themes to be created, much in the same way as a filesystem. For example, multiple computers may all publish their hard drive temperature information on the following topic, with their own computer and hard drive name being replaced as appropriate:

- `sensors/COMPUTER_NAME/temperature/HARDDRIVE_NAME`

Clients can receive messages by creating subscriptions. A subscription may be to an explicit topic, in which case only messages to that topic will be received, or it may include wildcards. Two wildcards are available, `+` or `#`.

`+` can be used as a wildcard for a single level of hierarchy. It could be used with the topic above to get information on all computers and hard drives as follows:

- sensors/+/temperature/+

As another example, for a topic of "a/b/c/d", the following example subscriptions will match:

- a/b/c/d
- +/b/c/d
- a/+/c/d
- a/+/+/d
- +/+/+/+

The following subscriptions will not match:

- a/b/c
- b/+/c/d
- +/+/+

`#` can be used as a wildcard for all remaining levels of hierarchy. This means that it must be the final character in a subscription. With a topic of "a/b/c/d", the following example subscriptions will match:

- a/b/c/d
- \#
- a/#
- a/b/#
- a/b/c/#
- +/b/c/#

Zero length topic levels are valid, which can lead to some slightly non-obvious behavior. For example, a topic of `a//topic` would correctly match against a subscription of `a/+/topic`. Likewise, zero length topic levels can exist at both the beginning and the end of a topic string, so `/a/topic` would match against a subscription of `+/a/topic`, `#` or `/#`, and a topic `a/topic/` would match against a subscription of `a/topic/+` or `a/topic/#`.

***



### SYS Topics

Many MQTT brokers implement SYS-Topics. These topics are special meta topics that the broker can use to publish information about the broker itself and its MQTT client sessions. All SYS-Topics start with **$SYS** and are read-only for MQTT clients. The MQTT broker should prevent clients from using such topic names to publish messages. 

> https://www.hivemq.com/blog/why-you-shouldnt-use-sys-topics-for-monitoring/

A documentation about System topics is available [here](https://github.com/mqtt/mqtt.github.io/wiki/SYS-Topics)

***



## How to Use

#### Authentication

To connect with broker a client must authenticate with valid `UserName` , `Password` and `ClientID`. 

| User Name | Password | Client ID | User Type | Response                   |
| --------- | -------- | --------- | --------- | -------------------------- |
| Invalid   | Invalid  | Invalid   | any       | `BadUserNameOrPassword`    |
| Valid     | Valid    | Invalid   | any       | `ClientIdentifierNotValid` |
| Valid     | Valid    | Valid     | Other     | `NotAuthorized`            |
| Valid     | Valid    | Valid     | X         | `Success`                  |

Here **X** is representing not `Other` type. e.g:

* Admin

* Agent

* Sensor

* Actuator

* Sensor and Actuator

  

#### Subscription

IotHub Broker allow only admin/agent to subscribe any topic. Otherwise broker will check whether client has the subscription on that topic. Every client has a list of subscription provided by admin that it can subscribe. Check **API** documentation to find out how to **add/remove** subscription of a client/user. Make sure that `$SYS` topics are allowed to subscribe. Because these topics are reserved for internal communication not for public broadcast.



#### SYS topics

IotHub broker allow only **agent** to publish `$SYS` to topic to make a request or command to MQTT broker to execute some internal execution i.e  *Request to disconnect a client, Request to get connected clients id*. Broker doesn't broadcast this agent`s system publish. broker will perform an internal execution and broadcast all respective clients about that execution as an response event. And thus agent will get the associated response of its request.



<p align="center">
	<img src="./images/system_topics.svg" />
</p>





**IotHub broker of SYS topics**

* **Get Connected Clients ID's**

  > Request:

  `$SYS/request/broker/clients/connected`

  > Response:

  `$SYS/broker/clients/connected`

  ```json
  {
      "IDList" : ["5abc123", "5abc1254"]
  }
  ```

  

* **Get Number Connected Clients**

  > Request:

  `$SYS/request/broker/clients/connected/count`

  > Response:

  `$SYS/broker/clients/connected/count`

  ```json
  {
      "Count" : 2
  }
  ```

* **Recently Connected Client Event**

  > Response

  `$SYS/broker/clients/connect/new`

  ```json
  "5ab12354565"
  ```

  

* **Recently Disconnected Client Event**

  > Response

  `$SYS/broker/clients/disconnect/new`

  ```json
  "5ab12354565"
  ```

  
