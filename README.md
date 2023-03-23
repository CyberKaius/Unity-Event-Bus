# Unity-Event-Bus
An event manager that allows for decoupled communication in Unity.

## Methods
Insantiate Event Bus
```c#
EventBus<IEvent> eventBus = new EventBus<IEvent>();
```


Create Event Class
```c#
public class EventClass : IEvent {}
```


Create Event Class With Arguments
```c#
public class EventClass : IEvent {
    public string name { get; set; };
    public int num { get; set; };
}

```


Publish (No arguments)
```c#
EventBus.Publish<EventClass>(new EventClass());
```


Publish (With arguments)
```c#
EventBus.Publish<EventClass>(new EventClass { name = "Jack", age = 25 });
```


Subscribe
```c#
EventBus.Unsubscribe<EventClass>(method);
```


Unsubscribe
```c#
EventBus.Unsubscribe<EventClass>(method);
```



Subscribed Function
```c#
void DoThing(EventClass eventData)
{
    Debug.Log(eventData.name);
}
```
eventData must be a parameter everytime due to delegates.





