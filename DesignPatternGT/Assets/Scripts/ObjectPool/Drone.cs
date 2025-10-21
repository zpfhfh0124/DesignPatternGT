using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Chapter.ObjectPool
{
    public class Drone : MonoBehaviour
    {
        public IObjectPool<Drone> Pool { get; set; }
        
        public float _currentHealth;

        [SerializeField] private float maxHealth = 100.0f;
        [SerializeField] private float timeToSelfDestruct = 3.0f;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        private void OnEnable()
        {
            AttackPlayer();
            StartCoroutine(SelfDestruct());
        }

        void OnDisable()
        {
            ResetDrone();
        }

        private IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            TakeDamage(maxHealth);
        }

        void ReturnToPool()
        {
            Pool.Release(this);
        }

        private void ResetDrone()
        {
            _currentHealth = maxHealth;
        }

        private void AttackPlayer()
        {
            Debug.Log("Attack player");
        }

        private void TakeDamage(float amount)
        {
            _currentHealth -= amount;
            
            if(_currentHealth <= 0f) ReturnToPool();
        }
    }
}