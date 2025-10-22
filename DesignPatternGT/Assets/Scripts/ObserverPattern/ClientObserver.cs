using System;
using UnityEngine;

namespace Chapter.ObserverPattern
{
    public class ClientObserver : MonoBehaviour
    {
        BikeController _bikeController;

        private void Start()
        {
            _bikeController = (BikeController)FindObjectOfType(typeof(BikeController));
        }

        void OnGUI()
        {
            if (GUILayout.Button("Damage Bike"))
            {
                if(_bikeController) _bikeController.TakeDamage(15.0f);

                if (GUILayout.Button("Toggle Turbo"))
                {
                    if(_bikeController) _bikeController.ToggleTurbo();
                }
            }
        }
    }
}