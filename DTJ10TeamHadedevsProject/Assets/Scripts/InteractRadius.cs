using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractRadius : MonoBehaviour
{
    public static event Action deSelect;
    public List<Station> stions = new List<Station>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Station newStat;
        if (!collision.CompareTag("Station"))
        {
            return;
        }
        else
        {
            newStat = collision.gameObject.GetComponent<Station>();
        }

        if (!stions.Contains(newStat))
        {
            stions.Add(newStat);
        }
        deSelect();
        newStat.select();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Station newStat;
        if (!collision.CompareTag("Station"))
        {
            return;
        }
        else
        {
            newStat = collision.gameObject.GetComponent<Station>();
        }
        if(stions.Contains(newStat))
        {
            stions.Remove(newStat);
        }
    }
}
