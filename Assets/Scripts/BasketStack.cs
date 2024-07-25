using System.Collections.Generic;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class BasketStack : MonoBehaviour
    {
        [SerializeField] private ItemStack _stackPrefab;
        [SerializeField] private int _stackCapacity = 3;
        [SerializeField] private Transform _bottomPoint;

        private List<ItemStack> _stacks = new List<ItemStack>();
        private int _activeIndex = 0;

        private void Start()
        {
            SpawnStack();
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out ColorDrop droplet))
            {
                CollectDroplet(droplet.DropletColor);
            }
        }

        private void SpawnStack()
        {
            for (int i = 0; i < _stackCapacity; i++)
            {
                var obj = Instantiate(_stackPrefab, this.transform);
                CalculateStackObj(obj.transform, i);
                obj.gameObject.SetActive(false);
                _stacks.Add(obj);
            }
        }

        private void CalculateStackObj(Transform colorObj, int order)
        {
            float dropletHeight = transform.localScale.y / _stackCapacity;
            float bottPivot = _bottomPoint.localPosition.y + dropletHeight / 2;
            colorObj.localScale = new Vector2(transform.localScale.x, dropletHeight);
            colorObj.localPosition = new Vector3(transform.localPosition.x,
                bottPivot + (dropletHeight * order));
        }

        private void CollectDroplet(Colorway color)
        {
            if (_activeIndex >= _stackCapacity) return;
            _stacks[_activeIndex].ChangeColor(color);
            _stacks[_activeIndex].gameObject.SetActive(true);
            _activeIndex++;
        }
    }
}