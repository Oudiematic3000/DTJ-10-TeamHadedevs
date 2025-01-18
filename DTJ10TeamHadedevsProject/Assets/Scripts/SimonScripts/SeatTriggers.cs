using UnityEngine;
using UnityEngine.Tilemaps;

public class SeatTriggers : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Customer"))
        {
            Vector3 worldPosition = other.transform.position;
            Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
            cellPosition = new Vector3Int(-5,-4,0);
            
            Debug.Log("World Position: " + worldPosition + ", Cell Position: " + cellPosition);
            TileBase tile = tilemap.GetTile(cellPosition);

            if (tile != null)
            {
                Debug.Log("Triggered tile at position: " + cellPosition + " - Tile: " + tile.name);
            } else {
                Debug.Log("No tile found at the triggered position");
            }
        }
    }
}
