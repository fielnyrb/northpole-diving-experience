using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButtonControl : MonoBehaviour
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
        SceneManager.LoadScene("Level 1");
    }
}