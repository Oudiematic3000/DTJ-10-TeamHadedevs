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
    }


    public void startMinigame()
    {
        if (isSelected)
        {
            //start Minigame
        }
    }
}
