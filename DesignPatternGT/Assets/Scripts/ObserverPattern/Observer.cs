using UnityEngine;

namespace Chapter.ObserverPattern
{
    public abstract class Observer : MonoBehaviour
    {
        public abstract void Notify(Subject subject);
    }
}