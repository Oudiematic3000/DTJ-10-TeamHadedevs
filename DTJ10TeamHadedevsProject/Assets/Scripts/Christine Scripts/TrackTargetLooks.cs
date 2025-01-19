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

        switch (targetEyes)
        {
            case 0:
                targetEyesText = "Green Eyes";
                break;

            case 1:
                targetEyesText = "Brown Eyes";
                break;

            case 2:
                targetEyesText = "Blue Eyes";
                break;
        }

        switch (targetHair)
        {
            case 0:
                targetHairText = "Short Black Hair";
                break;

            case 1:
                targetHairText = "Long Black Hair";
                break;

            case 2:
                targetHairText = "Short Blonde Hair";
                break;

            case 3:
                targetHairText = "Long Blonde Hair";
                break;

            case 4:
                targetHairText = "Short Brown Hair";
                break;

            case 5:
                targetHairText = "Long Brown Hair";
                break;

            case 6:
                targetHairText = "Short Green Hair";
                break;

            case 7:
                targetHairText = "Long Green Hair";
                break;

            case 8:
                targetHairText = "Short Pink Hair";
                break;

            case 9:
                targetHairText = "Long Pink Hair";
                break;
        }

        switch (targetShirt)
        {
            case 0:
                targetShirtText = "Red Shirt";
                break;

            case 1:
                targetShirtText = "Yellow Shirt";
                break;

            case 2:
                targetShirtText = "Purple Shirt";
                break;

            case 3:
                targetShirtText = "Green Shirt";
                break;

            case 4:
                targetShirtText = "Blue Shirt";
                break;
        }

        switch (targetSkin)
        {
            case 0:
                targetSkinText = "Light Toned Skin";
                break;

            case 1:
                targetSkinText = "Mid Toned Skin";
                break;

            case 2:
                targetSkinText = "Dark Toned Skin";
                break;
        }
    }


}
