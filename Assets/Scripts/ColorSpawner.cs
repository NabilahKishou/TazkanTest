using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class ColorSpawner : MonoBehaviour
    {
        [SerializeField] Transform _leftSide, _rightSide;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SpawnColor();
        }

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
    }
}