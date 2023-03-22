using System;
using System.Collections;
using System.Collections.Generic;

public class EventBus
{
    private Dictionary<object, List<EventHandler>> subscribers;

    public delegate void EventHandler();

    public EventBus()
    {
        subscribers = new Dictionary<object, List<EventHandler>>();
    }

    public void Subscribe<T>(EventHandler listener) where T : class
    {
        var type = typeof(T);

        if (!subscribers.ContainsKey(type))
            subscribers.Add(type, new List<EventHandler>());

        subscribers[type].Add(listener);
    }

    public void Unsubscribe<T>(EventHandler listener) where T : class
    {
        var type = typeof(T);

        if (!subscribers.ContainsKey(type))
            return;

        subscribers[type].Remove(listener);     
    }

    public void Publish<T>() where T : class
    {
        var type = typeof(T);

        if (!subscribers.ContainsKey(type))
            return;

        var listeners = subscribers[type];
 
        foreach(var value in listeners)
            value();
    }
}
