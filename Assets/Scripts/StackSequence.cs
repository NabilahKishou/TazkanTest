using EventBusSystem;
using System.Collections.Generic;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class StackSequence : MonoBehaviour
    {
        [SerializeField] private BasketStack _stack;
        [SerializeField] private ColorDirectory _colors;
        [SerializeField] private int _sequence = 4;

        private List<int> _colorSequence = new List<int>();

        private void Awake()
        {
            EventBus.Subscribe<EventParameter<int[]>>(EventStringDirectory.CheckSequence_ArrInt,
                (par) => CheckSequence(par.value));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
                CreateSequence();
        }

        private void CreateSequence()
        {
            for (int i = 0; i < _sequence; i++)
            {
                int color = Random.Range(0, _colors.EnumLength());
                //int color = 0;
                _stack.CollectDroplet((Colorway)color);
                if (i >= _colorSequence.Count)
                    _colorSequence.Add(color);
                else
                    _colorSequence[i] = color;
            }
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

            Debug.Log("SEQUENCE MATCH!");
        }
    }
}