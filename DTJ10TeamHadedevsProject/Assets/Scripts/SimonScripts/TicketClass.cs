using UnityEngine;
[System.Serializable]

public class TicketClass
{
    public Recipe customerRec;
    public string allergy;
    public int seatNum;

    public TicketClass(Recipe rec, string all, int seat)
    {
        customerRec = rec;
        allergy = all;
        seatNum = seat;
    }
}