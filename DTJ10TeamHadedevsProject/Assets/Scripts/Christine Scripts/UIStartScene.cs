using UnityEngine;

public class UIStartScene : MonoBehaviour
{
    public bool img1;
    public bool img2;
    public bool img3;
    public bool img4;

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (img1 == true)
            {
                image1.SetActive(false);
                img1 = false;
            }
            else if (img2 == true)
            {
                image2.SetActive(false);
                img2 = false;
            }
            else if (img3 == true)
            {
                image3.SetActive(false);
                img3 = false;
            }
            else if (img4 == true)
            {
                //Change to game scene
            }
        }
    }
}
