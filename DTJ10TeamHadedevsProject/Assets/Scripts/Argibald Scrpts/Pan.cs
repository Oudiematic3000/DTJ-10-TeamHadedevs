using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pan : Minigame
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject meat;
    public Rigidbody2D rb;
    public float maxMeatVelocity;
    public bool cooking;
    public GameObject center;

    public Slider heatGauge;
    public float heat = 0f;
    void Start()
    {
        GameObject.Find("MeatCanvas").GetComponent<Canvas>().worldCamera=Camera.main;
        center.transform.position = GameObject.Find("Player").transform.position;
        meat.transform.position = new Vector3(center.transform.position.x,center.transform.position.y+2,0);
        StartCoroutine(gameTimer());
    }
    private void Update()
    {
        if (cooking)
        {
            heat += 0.2f * Time.deltaTime;
        }
        else
        {
            heat -= 0.04f * Time.deltaTime;
        }
        heatGauge.value = heat;
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
        if(MousePos.y>center.transform.position.y-2)yClamp = center.transform.position.y - 2;
        rb.MovePosition(new Vector3(MousePos.x, yClamp, 0));
    }

    public IEnumerator gameTimer()
    {
        yield return new WaitForSeconds(12f);
        if (heat > 0.35 && heat < 0.65)
        {
            //good cook
            SceneManager.UnloadSceneAsync("Minigame_Meat");
            endMinigame();
        }
        else
        {
            //badcook
            SceneManager.UnloadSceneAsync("Minigame_Meat");
            endMinigame();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        cooking = true;
        Debug.Log(collision.gameObject.name);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        cooking=false;
        Debug.Log(collision.gameObject.name);

    }
}
