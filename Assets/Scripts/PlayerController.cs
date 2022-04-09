using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Vector3 velocity;

    private SpriteRenderer rend;
    private Animator anim;
    public float speed;
    public GameController gameControl;
    private Rigidbody rb;
    private Collider2D co;
    public AudioSource loudScarySound;

    // Use this for initialization
    void Start() {
        velocity = new Vector3(0f, 0f, 0f);
        rend = GetComponent<SpriteRenderer> ();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        co = GetComponent<Collider2D>();
        loudScarySound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update() {
        velocity = new Vector3(0f, 0f, 0f);
        //set the direction based on  input
        anim.enabled = true;
        if (Input.GetKey("left")) {
            velocity = new Vector3(-1f * speed, 0f, 0f);   
            //anim.Play("walk_right");  
        }
        if (Input.GetKey("right")) {
            velocity = new Vector3(1f * speed, 0f, 0f);   
            anim.Play("walk_right");
        }
        if (Input.GetKey("down")) {
            velocity = new Vector3(0f, -1f * speed, 0f); 
            //anim.Play("walk_right");   
        }
        if (Input.GetKey("up")) {
            velocity = new Vector3(0f, 1f * speed, 0f);
            //anim.Play("walk_right"); 
        }
        if(velocity.x == 0 && velocity.y == 0) {
            //anim.Play("idle");
            // stop the animation
            anim.enabled = false;
        }

        //move the player
        transform.position += velocity * Time.deltaTime;
        //transform.position = transform.position + velocity * Time.deltaTime * speed;

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "KitchenNote") {
            gameControl.kitchenList();
        }
        if (other.gameObject.tag == "StartlingPot") {
            loudScarySound.Play();
        }

    }

}