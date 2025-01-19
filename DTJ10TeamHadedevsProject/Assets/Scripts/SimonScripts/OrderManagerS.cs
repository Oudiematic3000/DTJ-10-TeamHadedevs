using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class OrderManagerS : MonoBehaviour
{
    public Queue<TicketClass> tickets = new Queue<TicketClass>();
    public TicketClass activeTicket;
    public TextMeshProUGUI ticketText;

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
}
