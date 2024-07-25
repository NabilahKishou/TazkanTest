using System;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class InputSystem : MonoBehaviour
    {
        private float _currentXAxis = 0f;
        private float _xAxis = 0f;

        private event Action<float> OnMove = delegate { };

        private void Update()
        {
            _xAxis = Input.GetAxisRaw("Horizontal");
            if (_currentXAxis != _xAxis)
            {
                _currentXAxis = _xAxis;
                OnMove.Invoke(_xAxis);
            }
        }

        public void AddMoveListener(Action<float> listener) => OnMove += listener;
    }
}