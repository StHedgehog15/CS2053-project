using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargeterController : MonoBehaviour {
    private Vector3 velocity;
    public float speed;
    public AudioSource shootSound;
    public GameController gameControl;
    private Collider2D co;
    private SpriteRenderer rend;
    public GameObject playerShot;

    // Start is called before the first frame update
    void Start() {
        velocity = new Vector3(0f, 0f, 0f);
        rend = GetComponent<SpriteRenderer>();
        shootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        velocity = new Vector3(0f, 0f, 0f);
        //set the direction based on  input
       // anim.enabled = true;
        if (Input.GetKey("left")) {
            velocity = new Vector3(-1f * speed, 0f, 0f);   
        }
        if (Input.GetKey("right")) {
            velocity = new Vector3(1f * speed, 0f, 0f);   
        }
        if (Input.GetKey("down")) {
            velocity = new Vector3(0f, -1f * speed, 0f); 
        }
        if (Input.GetKey("up")) {
            velocity = new Vector3(0f, 1f * speed, 0f);
        }

        //move the player
        transform.position += velocity * Time.deltaTime;
        //transform.position = transform.position + velocity * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.Space)) {
            shootSound.Play();
            Fire();
        }
    }

    public void Fire() {
        Instantiate(playerShot, new Vector3(transform.position.x, transform.position.y,-1), Quaternion.identity);
    }
}
