using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Smoothly open a door
    public float doorOpenAngle = 90.0f; //Set either positive or negative number to open the door inwards or outwards
    public float openSpeed = 2.0f; //Increasing this value will make the door open faster

    public bool open = false;
    bool enter = false;

    float defaultRotationAngle;
    float currentRotationAngle;
    public float openTime = 0;

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


        if (hinge.transform.localEulerAngles.y == defaultRotationAngle || hinge.transform.localEulerAngles.y == defaultRotationAngle + 90.0f)
        {
            m_opening = false;
            

        }
        
    }

    public void openDoor()
    {
        if (!mainDoor)
        {
            if (!m_opening)
            {
                open = !open;
                currentRotationAngle = hinge.transform.localEulerAngles.y;
                openTime = 0.0f;
                m_opening = true;
            }
        }
        else
        {
            //win game
        }
    }
   IEnumerator openclosedoor()
    {





        yield return null;
    }
}
