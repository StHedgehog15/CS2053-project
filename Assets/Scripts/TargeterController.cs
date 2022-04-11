using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TargeterController : MonoBehaviour {
    private Vector3 velocity;
    public float speed;
    private Collider2D co;
    private SpriteRenderer rend;
    public AudioSource shootSound;
    public GameObject playerShot;
    public Text objText;
    private bool canFire;
    private GameObject b;

    // Start is called before the first frame update
    void Start() {
        velocity = new Vector3(0f, 0f, 0f);
        rend = GetComponent<SpriteRenderer>();
        shootSound = GetComponent<AudioSource>();
        canFire = true;

    }

    // Update is called once per frame
    void Update() {
        velocity = new Vector3(0f, 0f, 0f);
        //set the direction based on  input
       // anim.enabled = true;
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A)) {
            velocity = new Vector3(-1f * speed, 0f, 0f);   
        }
        if (Input.GetKey("right") || Input.GetKey(KeyCode.D)) {
            velocity = new Vector3(1f * speed, 0f, 0f);   
        }
        if (Input.GetKey("down") || Input.GetKey(KeyCode.S)) {
            velocity = new Vector3(0f, -1f * speed, 0f); 
        }
        if (Input.GetKey("up") || Input.GetKey(KeyCode.W)) {
            velocity = new Vector3(0f, 1f * speed, 0f);
        }

        //move the player
        transform.position += velocity * Time.deltaTime;
        //transform.position = transform.position + velocity * Time.deltaTime * speed;
        if (Input.GetKey(KeyCode.Space) && canFire) {
            Fire();
        }

        // if count of objects is greater than 0, display the count
        if (GameObject.FindGameObjectsWithTag("Stat_obj").Length == 0) {
            SceneManager.LoadScene("FinalScene");
        }
    }
    
    void Fire() {
        //shootSound.Play();
        b = Instantiate(playerShot, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
        b.GetComponent<ShotController>().InitPosition(transform.position);
        canFire = false;
        StartCoroutine(PlayerCanFireAgain());
        objText.text = "Reloading...";
    }

    IEnumerator PlayerCanFireAgain() {
        //this will pause the execution of this method for 3 seconds without blocking
        yield return new WaitForSecondsRealtime(3);
        canFire = true;
        Destroy(b);
        objText.text = "Press Space to fire";
    }

}
