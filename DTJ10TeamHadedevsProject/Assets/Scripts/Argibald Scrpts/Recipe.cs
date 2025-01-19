using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Scriptable Objects/Recipe")]
public class Recipe : ScriptableObject
{
    public List<Ingredient> ingredients;
    List<string> allergens;
    public string allergenRequest;

    public void findAllergens()
    {
        foreach(Ingredient ingredient in ingredients)
        {
            if( ingredient.allergen!=null )
            allergens.Add(ingredient.allergen);
        }
        if( allergens!=null)
        {
            allergenRequest = "Notes:";
            foreach(string g in allergens)
            {
                allergenRequest += "\n"+g+" allergy";
            }
        }
    }
}
