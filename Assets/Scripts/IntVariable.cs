using System;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "Scriptable Objects/Variable Reference/Int Variable")]
    public class IntVariable : ScriptableObject
    {
        public int value;
        public event Action OnValueChanged = delegate { };

        public void SetValue(int value)
        {
            this.value = value;
            OnValueChanged.Invoke();
        }

        public void ApplyChange(int amount)
        {
            this.value += amount;
            OnValueChanged.Invoke();
        }

        public void AddListener(Action listener)
        {
            OnValueChanged += listener;
        }
    }
}