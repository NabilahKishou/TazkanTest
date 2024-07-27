using EventBusSystem;
using System.Collections;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class ColorSpawner : MonoBehaviour
    {
        [SerializeField] Transform _leftSide, _rightSide;

        private void SpawnColor()
        {
            var droplet = ColorPooler.GetDroplet();
            RandomizePosition(droplet.transform);
            droplet.ActivateDroplet();
        }

        private void RandomizePosition(Transform drop)
        {
            var spawn = new Vector2(0, _leftSide.position.y);
            var radius = drop.localScale.x / 2;
            int iteration = 10;

            for (int i = 0; i < iteration; i++)
            {
                spawn = new Vector2(Random.Range(_leftSide.position.x, _rightSide.position.x),
                    _leftSide.position.y);
                var hitColliders = Physics2D.OverlapCircleAll(spawn, radius);
                if (hitColliders.Length > 0) continue;
                else break;
            }

            drop.position = spawn;
        }

        private IEnumerator SpawnDroplets(int wave, int seqAmount)
        {
            int dropletsPerWave = seqAmount + wave;
            float spawnIntervalMin = .5f;
            float spawnIntervalMax = 3f;
            for (int i = 0; i < dropletsPerWave; i++)
            {
                SpawnColor();
                yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));
            }
        }

        public IEnumerator SpawnWave(int wave, int seqAmount)
        {
            yield return SpawnDroplets(wave, seqAmount);
            EventBus.Invoke(EventStringDirectory.WaveSpawned);
        }
    }

    [System.Serializable]
    public class Wave
    {
        public ColorDrop[] droplet;
        public int count;
    }
}