using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Smoothly open a door
    public float doorOpenAngle = 90.0f; //Set either positive or negative number to open the door inwards or outwards
    public float openSpeed = 2.0f; //Increasing this value will make the door open faster

    bool open = false;
    bool enter = false;

    float defaultRotationAngle;
    float currentRotationAngle;
    float openTime = 0;

    bool m_doorOpened = false;
    bool m_opening = false;
    public GameObject hinge;



    public bool mainDoor = false;
    // Start is called before the first frame update
    void Start()
    {
      
       // hinge = gameObject.GetComponentInParent<Transform>().gameObject;
        defaultRotationAngle = hinge.transform.localEulerAngles.y;
        currentRotationAngle = hinge.transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (openTime < 1)
        {
            openTime += Time.deltaTime * openSpeed;
        }
        hinge.transform.localEulerAngles = new Vector3(hinge.transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (open ? doorOpenAngle : 0), openTime), hinge.transform.localEulerAngles.z);

        
         
        
    }

    public void openDoor()
    {
        if (!mainDoor)
        {
            open = !open;
            currentRotationAngle = hinge.transform.localEulerAngles.y;
            openTime = 0;
        }
        else
        {
            //win game
        }

    }
   
}
