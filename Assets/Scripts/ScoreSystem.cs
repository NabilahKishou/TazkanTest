using EventBusSystem;
using TMPro;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class ScoreSystem : MonoBehaviour
    {
        private TMP_Text _scoreText;
        private int _score = 0;

        private void Awake()
        {
            _scoreText = GetComponent<TMP_Text>();
            EventBus.Subscribe<EventParameter<int>>(EventStringDirectory.ScoreUpdate_int, 
                (p)=> OnScoreUpdate(p.value));

            _scoreText.text = _score.ToString();
        }

        private void OnScoreUpdate(int amount)
        {
            _score += amount;
            _scoreText.text = _score.ToString();
        }
    }
}