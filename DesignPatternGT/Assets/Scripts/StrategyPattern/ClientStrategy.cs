using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StrategyPattern
{
    public class ClientStrategy : MonoBehaviour
    {
        private GameObject _drone;
        List<IManeuverBehaviour> _components = new List<IManeuverBehaviour>();

        void SpawnDrone()
        {
            _drone = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _drone.AddComponent<Drone>();
            _drone.transform.position = Random.insideUnitSphere * 10;
            ApplyRandomStrategies();
        }

        void ApplyRandomStrategies()
        {
            _components.Add(_drone.AddComponent<WeavingManeuver>());
            _components.Add(_drone.AddComponent<BoppingManeuver>());
            _components.Add(_drone.AddComponent<FallbackManeuver>());
            
            int index = Random.Range(0, _components.Count);
            _drone.GetComponent<Drone>().ApplyStrategy(_components[index]);
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Spawn Drone"))
            {
                SpawnDrone();
            }
        }
    }
}