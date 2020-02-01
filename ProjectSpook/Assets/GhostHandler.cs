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
    // Start is called before the first frame update
    void Start()
    {
        gameObjects2 = new List<GameObject>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(objective1.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
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
        GetComponent<SpriteRenderer>().enabled = false;
    }
    public void ShowGhost()
    {
        GetComponent<SpriteRenderer>().enabled = true;
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
