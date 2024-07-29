using EventBusSystem;
using System.Collections;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ColorSpawner _spawner;
        [SerializeField] private StackSequence _stackSeq;
        [SerializeField] private IntVariable _scoreRef;

        private float _waveInterval = 1f;
        private int _wave = 0;
        private int _waveToSequence = 5;
        private int _sequenceCap = 1;
        private int _sequenceCapLimit = 10;

        private void Awake()
        {
            EventBus.Subscribe(EventStringDirectory.SequenceMatch, OnCompleteSequence);
            EventBus.Subscribe(EventStringDirectory.ClearBasket, OnClearBasket);
            EventBus.Subscribe(EventStringDirectory.WaveSpawned, () => StartCoroutine(Wave()));
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            _stackSeq.RefreshSequence(_sequenceCap);
            StartCoroutine(Wave());
        }

        private void OnClearBasket()
        {
            if (_sequenceCap <= 1) return;
            _sequenceCap = Mathf.CeilToInt((float)_scoreRef.value / (float)_waveToSequence);
            if (_sequenceCap < 1) _sequenceCap = 1;
            _stackSeq.RefreshSequence(_sequenceCap);
        }

        private void OnCompleteSequence()
        {
            if (_sequenceCap > _sequenceCapLimit) return;
            if(_scoreRef.value >= _waveToSequence * _sequenceCap)
            {
                _sequenceCap++;
                EventBus.Invoke(EventStringDirectory.UpgradeStacker_Int, new EventParameter<int>(_sequenceCap));
            }
            _stackSeq.RefreshSequence(_sequenceCap);
        }

        private IEnumerator Wave()
        {
            yield return _spawner.SpawnWave(_wave, _sequenceCap);
            yield return new WaitForSeconds(_waveInterval);
        }
    }
}