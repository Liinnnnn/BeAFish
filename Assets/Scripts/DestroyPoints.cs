using UnityEngine;

public class DestroyPoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob"))
        {
            Destroy(collision.gameObject);
        }
    }
}
