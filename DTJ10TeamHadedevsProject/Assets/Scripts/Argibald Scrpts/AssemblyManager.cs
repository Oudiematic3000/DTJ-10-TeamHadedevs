using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AssemblyManager : Minigame
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Ingredient[] stock;
    public GameObject storageButtonPrefab;
    public GameObject content;
    public Image image;

    public GridLayoutGroup gridLayoutGroup;
    public RectTransform contentRect;
    Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        image.sprite = player.hand.GetComponentInChildren<Image>().sprite;
    }

    void UpdateContentSize()
    {
        // Get the number of children (menu items)
        int childCount = contentRect.childCount;

        // Get the dimensions of the grid cell
        Vector2 cellSize = gridLayoutGroup.cellSize;

        // Get the spacing between grid cells
        Vector2 spacing = gridLayoutGroup.spacing;

        // Get the number of columns in the grid
        int columns = Mathf.Max(1, Mathf.FloorToInt((contentRect.rect.width + spacing.x) / (cellSize.x + spacing.x)));

        // Calculate the number of rows needed
        int rows = Mathf.CeilToInt((float)childCount / columns);

        // Calculate the new height for the content rect
        float newHeight = rows * cellSize.y + (rows - 1) * spacing.y + gridLayoutGroup.padding.top + gridLayoutGroup.padding.bottom;

        // Update the content rect's size
        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, newHeight);
    }


    public void AddtoPlate()
    {
        if (player.hand.transform.childCount == 0) return;
        Ingredient ingredient =player.hand.GetComponentInChildren<InvItemUI>().ingredient;
        GameObject stobut = Instantiate(storageButtonPrefab, content.transform);
        stobut.GetComponent<StorageButton>().finite = true;
        stobut.GetComponent<StorageButton>().setup(ingredient);
        Destroy(player.hand.transform.GetChild(0).gameObject);
           
    }

    public void giveItemChefManager(Ingredient item)
    {
            giveItem(item);

    }

    public void exit()
    {
        SceneManager.UnloadSceneAsync("Minigame_Assembly");
        endMinigame();
    }
}
