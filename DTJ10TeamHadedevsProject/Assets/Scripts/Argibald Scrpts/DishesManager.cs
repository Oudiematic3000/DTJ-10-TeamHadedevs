using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DishesManager : Minigame
{
    public List<GameObject> directions;
    float startTime;
    string currentDirection;
    MinigameControls inputActions;
    Boolean started=false;
    int moveCounter = 0;
    int cleanCounter = 0;
    int dirtyCounter = 3;
    public TextMeshProUGUI dirtyCounterText;
    public TextMeshProUGUI cleanCounterText;
    public InvItemUI heldItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        heldItem = GameObject.Find("Hand").GetComponentInChildren<InvItemUI>();
        foreach (GameObject direction in directions)
        {
            direction.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        inputActions.MinigameUIControls.Disable();
    }

    private void OnEnable()
    {
        inputActions = new MinigameControls();

       inputActions.MinigameUIControls.Enable();

        inputActions.MinigameUIControls.Up.performed += ctx => checkInput("Up");
        inputActions.MinigameUIControls.Down.performed += ctx => checkInput("Down");
        inputActions.MinigameUIControls.Left.performed += ctx => checkInput("Left");
        inputActions.MinigameUIControls.Right.performed += ctx => checkInput("Right");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            sendDirection();
            started=true;
        }
    }

    void sendDirection()
    {
        foreach (GameObject direction in directions)
        {
            direction.SetActive(false);
        }
       GameObject directionObject = directions[UnityEngine.Random.Range(0, directions.Count)];
        directionObject.SetActive(true);
        currentDirection=directionObject.name;
    }

    void checkInput(string input)
    {

        if(input==currentDirection)
        {
            moveCounter++;
            if (moveCounter==5)
            {
                cleanCounter++;
                dirtyCounter--;
                dirtyCounterText.text= dirtyCounter.ToString();
                cleanCounterText.text = cleanCounter.ToString();
                moveCounter = 0;
                if(cleanCounter==3)
                {
                    StartCoroutine(wait());
                    
                }
            }
            sendDirection();
            
        }
    }
    public IEnumerator wait()
    {
        Ingredient temp = heldItem.ingredient;
        Destroy(heldItem.gameObject);
        yield return null;
        giveItem(goodCook(temp));
        endMinigame();
        SceneManager.UnloadSceneAsync("Minigame_Vegetables");
    }
}
