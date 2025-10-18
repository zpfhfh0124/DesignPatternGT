﻿using UnityEngine;

namespace Chapter.EventBus
{
    public class BikeController : MonoBehaviour
    {
        private string _status;

        void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, StartBike);
            RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
        }

        void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.START, StartBike);
            RaceEventBus.Unsubscribe(RaceEventType.STOP, StopBike);
        }

        void StartBike()
        {
            _status = "Started";
        }

        void StopBike()
        {
            _status = "Stopped";
        }

        void OnGUI()
        {
            GUI.color = Color.white;
            GUI.Label(new Rect(10, 60, 200, 20), "Bike Status : " + _status);
        }
    }
}