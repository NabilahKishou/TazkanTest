using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class BasketController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 3f;

        private Rigidbody2D _rb;
        private InputSystem _input;
        private float _moveAxis = 0f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _input = GetComponent<InputSystem>();
            _input.AddMoveListener(OnMove);
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_moveAxis * _moveSpeed, _rb.velocity.y);
        }

        private void OnMove(float value)
        {
            _moveAxis = value;
        }
    }
}