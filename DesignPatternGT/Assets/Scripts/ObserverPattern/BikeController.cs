﻿using System;
using UnityEngine;

namespace Chapter.ObserverPattern
{
    public class BikeController : Subject
    {
        public bool IsTurboOn { get; private set; }
        
        public float CurrentHealth
        {
            get { return health; }
        }

        private bool _isEngineOn;
        HUDController _hudController;
        CameraController _cameraController;
        
        [SerializeField] float health = 100f;

        private void Awake()
        {
            _hudController = gameObject.AddComponent<HUDController>();
            _cameraController = (CameraController)FindObjectOfType(typeof(CameraController));
        }

        private void Start()
        {
            StartEngine();
        }

        private void OnEnable()
        {
            if(_hudController) Attach(_hudController);
            
            if(_cameraController) Attach(_cameraController);
        }

        private void OnDisable()
        {
            if(_hudController) Detach(_hudController);
            
            if(_cameraController) Detach(_cameraController);
        }

        void StartEngine()
        {
            _isEngineOn = true;
            NotifyObservers();
        }

        public void ToggleTurbo()
        {
            if (_isEngineOn) IsTurboOn = !IsTurboOn;
            
            NotifyObservers();
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            IsTurboOn = false;
            
            NotifyObservers();
            
            if(health <= 0) Destroy(gameObject);
        }
    }
}