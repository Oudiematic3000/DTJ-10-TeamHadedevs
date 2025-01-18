using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

public class SeatAssigning : MonoBehaviour
{
    public List<GameObject> seatList;

    private void Start()
    {

        // Find all GameObjects with the specified tag and populate the list
        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Seats");

        // Add found objects to the list
        seatList.AddRange(foundObjects);

        // Optional: Print out the names of the objects with the tag
        foreach (var obj in seatList)
        {
            Debug.Log(obj.name);
        }
    }

    private void Awake()
    {
        SeatOccupation.occupied += removeSeat;
        SeatOccupation.notOccupied += addSeat;

    }

    private void removeSeat(GameObject seatToRemove)
    {
        seatList.Remove(seatToRemove);
    }

    private void addSeat(GameObject seatToAdd)
    {
        seatList.Add(seatToAdd);
    }
}
