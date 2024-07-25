using System.Collections.Generic;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class BasketStack : MonoBehaviour
    {
        [SerializeField] private GameObject _colorPrefab;
        [SerializeField] private int _stackCapacity = 3;
        [SerializeField] private Transform _bottomPoint;

        private List<Transform> _stacks = new List<Transform>();

        private void Start()
        {
            SpawnStack();
        }

        private void SpawnStack()
        {
            for (int i = 0; i < _stackCapacity; i++)
            {
                var obj = Instantiate(_colorPrefab, this.transform);
                CalculateStackObj(obj.transform, i);
                _stacks.Add(obj.transform);
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
    }
}