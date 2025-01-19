using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;

public class OrderManagerS : MonoBehaviour
{
    public Queue<TicketClass> tickets = new Queue<TicketClass>();
    public TicketClass activeTicket;
    public TextMeshProUGUI ticketText;
    public List<Ingredient> playerDish= new List<Ingredient>();
    public static event Action deathflag;
    private void Start()
    {
        ticketText = GameObject.Find("TicketText").GetComponent<TextMeshProUGUI>();
    }
    public void addTicket(TicketClass newTicket)
    {
        if (tickets.Count == 0)
        {
            tickets.Enqueue(newTicket);
            activeTicket = newTicket;
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

    public void addtoDish(Ingredient ingredient)
    {
        playerDish.Add(ingredient);

    }

    public void validateRecipe()
    {
        foreach(Ingredient i in activeTicket.customerRec.ingredients)
        {
            if (!playerDish.Contains(i) && !playerDish.Contains(i.twin))
            {
                //gameover
                Debug.Log("Gameover");
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
    }
    
    public void killActive()
    {
        if(activeTicket.isTarget) { Debug.Log("win"); }
        else { Debug.Log("Gameover"); }
    }
}
