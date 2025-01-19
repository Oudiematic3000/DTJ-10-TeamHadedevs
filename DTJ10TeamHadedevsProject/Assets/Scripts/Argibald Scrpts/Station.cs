using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public class Station : MonoBehaviour
{
    public static event Action minigameStarted;
    public Boolean isSelected=false;
    public stationType type;
    public GameObject hand;
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
        isSelected = false;
    }
    public void select()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        isSelected = true;
    }

    public void startMinigame()
    {
        hand = GameObject.Find("Hand");
        InvItemUI heldItem= hand.GetComponentInChildren<InvItemUI>();
        if (isSelected)
        {
            
            switch (type)
            { 

                case stationType.Fish:
                    if (hand.transform.childCount > 0 && heldItem.ingredient.ingredientType == Type.Fillet)
                    {
                        SceneManager.LoadSceneAsync("Minigame_Fish", LoadSceneMode.Additive);
                    }
                    break;
                case stationType.Meat:
                    if(hand.transform.childCount > 0 && heldItem.ingredient.ingredientType== Type.Pan)
                    SceneManager.LoadSceneAsync("Minigame_Meat", LoadSceneMode.Additive);
                    break;
                case stationType.Vegetables:
                    if(hand.transform.childCount > 0 && heldItem.ingredient.ingredientType == Type.Chop)
                    SceneManager.LoadSceneAsync("Minigame_Vegetables", LoadSceneMode.Additive);
                    break;
                case stationType.Prep:
                    SceneManager.LoadSceneAsync("Minigame_Prep", LoadSceneMode.Additive);
                    break;
                case stationType.Storage:
                    SceneManager.LoadSceneAsync("Minigame_Storage", LoadSceneMode.Additive);
                    break;
            }
            minigameStarted();
        }
    }

    public enum stationType
    {
        Fish,
        Meat,
        Vegetables,
        Prep,
        Storage,
        Terminal,
        Customer,
        Bin

    }
}
