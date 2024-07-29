using EventBusSystem;
using UnityEngine;
using UnityEngine.UI;

namespace NabilahKishou.TazkanTest
{
    public class ClearBasketButton : MonoBehaviour
    {
        [SerializeField] private IntVariable _scoreRef;
        private Button _clearBtn;

        private void Awake()
        {
            _clearBtn = GetComponent<Button>();
            _clearBtn.onClick.AddListener(ClearBtnClicked);
            _scoreRef.AddListener(OnScoreUpdated);
            OnScoreUpdated();
        }

        private void OnScoreUpdated()
        {
            _clearBtn.interactable = _scoreRef.value > 0;
        }

        private void ClearBtnClicked()
        {
            EventBus.Invoke(EventStringDirectory.ClearBasket);
        }
    }
}