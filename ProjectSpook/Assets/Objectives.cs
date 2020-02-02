using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    
    public bool repaired = false;
    public bool repairing = false;
    public float timer = 0.0f;
    public float maxRepair = 5.0f;



    public bool window1 = false;
    public bool uturnpipe = false;
    public Material window1fixed;
    public Material window2fixed;
    public Material lightswitch;
    public GameObject lightforlightswitch;
    public Material pipefixed;
    public Material pipe2fixed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!repairing) timer = 0.0f;
        else
        {
            Debug.Log("repairing");
            timer += Time.deltaTime;
            if (timer >= maxRepair)
            {
                Debug.Log("repaired");
                timer = 0.0f;
                repaired = true;
                repairing = false;
                if (gameObject.tag == "Window")
                {
                    if (window1) GetComponent<Renderer>().material = window1fixed;
                    else GetComponent<Renderer>().material = window2fixed;
                }
                else if (gameObject.tag == "Lightswitch")
                {
                    GetComponent<Renderer>().material = lightswitch;
                }
                else if (gameObject.tag == "Pipe")
                {
                    if (!uturnpipe)
                    GetComponent<Renderer>().material = pipefixed;
                    else
                        GetComponent<Renderer>().material = pipe2fixed;
                }
                GameplayManager.gameplayManager.repairedObjectives++;




            }
        }
    }


}
