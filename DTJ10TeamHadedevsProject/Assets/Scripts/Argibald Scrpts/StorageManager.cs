using System.Collections.Generic;
using UnityEngine;

public class StorageManager : Minigame
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Ingredient[] stock;
    public GameObject storageButtonPrefab;
    public GameObject content;
    void Start()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player.isChef)
        {
            chefPopulate();
        }
        else
        {
           // managerPopulate();
        }
    }

 
    public void chefPopulate()
    {
      stock= Resources.LoadAll<Ingredient>("Ingredients");
        foreach (Ingredient item in stock)
        {
          GameObject stobut=  Instantiate(storageButtonPrefab, content.transform);
            stobut.GetComponent<StorageButton>().setup(item);
        }

    }
}
