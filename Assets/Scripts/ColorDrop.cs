using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class ColorDrop : MonoBehaviour
    {
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
            _collider.isTrigger = false;
            _rb.gravityScale = 0;
            ColorPooler.Return(this);
        }

        public void ActivateDroplet()
        {
            _collider.isTrigger = true;
            _rb.gravityScale = 1;
        }

        public void ChangeColor(Color to)
        {
            _renderer.color = to;
        }
    }
}