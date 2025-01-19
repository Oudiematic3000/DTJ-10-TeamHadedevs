using UnityEngine;

public class Despawn : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Customer"))
        {
            Destroy(other.gameObject);
            Debug.Log("Gameover");
            losePanel.SetActive(true);
        }
    }
}