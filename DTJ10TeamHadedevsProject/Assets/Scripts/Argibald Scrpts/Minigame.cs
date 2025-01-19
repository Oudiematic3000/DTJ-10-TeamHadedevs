using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public static event Action endMinigameEvent;
    public static event Action<Ingredient> giveItemEvent;
    void Start()
    {
        
    }
    protected void endMinigame()
    {
        endMinigameEvent();
    }

    protected void giveItem(Ingredient item)
    {
        giveItemEvent(item);
    }
    protected void giveItem(Ingredient[] items)
    {
        foreach (Ingredient item in items)
        {
            giveItemEvent(item);
        }
    }

    protected Ingredient[] goodCook(Ingredient item)
    {
        return item.products;
    }

    protected Ingredient badCook(Ingredient item)
    {
        return item.badPrepProduct;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
