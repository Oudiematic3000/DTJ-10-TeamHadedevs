using UnityEngine;
using System;
using UnityEditor.UIElements;
using UnityEngine.AI;
using Unity.VisualScripting;

public class SeatOccupation : MonoBehaviour
{
    public static event Action<GameObject> occupied;
    public static event Action<GameObject> notOccupied;
    private bool satUpon = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!satUpon)
        {
            if (other.CompareTag("Customer"))
            {
                other.transform.SetParent(transform);
                other.transform.localPosition = Vector3.zero;
                other.GetComponent<NavMeshAgent>().enabled = false;
                other.GetComponent<CustomerScript>().enabled = false;
            }
        }
    }

    private void OnTransformChildrenChanged()
    {
        if (transform.childCount == 1)
        {
            occupied(this.gameObject);
            satUpon = true;
        } else if (transform.childCount == 0)
        {
            notOccupied(this.gameObject);
            satUpon = false;
        }
    }
}
