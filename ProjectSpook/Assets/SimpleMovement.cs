using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
   
    [SerializeField] float m_speed = 10;
    [SerializeField] float m__rotationSpeed = 180;
    [SerializeField] float m_jumpSpeed = 20.0f;
    [SerializeField] float gravity = 25.0f;

    public GameObject ghost;

    bool jumping = false;
    CharacterController characterController;
    Light flashlight;
    GameObject coneCollider;
    float m_jumped = 0.0f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        flashlight = GetComponentInChildren<Light>();
        coneCollider = gameObject.transform.Find("FlashLight").GetChild(0).gameObject;
       
    }
   
    public void Update()
    {
        ////Update the rotation
        rotate();

        float m_jump = 0.0f;
        Vector3 forward = Vector3.zero;

        forward = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
        forward = transform.TransformDirection(forward);
        forward.y = 0;
        forward.Normalize();



        //check if the player is grounded and if the jump button is pressed if
        if (characterController.isGrounded) if(Input.GetButton("Jump")) jumping = true;
  

        if (jumping)
        {
            m_jump += m_jumpSpeed * Time.deltaTime;
            m_jumped += m_jumpSpeed * Time.deltaTime;
            if (m_jumped >= 5.0f)
            {
                jumping = false;
                m_jumped = 0.0f;
            }
        }
        else if (!jumping)
            m_jump -= gravity * Time.deltaTime;


        //move the player
        characterController.Move(Input.GetAxisRaw("Horizontal") * transform.right * m_speed * Time.deltaTime);
        characterController.Move(forward * m_speed * Time.deltaTime);
        characterController.Move(new Vector3(0, m_jump, 0) * m_speed * Time.deltaTime);
        
      

        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
            coneCollider.SetActive(!coneCollider.activeSelf);
           if (!coneCollider.activeSelf && ghost.GetComponent<GhostHandler>().gameObjects2.Contains(coneCollider))
            {
                ghost.GetComponent<GhostHandler>().gameObjects2.Remove(coneCollider);
            }
           else if (coneCollider.activeSelf && !ghost.GetComponent<GhostHandler>().gameObjects2.Contains(coneCollider))
            {
                ghost.GetComponent<GhostHandler>().gameObjects2.Add(coneCollider);
            }
           
        }

        if (flashlight.enabled)

        {
            //RaycastHit[] hit;

        
            //hit = ConeCast.ConeCastAll(flashlight.transform.position, flashlight.spotAngle / ((flashlight.areaSize.x + flashlight.areaSize.y) * 4), flashlight.transform.forward, Mathf.Infinity, flashlight.spotAngle);
            ////Vector3 p1 = transform.position + characterController.center;

            //if (hit.Length > 0)
            //{
            //    for (int i = 0; i < hit.Length; i++)
            //    {
            //        if (hit[i].collider.gameObject.tag == "Ghost")
            //            hit[i].transform.GetComponent<GhostHandler>().HideGhost();
            //        //do something with collider information
            //       // Debug.Log(hit[i].collider.gameObject.name);
            //    }
            //}
            ////if (Physics.Raycast(flashlight.transform.position, flashlight.transform.forward, out hit, Mathf.Infinity))
            ////{
              
            ////    Debug.DrawRay(flashlight.transform.position, flashlight.transform.forward * hit.distance, Color.yellow);
            ////    if (hit.transform.tag == "Ghost")
            ////    {
            ////        hit.transform.GetComponent<GhostHandler>().HideGhost();
            ////    }
            ////}
         
        }
    }
    //void OnDrawGizmos()
    //{
    //    Vector3 p1 = transform.position + characterController.center;
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(p1, flashlight.spotAngle / 2);
    //}

 
    public void FixedUpdate()
    {
       
    }
    void rotate()
    {
        float x;
        float y;
        Vector3 rotateValue;

        //Get movement from the mouse
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        //create a vector3 with the movement values
        rotateValue = new Vector3(x, y * -1, 0);
        //update the rotation of the player
        transform.eulerAngles = transform.eulerAngles - rotateValue;
    }      
}


