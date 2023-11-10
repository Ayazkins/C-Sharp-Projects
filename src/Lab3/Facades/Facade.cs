using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Topics;

namespace Itmo.ObjectOrientedProgramming.Lab3.Facades;

public class Facade : IFacade
{
    private Dictionary<string, Topic> _topics;

    public Facade()
    {
        _topics = new Dictionary<string, Topic>();
    }

    public void Add(Topic topic)
    {
        if (topic == null)
        {
            throw new ArgumentNullException(nameof(topic));
        }

        _topics.Add(topic.Name, topic);
    }

    public void SendMessage(string name, Message message)
    {
        _topics[name].TakeMessage(message);
    }

    public void Remove(string name)
    {
        _topics.Remove(name);
    }
}