using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{


    [Header("MOVEMENT SETTINGS")]
    [Space(5)]
    // Public variables to set movement and look speed, and the player camera
    public float moveSpeed; // Speed at which the player moves
    public Transform playerCamera; // Reference to the player's camera
    // Private variables to store input values and the character controller
    private Vector2 moveInput; // Stores the movement input from the player
    private Vector2 lastMove;
    private Vector2 lookInput; // Stores the look input from the player
    private Vector3 velocity; // Velocity of the player
    private Rigidbody2D characterController; // Reference to the CharacterController component

    public bool isChef = true;

    public static Player instance;
    Controls playerInput;
    public Animator animator;
    public PlayerInput inputController;
    public static event Action onInteract;
    public GameObject hand, pocket, invItemUIPrefab, ticket;
    public TextMeshProUGUI description;


    private void Awake()
    {

        characterController = GetComponent<Rigidbody2D>();
        Station.minigameStarted += disable;
        Minigame.endMinigameEvent += reEnable;
        Minigame.giveItemEvent += addItem;
        PickUpScript.giveItem += addItem;
    }

    private void OnEnable()
    {
        // Create a new instance of the input actions
        playerInput = new Controls();

        // Enable the input actions
        playerInput.PlayerControls.Enable();

        // Subscribe to the movement input events
        playerInput.PlayerControls.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>(); // Update moveInput when movement input is performed
        playerInput.PlayerControls.Movement.performed += ctx => lastMove = ctx.ReadValue<Vector2>(); // Update moveInput when movement input is performed
        playerInput.PlayerControls.Movement.canceled += ctx => moveInput = Vector2.zero; // Reset moveInput when movement input is canceled

        playerInput.PlayerControls.Interact.performed += ctx => onInteract();
        playerInput.PlayerControls.Swap.performed += ctx => swapHand();
        playerInput.PlayerControls.OpenTicket.performed += ctx => openTicket();



        // Subscribe to the jump input event




    }

    public void reEnable()
    {
        playerInput.PlayerControls.Enable();
    }
    public void disable()
    {
        playerInput.PlayerControls.Disable();
    }

    private void Update()
    {

        
        


    }
    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {

        float currentSpeed;
        currentSpeed = moveSpeed;
       
        // Create a movement vector based on the input
        Vector2 move;
        move = new Vector2(moveInput.x, moveInput.y);
         // Move the character controller based on the movement vector and speed
        characterController.linearVelocity = (move * currentSpeed);

        
    }

    public void addItem(Ingredient item)
    {
        
        if(hand.transform.childCount == 0)
        {
          GameObject spawnItem =  Instantiate(invItemUIPrefab, hand.transform);
            spawnItem.GetComponent<InvItemUI>().setup(item);
        }
        else if(pocket.transform.childCount == 0)
        {
            GameObject spawnItem = Instantiate(invItemUIPrefab, pocket.transform);
            spawnItem.GetComponent<InvItemUI>().setup(item);
        }
        else
        {
          Destroy(pocket.transform.GetChild(0).gameObject);
            GameObject spawnItem = Instantiate(invItemUIPrefab, pocket.transform);
            spawnItem.GetComponent<InvItemUI>().setup(item);
        }
        description.text = hand.transform.GetChild(0).name;
    }

    public void swapHand()
    {
        if (hand.transform.childCount > 0 && pocket.transform.childCount > 0)
        {
            Ingredient temp = hand.GetComponentInChildren<InvItemUI>().ingredient;
            hand.GetComponentInChildren<InvItemUI>().setup(pocket.GetComponentInChildren<InvItemUI>().ingredient);
            pocket.GetComponentInChildren<InvItemUI>().setup(temp);
            description.text = hand.transform.GetChild(0).name;
        }else if(hand.transform.childCount == 0 && pocket.transform.childCount > 0)
        {
            addItem(pocket.GetComponentInChildren<InvItemUI>().ingredient);
            Destroy(pocket.transform.GetChild(0).gameObject);
        }else if( pocket.transform.childCount == 0 && hand.transform.childCount > 0)
        {
            addItem(hand.GetComponentInChildren<InvItemUI>().ingredient);
            Destroy(hand.transform.GetChild(0).gameObject);
        }
    }

    public void openTicket()
    {
        if(ticket.transform.localScale==Vector3.one)ticket.transform.localScale = Vector3.zero;
        else ticket.transform.localScale = Vector3.one;
    }

}

