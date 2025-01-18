using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageButton : MonoBehaviour
{
    public Ingredient ingredient;
    public TextMeshProUGUI ingredientName;
    public Image image;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setup(Ingredient item)
    {
        ingredient = item;
        ingredientName.text = ingredient.ingredientName;
        image.sprite=ingredient.rawSprite;
    }

    void giveIngredient()
    {
        //todo
    }
}
