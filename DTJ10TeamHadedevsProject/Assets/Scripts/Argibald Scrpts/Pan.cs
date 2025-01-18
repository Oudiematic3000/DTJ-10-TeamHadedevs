using UnityEngine;

public class Pan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject meat;
    public Rigidbody2D rb;
    public float maxMeatVelocity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 currentVel = meat.GetComponent<Rigidbody2D>().linearVelocity;
        if (meat.GetComponent<Rigidbody2D>().linearVelocity.magnitude > 20f)
        {
            meat.GetComponent<Rigidbody2D>().linearVelocity=currentVel.normalized*maxMeatVelocity;
        }
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float yClamp = MousePos.y;
        if(MousePos.y>-2.5)yClamp = -2.5f;
        rb.MovePosition(new Vector3(MousePos.x, yClamp, 0));
    }   
}
