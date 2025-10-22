using System;
using UnityEngine;

namespace Chapter.ObserverPattern
{
    public class HUDController : Observer
    {
        bool _isTurboOn = false;
        float _currentHealth;
        BikeController _bikeController;

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(50, 50, 100, 200));
            GUILayout.BeginHorizontal("box");
            GUILayout.Label($"Health: {_currentHealth}");
            GUILayout.EndHorizontal();

            if (_isTurboOn)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label($"Turbo Activated!");
                GUILayout.EndHorizontal();
            }

            if (_currentHealth <= 50f)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label($"WARNING: Low Health!");
                GUILayout.EndHorizontal();
            }
            
            GUILayout.EndArea();
        }

        public override void Notify(Subject subject)
        {
            if (!_bikeController) _bikeController = subject.GetComponent<BikeController>();

            if (_bikeController)
            {
                _isTurboOn = _bikeController.IsTurboOn;
                _currentHealth = _bikeController.CurrentHealth;
            }
        }
    }
}