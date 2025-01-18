using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Objects/Ingredient")]
public class Ingredient : ScriptableObject
{
    public string ingredientName;
    public Type ingredientType;
    public Sprite rawSprite, cookedSprite;
}
public enum Type
{
    Pan,
    Pot,
    Chop
}
