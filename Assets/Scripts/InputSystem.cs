using System;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class InputSystem : MonoBehaviour
    {
        private float _currentXAxis = 0f;
        private float _xAxis = 0f;

        private event Action<float> OnMove = delegate { };
        private event Action<Vector2> OnMouseMove = delegate { };

        private void Update()
        {
            _xAxis = Input.GetAxisRaw("Horizontal");
            if (_currentXAxis != _xAxis)
            {
                _currentXAxis = _xAxis;
                OnMove.Invoke(_xAxis);
            }

            if (Input.GetMouseButtonDown(0))
                MousePosition();
        }

        private void MousePosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            var worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            OnMouseMove.Invoke(worldPosition);
        }

        public void AddMouseMoveListener(Action<Vector2> listener) => OnMouseMove += listener;
        public void AddMoveListener(Action<float> listener) => OnMove += listener;
    }
}