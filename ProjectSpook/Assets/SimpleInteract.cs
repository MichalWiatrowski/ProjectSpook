using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteract : MonoBehaviour
{


    GameObject interactingObject;
    SimpleMovement simpleMovementReference;
    // Start is called before the first frame update
    void Start()
    {
        //Set the reference
        simpleMovementReference = GetComponent<SimpleMovement>();
        //Disable the UI by default


    }

    // Update is called once per frame
    void Update()
    {

        //If the player pressed interact
        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;


            //Run a raycast from the mouse pointer (middle of the screen)
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward), out hit, 2))
            {

                //Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward))
                if (hit.transform)
                {
                    Debug.Log("Hit an object called: " + hit.transform.gameObject.name);
                }
                if (hit.transform.gameObject.tag == "Door")
                {
                    hit.transform.gameObject.GetComponent<Door>().openDoor();
                }
                if ((hit.transform.gameObject.tag == "Window" || (hit.transform.gameObject.tag == "Lightswitch") && GameplayManager.gameplayManager.objectives.Contains(hit.transform.gameObject) && !hit.transform.gameObject.GetComponent<Objectives>().repaired))
                {
                    interactingObject = hit.transform.gameObject;
                    interactingObject.GetComponent<Objectives>().repairing = true;





                }
               
            

            }

        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            if (interactingObject)
            {
                if (!interactingObject.GetComponent<Objectives>().repaired)
                {
                    interactingObject.GetComponent<Objectives>().repairing = false;
                    interactingObject = null;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward), out hit, 2))
            {
                if (hit.transform.gameObject.tag == "Lightswitch" && GameplayManager.gameplayManager.objectives.Contains(hit.transform.gameObject) && hit.transform.gameObject.GetComponent<Objectives>().repaired)
                {
                    if (hit.transform.gameObject.GetComponent<Objectives>().lightforlightswitch != null)
                    {
                        hit.transform.gameObject.GetComponent<Objectives>().lightforlightswitch.GetComponent<LightFlicker>().enableDisableLight();
                    }
                    
                }
            }
        }
       

    }
}

