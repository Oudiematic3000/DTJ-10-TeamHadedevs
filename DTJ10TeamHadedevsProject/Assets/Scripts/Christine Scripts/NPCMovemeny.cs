using UnityEngine;

public class NPCMovemeny : MonoBehaviour
{
    private float lastY;
    private float lastX;

    public Animator anim;

    private CustomerScript customerScript;
    private TrackTargetLooks trackTarget;

    [SerializeField]
    private NPCEyes eyes;
    [SerializeField]
    private NPCHair hair;
    [SerializeField]
    private NPCSkin skin;
    [SerializeField]
    private NPCShirts shirts;


    private void Start()
    {
        lastY = this.gameObject.transform.position.y;
        lastX = this.gameObject.transform.position.x;

        customerScript = GetComponent<CustomerScript>();
        trackTarget = GameObject.Find("CustomerSpawner").GetComponent<TrackTargetLooks>();

        if (customerScript.isTarget == true)
        {
            eyes.eyeNum = trackTarget.targetEyes;
            hair.hairNum = trackTarget.targetHair;
            skin.skinNum = trackTarget.targetSkin;
            shirts.shirtNum = trackTarget.targetShirt;

            Debug.Log(eyes.eyeNum);
            Debug.Log(hair.hairNum);
            Debug.Log(skin.skinNum);
            Debug.Log(shirts.shirtNum);

        }
        else
        {
            eyes.eyeNum = Random.Range(0, 2);
            hair.hairNum = Random.Range(0, 9);
            skin.skinNum = Random.Range(0, 2);
            shirts.shirtNum = Random.Range(0, 4);
        }
    }

    private void Update()
    {
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

        if (customerScript.sitting == true)
        {
            anim.SetBool("moving", false);
        }
    }
}
