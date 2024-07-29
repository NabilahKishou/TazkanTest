using EventBusSystem;
using PrimeTween;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class GroundController : MonoBehaviour
    {
        [SerializeField] private float _liftLevel = 1f;
        [SerializeField] private float _liftDuration = .5f;
        [SerializeField] private float _dropDuration = 1f;

        private Vector2 _defaultPosition;

        private void Awake()
        {
            EventBus.Subscribe(EventStringDirectory.SequenceMatch, DropPlatform);
            EventBus.Subscribe(EventStringDirectory.RestartGame, ResetPlatform);

            _defaultPosition = new Vector2(transform.position.x, transform.position.y);
        }

        private void ResetPlatform()
        {
            transform.position = _defaultPosition;
        }

        public void LiftPlatform()
        {
            Tween.PositionY(transform, transform.position.y + _liftLevel, _liftDuration, Ease.Linear);
        }

        public void DropPlatform()
        {
            if (transform.position.y == _defaultPosition.y) return;
            Tween.PositionY(transform, _defaultPosition.y, _dropDuration, Ease.Linear);
        }
    }
}