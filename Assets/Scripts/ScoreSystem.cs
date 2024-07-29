using EventBusSystem;
using TMPro;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class ScoreSystem : MonoBehaviour
    {
        [SerializeField] private IntVariable _scoreRef;

        private TMP_Text _scoreText;

        private void Awake()
        {
            _scoreText = GetComponent<TMP_Text>();

            EventBus.Subscribe(EventStringDirectory.RestartGame, ResetScore);

            _scoreRef.AddListener(OnScoreUpdate);
            _scoreRef.SetValue(0);
        }

        private void ResetScore()
        {
            _scoreRef.SetValue(0);
        }

        private void OnScoreUpdate()
        {
            _scoreText.text = _scoreRef.value.ToString();
        }
    }
}