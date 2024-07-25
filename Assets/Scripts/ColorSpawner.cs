using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class ColorSpawner : MonoBehaviour
    {
        [SerializeField] Transform _leftSide, _rightSide;
        [SerializeField] Transform[] pivots;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SpawnColor();
        }

        private void SpawnColor()
        {
            var droplet = ColorPooler.GetColor();
            droplet.transform.position = new Vector2(Random.Range(_leftSide.position.x, _rightSide.position.x),
                _leftSide.position.y);
            droplet.ActivateDroplet();
        }
    }
}