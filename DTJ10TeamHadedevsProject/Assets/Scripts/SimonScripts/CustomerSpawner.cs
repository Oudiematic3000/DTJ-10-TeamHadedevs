using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] GameObject manager;
    [SerializeField] GameObject customerTargetPrefab;
    [SerializeField] GameObject customerPrefab;
    [SerializeField] GameObject targetPrefab;
    [SerializeField] float waitTime;
    public GameObject currentOpenSeat;
    public GameObject seatOfTarget;

    private int customerCount = 1;
    private int targetNumber;
    public int numberOfSpawns = 8;
    public bool targetSpawned = false;

    void Start()
    {
        if (manager != null)
        {
            targetNumber = Random.Range(4, 8);
            StartCoroutine(WaitToSpawn());
        }
        else
        {
            Debug.LogError("Manager is not assigned!");
        }
    }

    private IEnumerator WaitToSpawn()
    {
        yield return new WaitForSeconds(waitTime);

        if (customerCount == targetNumber)
        {
            currentOpenSeat = manager.GetComponent<SeatAssigning>().sendFirstOpenSeat();
            currentOpenSeat.GetComponent<SeatOccupation>().invokeTaken();
            GameObject customerInstance = Instantiate(customerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
            GameObject customerTargetInstance = Instantiate(customerTargetPrefab, currentOpenSeat.transform.position, Quaternion.identity);
            customerInstance.GetComponent<CustomerScript>().isTarget = true;
            customerInstance.name = "Customer" + customerCount;
            customerTargetInstance.name = "CustomerTarget" + customerCount;
            customerInstance.GetComponent<CustomerScript>().target = customerTargetInstance;
            customerInstance.GetComponent<CustomerScript>().seatNum = currentOpenSeat.GetComponent<SeatOccupation>().seatNum;
            currentOpenSeat.GetComponent<SeatOccupation>().assignedCustomer = customerInstance.name;
            customerCount++;
            targetSpawned = true;
            seatOfTarget = currentOpenSeat;

            /*currentOpenSeat = manager.GetComponent<SeatAssigning>().sendFirstOpenSeat();
            currentOpenSeat.GetComponent<SeatOccupation>().invokeTaken();
            GameObject targetInstance = Instantiate(targetPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject customerTargetInstance = Instantiate(customerTargetPrefab, currentOpenSeat.transform.position, Quaternion.identity);
            targetInstance.name = "target" + targetNumber;
            customerTargetInstance.name = "targetTarget" + targetNumber;
            targetInstance.GetComponent<CustomerScript>().target = customerTargetInstance;
            currentOpenSeat.GetComponent<SeatOccupation>().assignedCustomer = targetInstance.name;
            customerCount++;*/

        } else {
            currentOpenSeat = manager.GetComponent<SeatAssigning>().sendFirstOpenSeat();
            currentOpenSeat.GetComponent<SeatOccupation>().invokeTaken();
            GameObject customerInstance = Instantiate(customerPrefab, new Vector3(0, 5, 0), Quaternion.identity);
            GameObject customerTargetInstance = Instantiate(customerTargetPrefab, currentOpenSeat.transform.position, Quaternion.identity);
            customerInstance.name = "Customer" + customerCount;
            customerTargetInstance.name = "CustomerTarget" + customerCount;
            customerInstance.GetComponent<CustomerScript>().target = customerTargetInstance;
            customerInstance.GetComponent<CustomerScript>().seatNum = currentOpenSeat.GetComponent<SeatOccupation>().seatNum;
            currentOpenSeat.GetComponent<SeatOccupation>().assignedCustomer = customerInstance.name;
            customerCount++;
        }
        if (customerCount <= numberOfSpawns)
        {
            StartCoroutine(WaitToSpawn());
        }
    }
}