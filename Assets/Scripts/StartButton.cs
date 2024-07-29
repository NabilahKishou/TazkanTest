using EventBusSystem;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace NabilahKishou.TazkanTest
{
    public class StartButton : MonoBehaviour
    {
        private Button _startButton;

        private void Awake()
        {
            _startButton = GetComponent<Button>();
            _startButton.onClick.AddListener(StartButtonClicked);
        }

        private void StartButtonClicked()
        {
            EventBus.Invoke(EventStringDirectory.StartGame);
        }
    }
}