using UnityEngine;

namespace Chapter.Command
{
    public class BikeController : MonoBehaviour
    {
        public enum Direction
        {
            Left = -1,
            Right = 1
        }

        private bool _isTurboOn = false;
        private float _distance = 1.0f;
        
        public void ToggleTurbo()
        {
            _isTurboOn = !_isTurboOn;
            Debug.Log($"Turbo Active: {_isTurboOn}");
        }

        public void Turn(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    transform.Translate(Vector3.left * _distance);
                    break;
                case Direction.Right:
                    transform.Translate(Vector3.right * _distance);
                    break;
                default:
                    break;
            }
        }

        public void ResetPosition()
        {
            transform.position = Vector3.zero;
        }
    }
}