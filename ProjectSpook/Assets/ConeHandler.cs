using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeHandler : MonoBehaviour
{
    public bool seeGhost = false;
    public bool playerFlashLight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            //other.gameObject.GetComponent<GhostHandler>().exposed = true;
            if (!other.gameObject.GetComponent<GhostHandler>().gameObjects2.Contains(gameObject))
            other.gameObject.GetComponent<GhostHandler>().gameObjects2.Add(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            //other.gameObject.GetComponent<GhostHandler>().exposed = true;
            if (other.gameObject.GetComponent<GhostHandler>().gameObjects2.Contains(gameObject))
                other.gameObject.GetComponent<GhostHandler>().gameObjects2.Remove(gameObject);
        }
    }
   
}
    
