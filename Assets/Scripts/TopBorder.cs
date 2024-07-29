using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    public class TopBorder : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out BasketController basket))
            {
                Debug.Log("GAME OVER!");
            }
        }
    }
}