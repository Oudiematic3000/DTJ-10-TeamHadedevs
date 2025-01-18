using UnityEngine;

public class Despawn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Customer"))
        {
            Destroy(other.gameObject);
        }
    }
}
