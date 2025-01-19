using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FishManager : Minigame
{
    public Slider slider;
    public bool stopped = false;
    public int chopCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped)
        {
            float time = Time.time * 1f;
            slider.value = Mathf.Abs(Mathf.Sin(time));
        }
    }

    public void stopSlide()
    {
        
            if (slider.value > 0.45 && slider.value < 0.55)
            {
                chopCount++;
            }
            if (chopCount == 3)
            {
                SceneManager.UnloadSceneAsync("Minigame_Fish");
                endMinigame();
            }
        
    }
    IEnumerator stopWait()
    {
        stopped = true;
        yield return new WaitForSeconds(2f);
        stopped = false;
    }
}
