using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrderManagerS : MonoBehaviour
{
    public List<TicketClass> tickets = new List<TicketClass>();

    public void addTicket(TicketClass newTicket)
    {
        tickets.Add(newTicket);
    }
}
