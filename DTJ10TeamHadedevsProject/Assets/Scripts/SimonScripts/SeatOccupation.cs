using UnityEngine;
using System;
using UnityEngine.AI;
using System.Collections;

public class SeatOccupation : MonoBehaviour
{
    public static event Action<GameObject> occupied;
    public static event Action<GameObject> notOccupied;
    private bool satUpon = false;
    public float waitTime = 2f;

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
                satUpon = true;
                occupied(this.gameObject);
                StartCoroutine(CustomerSitAndLeave(other.gameObject));
            }
        }
    }

    private IEnumerator CustomerSitAndLeave(GameObject customer)
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(waitTime);

        customer.transform.SetParent(null);
        customer.GetComponent<NavMeshAgent>().enabled = true;
        customer.GetComponent<CustomerScript>().sitting = false;
        customer.GetComponent<CustomerScript>().walking = true;
        satUpon = false;
        notOccupied(this.gameObject);
    }
}