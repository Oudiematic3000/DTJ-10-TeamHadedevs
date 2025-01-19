using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class OrderManagerS : MonoBehaviour
{
    public Queue<TicketClass> tickets = new Queue<TicketClass>();
    public TicketClass activeTicket;
    public TextMeshProUGUI ticketText;
    public List<Ingredient> playerDish= new List<Ingredient>();
    public static event Action<TicketClass> ticketMade;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private void Start()
    {
        ticketText = GameObject.Find("TicketText").GetComponent<TextMeshProUGUI>();
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }
    private void Awake()
    {
        PrepManager.SendToppings += addtoDish;
        PrepManager.validateDish += validateRecipe;
        AssemblyManager.sendIngredients += addtoDish;
    }

    public void addTicket(TicketClass newTicket)
    {
        if (tickets.Count == 0)
        {
            tickets.Enqueue(newTicket);
            activeTicket = newTicket;
            ticketMade(activeTicket);
        }
        else
        {
            tickets.Enqueue(newTicket);
        }
        ticketText.text = display();
    }

    public void removeTicket()
    {
        tickets.Dequeue();
        activeTicket=tickets.Peek();
        ticketText.text = display();
    }

    public string display()
    {
        string output = "<b>Seat "+activeTicket.seatNum+":</b>\n"+activeTicket.customerRec.display()+"\n\nNotes:\n "+activeTicket.allergy+" allergy.";
        return output;
    }

    public void addtoDish(List<Ingredient> ingredients)
    {
       foreach(Ingredient i in ingredients) { 
        playerDish.Add(i);
        }

    }

    public void validateRecipe()
    {
        foreach(Ingredient i in activeTicket.customerRec.ingredients)
        {
            if (!playerDish.Contains(i) && !playerDish.Contains(i.twin))
            {
                //gameover
                Debug.Log("Gameover");
                losePanel.SetActive(true);
                return;
            }
        }
        foreach(Ingredient i in playerDish)
        {
            if (i.toxic)
            {

                killActive();
                return;
            }
        }
        foreach(Ingredient i in playerDish)
        {
            if (activeTicket.allergy==i.allergen)
            {

                killActive();
                return;
            }
        }
        removeTicket();
    }
    
    public void killActive()
    {
        if(activeTicket.isTarget) { Debug.Log("win"); winPanel.SetActive(true); }
        else { Debug.Log("Gameover"); losePanel.SetActive(true); }
    }

    public void Reset()
    {
        SceneManager.LoadScene("RestaurantA");
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);
    }
}
