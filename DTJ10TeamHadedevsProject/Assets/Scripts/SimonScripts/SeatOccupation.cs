using UnityEngine;
using System;
using UnityEngine.AI;
using System.Collections;

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
                other.GetComponent<CustomerScript>().sitting = true;
                other.GetComponent<CustomerScript>().walking = false;

                // Start the coroutine to wait for 10 seconds before the customer leaves
                StartCoroutine(CustomerSitAndLeave(other.gameObject));
            }
        }
    }

    private IEnumerator CustomerSitAndLeave(GameObject customer)
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(10f);

        // After 10 seconds, make the customer leave
        customer.transform.SetParent(null); // Remove customer from the chair
        customer.GetComponent<NavMeshAgent>().enabled = true; // Enable NavMeshAgent to allow walking again
        customer.GetComponent<CustomerScript>().sitting = false;
        customer.GetComponent<CustomerScript>().walking = true;

        // Optionally: You can add other logic here for the customer to leave the seat
        satUpon = false; // Set the chair as unoccupied
        notOccupied(this.gameObject); // Trigger the notOccupied event
    }

    private void OnTransformChildrenChanged()
    {
        if (transform.childCount == 1)
        {
            occupied(this.gameObject);
            satUpon = true;
        }
        else if (transform.childCount == 0)
        {
            notOccupied(this.gameObject);
            satUpon = false;
        }
    }
}

