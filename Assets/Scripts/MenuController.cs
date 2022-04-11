using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //public Button startGame;
    //public Button quitGame;



    // Start is called before the first frame update
    void Start()
    {
        //startGame.onClick.AddListener(StartGame);
        //quitGame.onClick.AddListener(QuitGame);

        // startGame.onClick.AddListener(() => {
        //     Debug.Log("Start Game");
        // });

        // quitGame.onClick.AddListener(() => {
        //     Debug.Log("Quit Game");
        // });


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("StartLevel");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void loadCredits() {
        Debug.Log("Load Credits");
        SceneManager.LoadScene("Credits");
    }

}
