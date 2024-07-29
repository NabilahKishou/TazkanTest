using EventBusSystem;
using System.Collections;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ColorSpawner _spawner;
        [SerializeField] private StackSequence _stackSeq;

        private float _waveInterval = 1f;
        private int _wave = 0;
        private int _waveToSequence = 5;
        private int _sequenceCap = 1;

        private void Awake()
        {
            EventBus.Subscribe(EventStringDirectory.SequenceMatch, CompleteSequence);
            EventBus.Subscribe(EventStringDirectory.WaveSpawned, () => StartCoroutine(Wave()));
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(1f);
            _stackSeq.RefreshSequence(_sequenceCap);
            StartCoroutine(Wave());
        }

        private void CompleteSequence()
        {
            _wave++;
            if (_wave % _waveToSequence == 0)
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