using System;
using UnityEngine;

namespace SpatialPartition
{
    public class Segment : MonoBehaviour
    {
        public TrackController trackController;

        private void OnDestroy()
        {
            if (trackController) trackController.LoadNextSegment();
        }
    }
}