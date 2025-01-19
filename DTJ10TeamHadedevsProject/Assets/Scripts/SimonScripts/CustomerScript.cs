using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class CustomerScript : MonoBehaviour
{
    /*
    Possible allergens:
    Wheat
    Cashew
    Peanut
    Hazelnut
    Dairy
    Salt
    Sesame Seeds
    */

    /*
    Recipes:
    
    */

    [SerializeField] public List<string> allergies;

    [SerializeField] public GameObject target;
    NavMeshAgent agent;
    public bool sitting;
    public bool walking;
    public bool isTarget = false;
    public int seatNum;

    void Start()
    {
        walking = true;
        sitting = false;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (walking)
        {
            agent.SetDestination(target.transform.position);
        } else if (sitting)
        {
            target.transform.position = new Vector3(-3f, -4.5f, 0f);
            target.gameObject.SetActive(false);
        }

        if (this.transform.position == new Vector3(-3f, -4.5f, 0f))
        {
            Destroy(this.gameObject);
        }
    }
}
