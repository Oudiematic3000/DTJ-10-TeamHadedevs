using UnityEngine;
using UnityEngine.UI;

public class InvItemUI : MonoBehaviour
{
    public Ingredient ingredient;
    public Image image;

    void Start()
    {
        
    }

    public void setup(Ingredient item)
    {
        ingredient=item;
        gameObject.name=ingredient.ingredientName;
        image.sprite=ingredient.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
