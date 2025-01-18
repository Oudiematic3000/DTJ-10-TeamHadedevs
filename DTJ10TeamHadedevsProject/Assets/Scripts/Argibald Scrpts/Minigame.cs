using System;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public static event Action endMinigameEvent;    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    protected void endMinigame()
    {
        endMinigameEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
