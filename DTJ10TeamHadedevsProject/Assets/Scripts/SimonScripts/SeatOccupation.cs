using UnityEngine;
using System;
using UnityEngine.AI;
using System.Collections;


public class SeatOccupation : MonoBehaviour
{
    public static event Action<GameObject> taken;
    public static event Action<GameObject> notTaken;
    public String assignedCustomer;
    [SerializeField] public float waitTime = 10f;


    private IEnumerator CustomerSitAndLeave(GameObject customer)
    {
        yield return new WaitForSeconds(waitTime);
        customer.transform.SetParent(null);
        customer.GetComponent<NavMeshAgent>().enabled = true;
        customer.GetComponent<CustomerScript>().sitting = false;
        customer.GetComponent<CustomerScript>().walking = true;
        notTaken(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Customer") && other.gameObject.name == assignedCustomer)
        {
            other.transform.SetParent(transform);
            other.transform.localPosition = Vector3.zero;
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.GetComponent<CustomerScript>().sitting = true;
            other.GetComponent<CustomerScript>().walking = false;
            StartCoroutine(CustomerSitAndLeave(other.gameObject));
        }
    }

    public void invokeTaken()
    {
        taken(this.gameObject);
    }
}