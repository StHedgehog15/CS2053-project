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
    public GameObject floatingText;
    private GameObject floatingTextInstance;
    bool isFloatingNote = false;
    bool isFloatingPainting = false;
    Vector3 offset;
    private bool lastWasRight = true;
    // Use this for initialization
    void Start() {
        velocity = new Vector3(0f, 0f, 0f);
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        co = GetComponent<Collider2D>();
        //loudScarySound = GetComponent<AudioSource>();
        offset = new Vector3(0, 2.5f, 0);
    }

    // Update is called once per frame
    void Update() {
        velocity = new Vector3(0f, 0f, 0f);
        //set the direction based on  input
       // anim.enabled = true;
        if (Input.GetKey("left")) {
            velocity = new Vector3(-1f * speed, 0f, 0f);
            //anim.Play("walk_right");  
            lastWasRight = false;
        }
        if (Input.GetKey("right")) {
            velocity = new Vector3(1f * speed, 0f, 0f);
            //anim.Play("walk_right");
            lastWasRight = true;
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
        //    anim.enabled = false;
        }
      
        // user interaction and pressing E
        if(Input.GetKey("e")) {
            if(isFloatingNote) {
                gameControl.kitchenList();
                floatingTextInstance.SetActive(false);
                isFloatingNote = false;
                Destroy(floatingTextInstance);
            } else if(isFloatingPainting) {
                gameControl.paintingStory();
                floatingTextInstance.SetActive(false);
                isFloatingPainting = false;
                Destroy(floatingTextInstance);
            } 
        }
        if (lastWasRight)
        {
            anim.Play("walk_right");
        }
        else
        {
            //anim.Play("walk_left");
        }
        //move the player
        transform.position += velocity * Time.deltaTime;
        //transform.position = transform.position + velocity * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "KitchenNote") {
            if(!isFloatingNote) {
                floatingTextInstance = Instantiate(floatingText, transform.position+offset, Quaternion.identity, transform);
                floatingTextInstance.SetActive(true);
                isFloatingNote = true;
            }
        }

        if (other.gameObject.tag == "StartlingPot") {
            loudScarySound.Play();
        }

        if(other.gameObject.tag == "painting") {
            if(!isFloatingPainting) {
                floatingTextInstance = Instantiate(floatingText, transform.position+offset, Quaternion.identity, transform);
                floatingTextInstance.SetActive(true);
                isFloatingPainting = true;
            }
        }

    }

}