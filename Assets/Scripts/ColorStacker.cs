using EventBusSystem;
using System.Collections.Generic;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class ColorStacker : MonoBehaviour
    {
        [SerializeField] private ItemStack _stackPrefab;
        [SerializeField] private int _defaultCap = 5;
        [SerializeField] private Transform _bottomPoint;

        private List<ItemStack> _stacks = new List<ItemStack>();
        private int _activeIndex = -1;
        private int _currentCapacity = 0;

        private void Awake()
        {
            EventBus.Subscribe<EventParameter<int>>(EventStringDirectory.UpgradeStacker_Int, (p) => UpgradeCapacity(p.value));
        }

        private void Start()
        {
            SetDefaultStack();
        }

        private void SpawnColor(int order, int max)
        {
            var obj = Instantiate(_stackPrefab, this.transform);
            //CalculateStackObj(obj.transform, order, max);
            obj.gameObject.SetActive(false);
            _stacks.Add(obj);
        }

        private void CalculateStackObj(Transform colorObj, int order, int maxCap)
        {
            float dropletHeight = transform.localScale.y / maxCap;
            float bottPivot = _bottomPoint.localPosition.y + dropletHeight / 2;
            colorObj.localScale = new Vector2(transform.localScale.x, dropletHeight);
            colorObj.localPosition = new Vector3(transform.localPosition.x,
                bottPivot + (dropletHeight * order));
        }

        private void SetDefaultStack()
        {
            for (int i = 0; i < _defaultCap; i++)
            {
                SpawnColor(_currentCapacity + i, _defaultCap);
                CalculateStackObj(_stacks[i].transform, i, _defaultCap);
            }
        }

        public void UpgradeCapacity(int maxCap)
        {
            if (maxCap <= _stacks.Count) return;

            for (int i = _stacks.Count-1; i < maxCap; i++)
            {
                SpawnColor(i, maxCap);
            }

            for (int i = 0; i < _stacks.Count; i++)
            {
                CalculateStackObj(_stacks[i].transform, i, _stacks.Count);
            }
        }

        public void InsertDroplet(Colorway color)
        {
            _activeIndex++;
            _stacks[_activeIndex].ChangeColor(color);
            _stacks[_activeIndex].gameObject.SetActive(true);
        }

        public void ClearDroplet()
        {
            _activeIndex = -1;
            for (int i = 0; i < _stacks.Count; i++)
            {
                _stacks[i].gameObject.SetActive(false);
            }
        }

        public int[] GetDropletOrder()
        {
            int[] order = new int[_activeIndex+1];
            for (int i = 0; i < order.Length; i++)
            {
                if (!_stacks[i].isActiveAndEnabled)
                    break;
                order[i] = (int)_stacks[i].Color;
            }
            return order;
        }
    }
}