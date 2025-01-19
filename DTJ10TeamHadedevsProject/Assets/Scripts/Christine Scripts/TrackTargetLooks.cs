using UnityEngine;

public class TrackTargetLooks : MonoBehaviour
{
    public int targetEyes;
    public int targetHair;
    public int targetShirt;
    public int targetSkin;

    public string targetEyesText;
    public string targetHairText;
    public string targetShirtText;
    public string targetSkinText;

    private void Start()
    {
        targetEyes = Random.Range(0, 2);
        targetHair = Random.Range(0, 9);
        targetShirt = Random.Range(0, 4);
        targetSkin = Random.Range(0, 2);
    }
}
