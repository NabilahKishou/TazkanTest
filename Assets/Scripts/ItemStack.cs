using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class ItemStack : MonoBehaviour
    {
        [SerializeField] private ColorDirectory _colors;

        private SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void ChangeColor(Colorway to)
        {
            _renderer.color = _colors.GetColor(to);
        }
    }
}