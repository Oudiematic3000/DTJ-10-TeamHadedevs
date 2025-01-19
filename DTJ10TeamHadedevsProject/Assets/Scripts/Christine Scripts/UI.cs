using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public bool paused;
    public bool book;
    public GameObject pauseMenu;
    public GameObject poisonBook;
    public TrackTargetLooks trackTarget;
    public TextMeshProUGUI targetText;

    private void Start()
    {
        trackTarget = GameObject.Find("CustomerSpawner").GetComponent<TrackTargetLooks>();
        targetText.text = "The target has a " + trackTarget.targetSkinText + ", " + trackTarget.targetEyesText + ", " + trackTarget.targetHairText + " and a " + trackTarget.targetShirtText + ".";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Book();
        }
    }

    private void PauseGame()
    {
        if (paused == false)
        {
            pauseMenu.SetActive(true);
            paused = true;
        }
        else if (paused == true)
        {
            pauseMenu.SetActive(false);
            paused = false;
        }
    }

    private void Book()
    {
        if (book == false)
        {
            poisonBook.SetActive(true);
            book = true;
        }
        else if (book == true)
        {
            poisonBook.SetActive(false);
            book = false;
        }
    }
}
