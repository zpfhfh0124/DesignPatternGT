using System;
using System.Collections.Generic;
using UnityEngine;

namespace VisitorPattern
{
    public class BikeController : MonoBehaviour, IBikeElement
    {
        List<IBikeElement> _bikeElements = new List<IBikeElement>();

        private void Start()
        {
            _bikeElements.Add(gameObject.AddComponent<BikeShield>());
            _bikeElements.Add(gameObject.AddComponent<BikeWeapon>());
            _bikeElements.Add(gameObject.AddComponent<BikeEngine>());
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var element in _bikeElements)
            {
                element.Accept(visitor);
            }
        }
    }
}