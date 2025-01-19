using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class CustomerScript : MonoBehaviour
{
    [SerializeField] public List<string> allergies;
    [SerializeField] public GameObject target;

    public Recipe[] recipes;

    public GameObject orderManager;

    NavMeshAgent agent;

    public bool sitting;
    public bool walking;
    public bool isTarget = false;
    public int seatNum;
    private bool ticketCreated = false;
    private string allergyToSend;

    void Start()
    {
        recipes = new Recipe[20];
        walking = true;
        sitting = false;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        orderManager = GameObject.Find("OrderManage");

        if (orderManager == null)
        {
            Debug.LogError("OrderManager not found in the scene!");
            return;
        }

        OrderManagerS orderManagerScript = orderManager.GetComponent<OrderManagerS>();
        if (orderManagerScript == null)
        {
            Debug.LogError("OrderManagerS component not found on OrderManager!");
            return;
        }

        recipes = Resources.LoadAll<Recipe>("Recipes");
    }

    void Update()
    {
        if (walking)
        {
            agent.SetDestination(target.transform.position);
        }
        else if (sitting)
        {
            target.transform.position = new Vector3(-3f, -4.5f, 0f);
            target.gameObject.SetActive(false);

            if (!ticketCreated)
            {
                OrderManagerS orderManagerScript = orderManager.GetComponent<OrderManagerS>();
                if (orderManagerScript != null)
                {
                    if (Random.Range(1,4) == 3)
                    {
                        int choice = Random.Range(0, allergies.Count);
                        Debug.Log(choice);
                        allergyToSend = allergies[choice];
                    } else {
                        allergyToSend = "None";
                    }
                    
                    orderManagerScript.addTicket(new TicketClass(recipes[Random.Range(0, recipes.Length)], allergyToSend, seatNum));
                    ticketCreated = true;
                }
            }
        }

        if (this.transform.position == new Vector3(-3f, -4.5f, 0f))
        {
            Destroy(this.gameObject);
        }
    }
}
