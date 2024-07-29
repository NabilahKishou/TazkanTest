using EventBusSystem;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class BasketController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private ColorStacker _stacker;

        private Rigidbody2D _rb;
        private InputSystem _input;
        private float _moveAxis = 0f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _input = GetComponent<InputSystem>();
            _input.AddMoveListener(OnMove);
            EventBus.Subscribe(EventStringDirectory.SequenceMatch, OnSequenceMatch);
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_moveAxis * _moveSpeed, _rb.velocity.y);
        }

        private void OnMove(float value)
        {
            _moveAxis = value;
        }

        private void OnSequenceMatch()
        {
            _stacker.ClearDroplet();
        }

        public void EnterBasket(Colorway color)
        {
            _stacker.InsertDroplet(color);
            EventBus.Invoke(EventStringDirectory.CheckSequence_ArrInt,
                new EventParameter<int[]>(_stacker.GetDropletOrder()));
        }
    }
}