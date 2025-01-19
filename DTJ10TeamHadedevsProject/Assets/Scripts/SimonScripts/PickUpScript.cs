using UnityEngine;
using System;

public class PickUpScript : MonoBehaviour
{
    public Ingredient ingred;
    private string name;
    private Sprite sprite;
    public static Action<Ingredient> giveItem;

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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            giveItem(ingred);
            Destroy(this.gameObject);
        }
    }
}
