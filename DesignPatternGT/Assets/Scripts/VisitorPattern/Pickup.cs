using UnityEngine;

namespace VisitorPattern
{
    public class Pickup : MonoBehaviour
    {
        public PowerUp powerUp;

        void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BikeController>())
            {
                other.GetComponent<BikeController>().Accept(powerUp);
                Destroy(gameObject);
            }
        }
    }
}