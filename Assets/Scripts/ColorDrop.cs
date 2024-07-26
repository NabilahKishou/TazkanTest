using System.Collections;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class ColorDrop : MonoBehaviour
    {
        [SerializeField] private ColorDirectory _colors;
        [SerializeField] private float _timerToDrop = 3f;

        private SpriteRenderer _renderer;
        private Rigidbody2D _rb;
        private Collider2D _collider;
        private Colorway _colorway;

        public Colorway DropletColor => _colorway;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out BasketController basket))
            {
                DeactivateDroplet();
                basket.EnterBasket(_colorway);
            }
            else if (collision.gameObject.TryGetComponent(out GroundController ground))
            {
                DeactivateDroplet();
                ground.LiftPlatform();
            }
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

        private void RandomizeColor()
        {
            _colorway = (Colorway)Random.Range(0, _colors.EnumLength());
            //_colorway = (Colorway)0;
            _renderer.color = _colors.GetColor(_colorway);
        }

        public void ActivateDroplet()
        {
            RandomizeColor();
            _collider.isTrigger = true;
            StartCoroutine(ActivateGravity(_timerToDrop));
        }
    }
}