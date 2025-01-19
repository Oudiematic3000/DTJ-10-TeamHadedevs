using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class SeatAssigning : MonoBehaviour
{
    public List<GameObject> seatList;

    private void Start()
    {
        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Seats");
        seatList.AddRange(foundObjects);
    }

    private void Awake()
    {
        SeatOccupation.taken += removeSeat;
        SeatOccupation.notTaken += addSeat;
    }

    private void removeSeat(GameObject seatToRemove)
    {
        seatList.Remove(seatToRemove);
    }

    private void addSeat(GameObject seatToAdd)
    {
        seatList.Add(seatToAdd);
    }

    public GameObject sendFirstOpenSeat()
    {
        return seatList[0];
    }
}
