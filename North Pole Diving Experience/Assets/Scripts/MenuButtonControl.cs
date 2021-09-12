using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtonControl : MonoBehaviour
{

    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(goToGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void goToGame()
    {
        if (button.tag == "StartButton")
        {
            SceneManager.LoadScene("Level 1");
        }
        else if (button.tag == "ExitButton")
        {
            Application.Quit();
        }
    }
}
