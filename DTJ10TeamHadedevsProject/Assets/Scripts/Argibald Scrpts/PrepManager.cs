using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PrepManager : Minigame
{
    public GameObject toppingButtonPrefab, toppingPrefab;
    public GameObject center,spawner;
    public List<Ingredient> addedToppings = new List<Ingredient>();
    public static event Action<List<Ingredient>> SendToppings;
    void Start()
    {
        GameObject.Find("PrepCanvas").GetComponent<Canvas>().worldCamera = Camera.main;
        center.transform.position = GameObject.Find("Player").transform.position;
        Ingredient[] tops = Resources.LoadAll<Ingredient>("Ingredients");
        int slotsCount = 0;
        foreach (var to in tops)
        {
            if (to.ingredientType == Type.Top)
            {
                ToppingButton spawnItem = Instantiate(toppingButtonPrefab, GameObject.Find("ToppingsHolder").transform).GetComponent<ToppingButton>();
                spawnItem.setup(to);
                slotsCount++;
            }
        }
    }

    public void spawnTopping(Ingredient item)
    {
        ToppingPrefab spawnItem= Instantiate(toppingPrefab,new Vector3(UnityEngine.Random.Range(center.transform.position.x-1, center.transform.position.x+1),center.transform.position.y+3,0), Quaternion.identity, spawner.transform).GetComponent<ToppingPrefab>();
        spawnItem.setup(item);
        addedToppings.Add(spawnItem.ingredient);
    }

    public void clearToppings()
    {
        addedToppings.Clear();
        foreach(Transform t in spawner.transform)
        {
            if(t.GetComponent<ToppingPrefab>() != null)
            Destroy(t.gameObject);
        }
    }

    public void finish()
    {
        SendToppings(addedToppings);
        endMinigame();
        SceneManager.UnloadSceneAsync("Minigame_Prep");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
