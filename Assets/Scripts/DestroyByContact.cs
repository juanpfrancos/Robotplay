using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle") | collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemy") | collision.CompareTag("laser"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
