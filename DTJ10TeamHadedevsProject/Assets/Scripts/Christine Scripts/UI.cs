using UnityEngine;

public class UI : MonoBehaviour
{
    public bool paused;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
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
}
