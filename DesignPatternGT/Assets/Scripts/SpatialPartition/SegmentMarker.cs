using System;
using Chapter.State;
using UnityEngine;

namespace SpatialPartition
{
    public class SegmentMarker : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<BikeController>())
                Destroy(transform.parent.gameObject);
        }
    }
}