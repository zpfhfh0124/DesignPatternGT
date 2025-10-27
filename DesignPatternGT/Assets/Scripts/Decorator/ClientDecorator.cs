﻿using System;
using UnityEngine;

namespace Decorator
{
    public class ClientDecorator : MonoBehaviour
    {
        private BikeWeapon _bikeWeapon;
        private bool _isWeaponDecorated;

        private void Start()
        {
            _bikeWeapon = (BikeWeapon)FindObjectOfType(typeof(BikeWeapon));
        }

        void OnGUI()
        {
            if (!_isWeaponDecorated)
            {
                if (GUILayout.Button("Decorate Weapon"))
                {
                    _bikeWeapon.Decorate();
                    _isWeaponDecorated = !_isWeaponDecorated;
                }
            }
            
            if (!_isWeaponDecorated)
            {
                if (GUILayout.Button("Reset Weapon"))
                {
                    _bikeWeapon.Reset();
                    _isWeaponDecorated = !_isWeaponDecorated;
                }
            }
            
            if(GUILayout.Button("Toggle Fire"))
                _bikeWeapon.ToggleFire();
        }
    }
}