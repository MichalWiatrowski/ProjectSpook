using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    float m_flickerTimer = 0.0f;
    float m_flickerMaxTimer = 6.0f;
    bool m_flickering = false;
    public bool enabled = false;
    Light m_spotlight;
    GameObject coneCollider;
    GameObject ghost;
    // Start is called before the first frame update
    void Start()
    {
        ghost = GameObject.Find("Ghost");
        //Retrieve the light component
        m_spotlight = GetComponent<Light>();
        //init the flicker timer to random value so not all lights flicker at the same time
        m_flickerTimer = Random.Range(0.0f, 5.0f);
        m_spotlight.intensity = 10;
        coneCollider = gameObject.transform.GetChild(0).gameObject;
        coneCollider.transform.localScale = new Vector3(m_spotlight.spotAngle / 2, (m_spotlight.spotAngle / 2), (m_spotlight.range) + 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            //if the light is not flickering
            if (!m_flickering)
            {
                //increment the flicker timer
                m_flickerTimer += Time.deltaTime;

                //if the flicker timer is greater or equal to the flicker time
                if (m_flickerTimer >= m_flickerMaxTimer)
                {
                    //start flickering
                    m_flickering = true;
                    //Start a coroutine with the flicker ssound and light "animation"
                    StartCoroutine(PlaySoundAndFlickerLight());
                }
            }
        }
        else
        {
            m_spotlight.intensity = 0;
        }
        

   

    }

    IEnumerator PlaySoundAndFlickerLight()
    {
        //Call the WWsise event to start playing the flicker sound on this game object the script is attached to
        //AkSoundEngine.PostEvent("LightFlicker_Play", this.gameObject);

        //Flicker from 0 to 10
        //The wait for seconds is matched with the sound to try and add realism/immersion
        m_spotlight.intensity = 0;
        showhideghost();
       yield return new WaitForSecondsRealtime(0.2f);
        m_spotlight.intensity = 2;
        showhideghost();
        yield return new WaitForSecondsRealtime(0.4f);
        m_spotlight.intensity = 0;
        showhideghost();
        yield return new WaitForSecondsRealtime(0.11f);
        m_spotlight.intensity = 2;
        showhideghost();
        //reset the valuess to default
        m_flickerTimer = 0.0f;
        m_flickering = false;
    }

    void showhideghost()
    {
        coneCollider.SetActive(!coneCollider.activeSelf);
        if (!coneCollider.activeSelf && ghost.GetComponent<GhostHandler>().gameObjects2.Contains(coneCollider))
        {
            ghost.GetComponent<GhostHandler>().gameObjects2.Remove(coneCollider);
        }
        //else if (coneCollider.activeSelf && !ghost.GetComponent<GhostHandler>().gameObjects2.Contains(coneCollider))
        //{
        //    ghost.GetComponent<GhostHandler>().gameObjects2.Add(coneCollider);
        //}
    }
    public void enableDisableLight()
    {
        enabled = !enabled;
        showhideghost();
    }
    
}
