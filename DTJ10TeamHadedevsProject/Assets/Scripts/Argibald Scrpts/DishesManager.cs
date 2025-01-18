using System.Collections.Generic;
using UnityEngine;

public class DishesManager : MonoBehaviour
{
    public List<GameObject> directions;
    float startTime;
    MinigameControls inputActions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time+3;
        foreach (GameObject direction in directions)
        {
            direction.SetActive(false);
        }
    }

    private void OnEnable()
    {
        inputActions = new MinigameControls();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time == startTime)
        {
            sendDirection();
        }
    }

    void sendDirection()
    {
        directions[Random.Range(0, directions.Count)].SetActive(true);
    }
}
