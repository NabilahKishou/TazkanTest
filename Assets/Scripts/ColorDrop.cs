using System.Collections;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class ColorDrop : MonoBehaviour
    {
        [SerializeField] private float _timerToDrop = 3f;

        private SpriteRenderer _renderer;
        private Rigidbody2D _rb;
        private Collider2D _collider;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
                DeactivateDroplet();
        }

        private void DeactivateDroplet()
        {
            _rb.gravityScale = 0;
            _collider.isTrigger = false;
            ColorPooler.Return(this);
        }

        private IEnumerator ActivateGravity(float wait)
        {
            yield return new WaitForSeconds(wait);
            _rb.gravityScale = 1;
        }

        public void ActivateDroplet()
        {
            _collider.isTrigger = true;
            StartCoroutine(ActivateGravity(_timerToDrop));
        }

        public void ChangeColor(Color to)
        {
            _renderer.color = to;
        }
    }
}