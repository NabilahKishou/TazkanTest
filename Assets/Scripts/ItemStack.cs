using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class ItemStack : MonoBehaviour
    {
        [SerializeField] private ColorDirectory _colors;

        private SpriteRenderer _renderer;
        private Colorway _way;

        public Colorway Color => _way;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void ChangeColor(Colorway to)
        {
            _way = to;
            _renderer.color = _colors.GetColor(_way);
        }
    }
}