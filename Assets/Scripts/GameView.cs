using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private GameObject _startPanel, _gameOverPanel;

        private void Start()
        {
            _startPanel.SetActive(true);
        }

        public void CallStartPanel()
        {
            _gameOverPanel.SetActive(false);
            _startPanel.SetActive(true);
        }

        public void CallGameOverPanel()
        {
            _startPanel.SetActive(false);
            _gameOverPanel.SetActive(true);
        }

        public void CloseAll()
        {
            _startPanel.SetActive(false);
            _gameOverPanel.SetActive(false);
        }
    }
}