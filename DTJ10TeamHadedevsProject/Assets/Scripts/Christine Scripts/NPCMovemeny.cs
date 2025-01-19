using UnityEngine;

public class NPCMovemeny : MonoBehaviour
{
    private float lastY;
    private float lastX;

    public Animator anim;

    private CustomerScript customerScript;

    private void Start()
    {
        lastY = this.gameObject.transform.position.y;
        lastX = this.gameObject.transform.position.x;

        customerScript = GetComponent<CustomerScript>();
    }

    private void Update()
    {
        if (lastY < this.gameObject.transform.position.y)
        {
            Debug.Log("y-Increase");
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", 1);
            anim.SetBool("moving", true);
        }
        else if (lastY > this.gameObject.transform.position.y)
        {
            Debug.Log("y-decrease");
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", -1);
            anim.SetBool("moving", true);
        }

        lastY = this.gameObject.transform.position.y;

        if (lastX < this.gameObject.transform.position.x)
        {
            Debug.Log("x-Increase");
            anim.SetFloat("moveX", 1);
            anim.SetFloat("moveY", 0);
            anim.SetBool("moving", true);
        }
        else if (lastX > this.gameObject.transform.position.x)
        {
            Debug.Log("x-decrease");
            anim.SetFloat("moveX", -1);
            anim.SetFloat("moveY", 0);
            anim.SetBool("moving", true);
        }

        lastX = this.gameObject.transform.position.x;

        if (customerScript.sitting == true)
        {
            anim.SetBool("moving", false);
        }
    }
}
