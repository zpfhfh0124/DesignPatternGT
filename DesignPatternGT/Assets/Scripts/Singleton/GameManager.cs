using System;
using UnityEngine;

namespace GT.Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        DateTime _sessionStartTime;
        DateTime _sessionEndTime;
        
        void Start()
        {
            _sessionStartTime = DateTime.Now;
        }

        void OnApplicationQuit()
        {
            _sessionEndTime = DateTime.Now;
        }
    }
}