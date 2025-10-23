﻿using System;
using UnityEngine;

namespace VisitorPattern
{
    public class BikeShield : MonoBehaviour, IBikeElement
    {
        public float health = 50f; // %

        public float Damage(float damage)
        {
            health -= damage;
            return health;
        }
        
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(125, 0, 200, 20), "Shield Health: " + health);
        }
    }
}