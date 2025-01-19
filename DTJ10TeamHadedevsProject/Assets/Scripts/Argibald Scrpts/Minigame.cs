using System;
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
