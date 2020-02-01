using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteract : MonoBehaviour
{
 
   
    
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;


            //Run a raycast from the mouse pointer (middle of the screen)
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {

                if (hit.transform)
                {
                    Debug.Log("Hit an object called: " + hit.transform.gameObject.name);
                }
                if (hit.transform.gameObject.tag == "Door")
                {
                    hit.transform.gameObject.GetComponent<Door>().openDoor();
                }
                ////if it the piano object
                //if (hit.transform.gameObject == pianoObject)
                //{
                //    //free the cursor
                //    Cursor.lockState = CursorLockMode.None;
                //    //enable the UI
                //    pianoHUD.SetActive(true);
                //    //disable the movement and shooting
                //    simpleMovementReference.enabled = false;

                //}     
            }
        }

      
    }
}
