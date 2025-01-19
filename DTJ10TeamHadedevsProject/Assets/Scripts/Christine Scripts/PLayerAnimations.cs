using UnityEngine;

public class PLayerAnimations : MonoBehaviour
{
    private float lastY;
    private float lastX;

    public Animator anim;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.linearVelocity == new Vector2 (0,0))
        {
            anim.SetBool("moving", false);
        }

        if (lastY < this.gameObject.transform.position.y)
        {
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", 1);
            anim.SetBool("moving", true);
        }
        else if (lastY > this.gameObject.transform.position.y)
        {
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", -1);
            anim.SetBool("moving", true);
        }

        lastY = this.gameObject.transform.position.y;

        if (lastX < this.gameObject.transform.position.x)
        {
            anim.SetFloat("moveX", 1);
            anim.SetFloat("moveY", 0);
            anim.SetBool("moving", true);
        }
        else if (lastX > this.gameObject.transform.position.x)
        {
            anim.SetFloat("moveX", -1);
            anim.SetFloat("moveY", 0);
            anim.SetBool("moving", true);
        }

        lastX = this.gameObject.transform.position.x;

        
    }
}
