using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string[] scenes;
    
    void Start()
    {
        foreach (string scene in scenes)
        {
            SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
