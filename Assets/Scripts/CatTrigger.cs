using UnityEngine;

public class CatTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Bird"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().PlayerDeath();
        }

        if (collision.gameObject.name.Equals("Coin"))
        {
            Destroy(collision.gameObject);
        }
        
    }
}
