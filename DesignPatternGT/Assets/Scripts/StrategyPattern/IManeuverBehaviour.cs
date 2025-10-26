using System.Collections;
using UnityEngine;

namespace StrategyPattern
{
    public interface IManeuverBehaviour
    {
        void Maneuver(Drone drone);
    }
}