using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
public class Station : MonoBehaviour
{
    //Onselectevent
    public Boolean isSelected=false;

    public void Awake()
    {
        //highlight onselect
        Player.onInteract += startMinigame;
        InteractRadius.deSelect += deselect;
    }

    public void OnDestroy()
    {
        Player.onInteract -= startMinigame;
    }
        
    public void deselect()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void select()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    public void startMinigame()
    {
        if (isSelected)
        {
            //start Minigame
        }
    }
}
