using UnityEngine;

public class ToppingPrefab : MonoBehaviour
{
    public Ingredient ingredient;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        
    }
    public void setup(Ingredient item)
    {
        ingredient = item;
        spriteRenderer.sprite=ingredient.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
