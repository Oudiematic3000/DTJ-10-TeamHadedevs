using UnityEngine;
[System.Serializable]

public class TicketClass
{
    public Recipe customerRec;
    public string allergy;
    public int seatNum;
    public bool isTarget;
    public TicketClass(Recipe rec, string all, int seat, bool isTarget)
    {
        customerRec = rec;
        allergy = all;
        seatNum = seat;
        this.isTarget = isTarget;
    }
}