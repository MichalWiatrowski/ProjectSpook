using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostHandler : MonoBehaviour
{
    public GameObject objective1;
    public GameObject objective2;
    NavMeshAgent navMeshAgent;
    public bool exposed = false;
    public List<GameObject> gameObjects2;
    GameObject front;
    GameObject back;
    // Start is called before the first frame update
    void Start()
    {
        front = transform.GetChild(0).gameObject;
        back = transform.GetChild(1).gameObject;
        gameObjects2 = new List<GameObject>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(objective1.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
       // transform.LookAt(Camera.main.transform.position, Vector3.up);
        //GetComponent<SpriteRenderer>().enabled = true;

        if (navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            navMeshAgent.SetDestination(objective2.transform.position);
        }

        if (gameObjects2.Count == 0)
            ShowGhost();
        else
            HideGhost();
    }
    public void HideGhost()
    {
        front.GetComponent<SpriteRenderer>().enabled = false;
        back.GetComponent<SpriteRenderer>().enabled = false;
    }
    public void ShowGhost()
    {
        front.GetComponent<SpriteRenderer>().enabled = true;
        back.GetComponent<SpriteRenderer>().enabled = true;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Light")
    //    {
    //        other.gameObject.GetComponent<ConeHandler>().seeGhost = true;
    //      HideGhost();
    //    }
    //}
    //private void OnTriggerStay(Collider other)
    //{

    //    if (other.gameObject.tag == "Light")
    //    {
    //        other.gameObject.GetComponent<ConeHandler>().seeGhost = true;
    //        HideGhost();
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Light")
    //    {
    //        other.gameObject.GetComponent<ConeHandler>().seeGhost = false;
    //        ShowGhost();
    //    }
    //}
}
