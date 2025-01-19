using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Scriptable Objects/Ingredient")]
public class Ingredient : ScriptableObject
{
    public string ingredientName;
    public Type ingredientType;
    public Sprite sprite;
    public bool toxic, raw;
    public Ingredient[] products;
    public Ingredient badPrepProduct;
    public Ingredient twin;
    public string allergen;
}
    public enum Type
    {
        Pan,
        Fillet,
        Chop,
        Top,
        Biproduct
    }
