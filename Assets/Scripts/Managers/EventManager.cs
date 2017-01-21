using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void Handler(params object[] args);

    public static void Listen(string message, Handler action)
    {
        var actions = listeners[message] as Handler;
        if (actions != null)
        {
            listeners[message] = actions + action;
        }
        else
        {
            listeners[message] = action;
        }
    }

    public static void Remove(string message, Handler action)
    {
        var actions = listeners[message] as Handler;
        if (actions != null)
        {
            listeners[message] = actions - action;
        }
    }

    public static void Send(string message, params object[] args)
    {
        var actions = listeners[message] as Handler;
        if (actions != null)
        {
            actions(args);
        }
    }

    private static Hashtable listeners = new Hashtable();
}

