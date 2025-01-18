using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CustomerScript : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    private bool sitting;
    private bool walking;

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
            agent.SetDestination(target.position);
        } else if (sitting)
        {
            target.transform.position = Vector3.zero;
        }
        
    }
}
