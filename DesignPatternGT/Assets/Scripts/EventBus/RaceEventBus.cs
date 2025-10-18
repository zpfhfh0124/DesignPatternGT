using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Chapter.EventBus
{
    public enum RaceEventType
    {
        COUNTDOWN, START, RESTART, STOP, PAUSE, FINISH, QUIT
    }
    
    public class RaceEventBus
    {
        private static readonly IDictionary<RaceEventType, UnityEvent> Events =
            new Dictionary<RaceEventType, UnityEvent>();

        public static void Subscribe(RaceEventType eventType, UnityAction listener)
        {
            if (Events.TryGetValue(eventType, out var thisEvent))
            {
                thisEvent.AddListener(listener);
            }
            else
            {
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Events.Add(eventType, thisEvent);
            }
        }

        public static void Unsubscribe(RaceEventType eventType, UnityAction listener)
        {
            if (Events.TryGetValue(eventType, out var thisEvent))
            {
                thisEvent.RemoveListener(listener);
            }
        }

        public static void Publish(RaceEventType eventType)
        {
            if (Events.TryGetValue(eventType, out var thisEvent))
            {
                thisEvent.Invoke();
            }
        }
    }
}