﻿using System;
using UnityEngine;

namespace VisitorPattern
{
    public class BikeEngine : MonoBehaviour, IBikeElement
    {
        public float turboBoost = 25f; // mph
        public float maxTurboBoost = 200f;
        
        bool _isTurboOn;
        private float _defaultSpeed = 300f; // mph

        public float CurrentSpeed
        {
            get
            {
                if(_isTurboOn) return _defaultSpeed + turboBoost;
                
                return _defaultSpeed;
            }
        }

        public void ToggleTurbo()
        {
            _isTurboOn = !_isTurboOn;
        }
        
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(125, 20, 200, 20), "Turbo Boost: " + turboBoost);
        }
    }
}