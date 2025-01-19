using UnityEngine;
using UnityEngine.UI;

public class ToppingButton : MonoBehaviour
{
    public Image image;
    public Ingredient ingredient;
    void Start()
    {
        
    }
    public void setup(Ingredient ingredient)
    {
        this.ingredient = ingredient;
        image.sprite = ingredient.sprite;
    }
    public void addTopping()
    {
        GameObject.FindAnyObjectByType<PrepManager>().spawnTopping(ingredient);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
