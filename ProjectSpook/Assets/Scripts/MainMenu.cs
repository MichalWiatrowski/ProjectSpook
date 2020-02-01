using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPress(Button button)
    {
        if (button.name == "StartGame") { SceneManager.LoadScene(1); }
        else if (button.name == "Options") {/* todo*/ }
        else if (button.name == "ExitGame") { Application.Quit(); }
    }
}
