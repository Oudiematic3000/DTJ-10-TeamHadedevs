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
        if (isSelected)
        {
            
            switch (type)
            {
                case stationType.Sink:
                    SceneManager.LoadSceneAsync("Minigame_Dishes", LoadSceneMode.Additive);
                    break;
                case stationType.Fish:
                    SceneManager.LoadSceneAsync("Minigame_Fish", LoadSceneMode.Additive);
                    break;
                case stationType.Meat:
                    SceneManager.LoadSceneAsync("Minigame_Meat", LoadSceneMode.Additive);
                    break;
                case stationType.Vegetables:
                    SceneManager.LoadSceneAsync("Minigame_Vegetables", LoadSceneMode.Additive);
                    break;
                case stationType.Prep:
                    SceneManager.LoadSceneAsync("Minigame_Prep", LoadSceneMode.Additive);
                    break;
            }
            minigameStarted();
        }
    }

    public enum stationType
    {
        Sink,
        Fish,
        Meat,
        Vegetables,
        Prep

    }
}
