using EventBusSystem;
using UnityEngine;
using UnityEngine.UI;

namespace NabilahKishou.TazkanTest
{
    public class GameOverButton : MonoBehaviour
    {
        private Button _restartButton;

        private void Awake()
        {
            _restartButton = GetComponent<Button>();
            _restartButton.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            EventBus.Invoke(EventStringDirectory.RestartGame);
        }
    }
}