# Unity-Event-Bus
An event manager that allows for decoupled clean code in Unity.

## Methods
Insantiate Event Bus
```c#
EventBus<IEvent> eventBus = new EventBus<IEvent>();
```

Publish (No arguments)
```c#
EventBus.Publish<EventClass>(new EventClass());
```

Publish (With arguments)
```c#
EventBus.Publish<EventClass>(new EventClass());
```

Subscribe
```c#
EventBus.Unsubscribe<EventClass>(method);
```

Unsubscribe
```c#
EventBus.Unsubscribe<EventClass>(method);
```

## Set up
Add the EventBus.cs file to your Unity project.

Next you will need to create a script acting as your overall event manager. How this is done is entirely optional and can be done with a singleton or by referencing scripts. In this case I will use a singleton.

For more information on how to use singletons:
https://gamedevbeginner.com/singletons-in-unity-the-right-way/

To instantiate an EventBus object do the following:
```c#
EventBus<IEvent> eventBus = new EventBus<IEvent>();
```
IEvent must be in the < >

or in the case of a singleton something like:
```c#
public class Singleton : MonoBehaviour 
{
    public static Singleton Instance { get; private set; }

    public EventBus<IEvent> eventBus;

    private void Awake() 
    { 
        ...
        
        eventBus = new EventBus<IEvent>();
    }
}
```

Next I recommend creating an event script to store your events. Events are stored as classes that much inherent from IEvent.
```c#
//Example event script
public class ExampleEvent : IEvent {}

public class ExampleEvent2 : IEvent {}

public class ExampleEvent3 : IEvent {}
```

Arguments can be passed through events by adding fields to the classes. These act as a template and should not have any values:
```c#
public class ExampleEvent : IEvent {
    public int num { get; set; };
    public string name { get; set; };
}
```

To publish an event:
```c#
EventBus.Publish<EventClass>(new EventClass());
```
It is important that the class type is specified between the < > and for no arguments leave object as is.


To pass arguments through an event:
```c#
EventBus.Publish<ExampleEvent>(new ExampleEvent { num = 10, name = "example"});
```
To pass arguments you must create a new object of your event class and assign new values to the fields you created.

In the case of a singleton you can publish and subcribe to an event without any coupling:
```c#
public class Publisher : MonoBehaviour
{
    void Start()
    {
        Singleton.Instance.eventBus.Publish<ExampleEvent>(new ExampleEvent());
    }
}
```

To subcribe and unsubscribe from an event:
```c#
EventBus.Subscribe<EventClass>(method);
EventBus.Unsubscribe<EventClass>(method);
```
Once again you must put your class type in the < > and specify the method you want to fire when the event is published.


Singleton example:
```
public class Subscriber : MonoBehaviour
{
    void OnEnable()
    {
        Singleton.Instance.eventBus.Subscribe<ExampleEvent>(DoThing);
    }

    void OnDisable()
    {
        Singleton.Instance.eventBus.Unsubscribe<ExampleEvent>(DoThing);
    }

    void DoThing(ExampleEvent eventData)
    {
        Debug.Log(eventData.num);

        //Outputs 10
    }
}
```




