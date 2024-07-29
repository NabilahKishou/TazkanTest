using EventBusSystem;
using System.Collections.Generic;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class StackSequence : MonoBehaviour
    {
        [SerializeField] private ColorStacker _stacker;
        [SerializeField] private ColorDirectory _colors;
        [SerializeField] private IntVariable _scoreRef;

        private List<int> _colorSequence = new List<int>();

        private void Awake()
        {
            EventBus.Subscribe<EventParameter<int[]>>(EventStringDirectory.CheckSequence_ArrInt,
                (par) => CheckSequence(par.value));
        }

        private void CheckSequence(int[] basket)
        {
            if (basket.Length != _colorSequence.Count)
                return;
            for (int i = 0; i < _colorSequence.Count; i++)
            {
                if (basket[i] != _colorSequence[i])
                    return;
            }
            
            _scoreRef.ApplyChange(_colorSequence.Count);
            EventBus.Invoke(EventStringDirectory.SequenceMatch);
        }

        public void RefreshSequence(int capacity)
        {
            _colorSequence.Clear();
            _stacker.ClearDroplet();
            for (int i = 0; i < capacity; i++)
            {
                int color = Random.Range(0, _colors.EnumLength());
                _colorSequence.Add(color);
                _stacker.InsertDroplet((Colorway)color);
            }
        }
    }
}