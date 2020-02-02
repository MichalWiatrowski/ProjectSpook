using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostHandler : MonoBehaviour
{
    public static GhostHandler ghostHandler;
    public GameObject objective1;
    public GameObject objective2;
    NavMeshAgent navMeshAgent;
    public bool exposed = false;
    public List<GameObject> gameObjects2;
    public GameObject front;
    public GameObject back;
    float timer = 0.0f;
    public GameObject player;
    float alpha = 1.0f;
    public Material niceGhostFront;
    public Material niceGhostBack;
    public Material badGhostFront;
    public Material badGhostBack;
    public bool badGhost = false;
    public float spriteTimer = 0.0f;
    public int currentSprite = 0;
    public List<Texture2D> badghostsprites;
    public List<Texture2D> goodghostsprites;

    public bool chasingPlayer = false;
    public List<GameObject> patrolDestinations;
    public int currentDestination = 0;
    // Start is called before the first frame update
    void Start()
    {
        ghostHandler = this;
        front = transform.GetChild(0).gameObject;
        back = transform.GetChild(1).gameObject;
        front.GetComponent<Renderer>().material = niceGhostBack;
        back.GetComponent<Renderer>().material = niceGhostFront;
       // front.GetComponent<Renderer>().material = badGhostBack;
       // back.GetComponent<Renderer>().material = badGhostFront;
        gameObjects2 = new List<GameObject>();
        navMeshAgent = GetComponent<NavMeshAgent>();



        navMeshAgent.SetDestination(patrolDestinations[currentDestination].transform.position);
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!chasingPlayer)
        {
            navMeshAgent.updateRotation = true;
        }
        //transform.LookAt(gameObject.transform.position + Vector3.forward, Vector3.up);
        //GetComponent<SpriteRenderer>().enabled = true;
       // navMeshAgent.SetDestination(player.transform.position);
        if (navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete && navMeshAgent.remainingDistance <= 0.01f)
        {
            currentDestination++;
            if (currentDestination >= patrolDestinations.Count) currentDestination = 0;

         
            navMeshAgent.SetDestination(patrolDestinations[currentDestination].transform.position);





        }
        timer += Time.deltaTime;
        if (timer >= 0.25f)
        {
            front.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(-front.GetComponent<Renderer>().material.mainTextureScale.x, 1));
            back.GetComponent<Renderer>().material.SetTextureScale("_MainTex", new Vector2(-back.GetComponent<Renderer>().material.mainTextureScale.x, 1));
            timer = 0.0f;
        }





        spriteTimer += Time.deltaTime;

        if (spriteTimer >= 1.0f)
        {
            currentSprite++;
            if (currentSprite >= badghostsprites.Count) currentSprite = 0;
            if (badGhost)
                back.GetComponent<Renderer>().material.SetTexture("_MainTex", badghostsprites[currentSprite]);
            else
            {
                back.GetComponent<Renderer>().material.SetTexture("_MainTex", goodghostsprites[currentSprite]);
            }
            spriteTimer = 0.0f;
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
  public void switchtobadghost()
    {
        badGhost = true;
        currentSprite = 0;
        front.GetComponent<Renderer>().material = badGhostBack;
       back.GetComponent<Renderer>().material = badGhostFront;
        transform.GetChild(2).GetComponent<Light>().color = new Color(255, 24, 0, 255);
        transform.GetChild(3).GetComponent<Light>().color = new Color(255, 24, 0, 255);
    }
}
