using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    public static GameplayManager gameplayManager;
    public List<GameObject> objectives;
    public List<GameObject> lights;

    public GameObject mainLight1;
    public GameObject mainLight2;
    public GameObject mainLight3;
    public int repairedObjectives = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject game in lights)
        {
            game.GetComponent<LightFlicker>().enabled = false;
            game.transform.GetChild(0).gameObject.SetActive(false);
            //game.transform.GetChild(0).gameObject.SetActive(false)
        }
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Window");
        foreach (GameObject test in temp)
        {
            if (!test.GetComponent<Objectives>().repaired) objectives.Add(test);
        }

        temp = GameObject.FindGameObjectsWithTag("Lightswitch");
        foreach (GameObject test in temp)
        {
            if (!test.GetComponent<Objectives>().repaired) objectives.Add(test);
        }
        temp = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject test in temp)
        {
            if (!test.GetComponent<Objectives>().repaired) objectives.Add(test);
        }

        Debug.Log(objectives.Count);

        //mainLight1.SetActive(true);
        // mainLight2.SetActive(true);
        // mainLight3.SetActive(true);
        //objectives = new List<GameObject>();
        gameplayManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (repairedObjectives == 3)
        {
            //    mainLight1.SetActive(false);
            //    mainLight2.SetActive(false);
            //    mainLight3.SetActive(false);
            //    foreach (GameObject game in lights)
            //    {
            //        game.SetActive(true);
            //    }
            //}
            if (repairedObjectives == 4 || Input.GetKeyDown(KeyCode.B))
            {
                mainLight1.SetActive(false);
                mainLight2.SetActive(false);
                mainLight3.SetActive(false);
                GhostHandler.ghostHandler.switchtobadghost();


            }
        }
    }
}
