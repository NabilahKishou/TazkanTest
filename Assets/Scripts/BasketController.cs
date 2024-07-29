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
        private float _moveAxis = 0f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _input = GetComponent<InputSystem>();
            _input.AddMoveListener(OnMove);
            EventBus.Subscribe(EventStringDirectory.SequenceMatch, OnSequenceMatch);
            EventBus.Subscribe(EventStringDirectory.ClearBasket, OnClearButtonCalled);
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