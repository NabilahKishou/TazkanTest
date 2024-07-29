using EventBusSystem;
using System;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class BasketController : MonoBehaviour
    {
        [SerializeField] private ColorStacker _stacker;
        [SerializeField] private IntVariable _scoreRef;
        [SerializeField] private float _moveSpeed = 3f;

        private Rigidbody2D _rb;
        private InputSystem _input;
        private Vector2 _initialPos;
        private float _moveAxis = 0f;
        private float _mouseXAxis = 0f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _input = GetComponent<InputSystem>();

            _initialPos = this.transform.position;

            EventBus.Subscribe(EventStringDirectory.SequenceMatch, OnSequenceMatch);
            EventBus.Subscribe(EventStringDirectory.ClearBasket, OnClearButtonCalled, EventListenerPriority.High);
            EventBus.Subscribe(EventStringDirectory.RestartGame, ResetBasket);

            _input.AddMoveListener(OnMove);
            _input.AddMouseMoveListener(OnMouseMove);
        }

        private void FixedUpdate()
        {
            //_rb.velocity = new Vector2(_moveAxis * _moveSpeed, _rb.velocity.y);
            transform.position = new Vector2(Mathf.Clamp(_mouseXAxis, -2.3f, 2.3f),
                transform.position.y);
        }

        private void ResetBasket()
        {
            _stacker.ClearDroplet();
            transform.position = _initialPos;
        }

        private void OnMouseMove(Vector2 value)
        {
            _mouseXAxis = value.x;
        }

        private void OnMove(float value)
        {
            _moveAxis = value;
        }

        private void OnSequenceMatch()
        {
            _stacker.ClearDroplet();
        }

        private void OnClearButtonCalled()
        {
            int dropletAmount = _stacker.GetDropletOrder().Length;
            _stacker.ClearDroplet();
            _scoreRef.ApplyChange(-dropletAmount);
        }

        public void EnterBasket(Colorway color)
        {
            _stacker.InsertDroplet(color);
            EventBus.Invoke(EventStringDirectory.CheckSequence_ArrInt,
                new EventParameter<int[]>(_stacker.GetDropletOrder()));
        }
    }
}