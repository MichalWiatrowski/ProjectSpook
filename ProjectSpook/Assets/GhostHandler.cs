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
    float timer = 0.0f;
    public GameObject player;
    float alpha = 1.0f;
    public Material niceGhostFront;
    public Material niceGhostBack;
    public Material badGhostFront;
    public Material badGhostBack;
    // Start is called before the first frame update
    void Start()
    {
        front = transform.GetChild(0).gameObject;
        back = transform.GetChild(1).gameObject;
       // front.GetComponent<Renderer>().material = niceGhostFront;
//back.GetComponent<Renderer>().material = niceGhostBack;
        front.GetComponent<Renderer>().material = badGhostFront;
        back.GetComponent<Renderer>().material = badGhostBack;
        gameObjects2 = new List<GameObject>();
        navMeshAgent = GetComponent<NavMeshAgent>();
      
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Camera.main.transform.position, Vector3.up);
        //GetComponent<SpriteRenderer>().enabled = true;
        navMeshAgent.SetDestination(player.transform.position);
        //if (navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete)
        //{
        //    navMeshAgent.SetDestination(objective2.transform.position);
        //}
        timer += Time.deltaTime;
        if (timer >= 0.25f)
        {
            front.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(-front.GetComponent<Renderer>().material.mainTextureScale.x, 1));
            back.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(-back.GetComponent<Renderer>().material.mainTextureScale.x, 1));
            timer = 0.0f;
        }
     
        if (gameObjects2.Count == 0)
            ShowGhost();
        else
            HideGhost();
    }
    public void HideGhost()
    {
        alpha -= Time.deltaTime * 3.0f;
        if (alpha <= 0.0f) alpha = 0.0f;
        front.GetComponent<Renderer>().material.color = new Color(front.GetComponent<Renderer>().material.color.r, front.GetComponent<Renderer>().material.color.g, front.GetComponent<Renderer>().material.color.b, alpha);
        back.GetComponent<Renderer>().material.color = new Color(back.GetComponent<Renderer>().material.color.r, back.GetComponent<Renderer>().material.color.g, back.GetComponent<Renderer>().material.color.b, alpha);
    }
    public void ShowGhost()
    {
        alpha += Time.deltaTime * 3.0f;
        if (alpha >= 1.0f) alpha = 1.0f;
        front.GetComponent<Renderer>().material.color = new Color(front.GetComponent<Renderer>().material.color.r, front.GetComponent<Renderer>().material.color.g, front.GetComponent<Renderer>().material.color.b, alpha);
        back.GetComponent<Renderer>().material.color = new Color(back.GetComponent<Renderer>().material.color.r, back.GetComponent<Renderer>().material.color.g, back.GetComponent<Renderer>().material.color.b, alpha);
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
