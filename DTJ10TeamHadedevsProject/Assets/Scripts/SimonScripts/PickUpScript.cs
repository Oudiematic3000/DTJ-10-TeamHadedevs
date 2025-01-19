using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public Ingredient ingred;
    private string name;
    private Sprite sprite;

    public void Start()
    {
        name = ingred.ingredientName;
        sprite = ingred.sprite;
    }

    public void setup(Ingredient newI)
    {
        ingred = newI;
        name = ingred.ingredientName;
        sprite = ingred.sprite;
    }
}
