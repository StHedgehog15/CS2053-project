using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GunScript : MonoBehaviour {
    // Start is called before the first frame update
    private bool isDone;
    private bool playerMounted;
    public Text goalText;
    void Start() {
        isDone = false;
        playerMounted = false;
    }

    // Update is called once per frame
    void Update() {
        if (playerMounted && !isDone) {
            if (Input.GetKeyDown(KeyCode.E)) {
                isDone = true;
                //load plane level scene
                Debug.Log("Loading plane scene...");
                SceneManager.LoadScene("PlaneLevel");

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.tag + " is on gun");

        if (other.gameObject.tag == "Player") {
            playerMounted = true;
            goalText.text = "Press E to mount";
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        playerMounted = false;
        goalText.text = "Destroy enemy aircraft";

    }
}
