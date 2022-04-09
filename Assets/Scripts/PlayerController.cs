using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Vector3 velocity;

    private SpriteRenderer rend;
    private Animator anim;
    public float speed;
    public GameController gameControl;

    // Use this for initialization
    void Start() {
        velocity = new Vector3(0f, 0f, 0f);
        rend = GetComponent<SpriteRenderer> ();
        anim = GetComponent<Animator>();
        speed = 4.0f;
    }

    // Update is called once per frame
    void Update() {
        velocity = new Vector3(0f, 0f, 0f);

        //set the direction based on  input
        if (Input.GetKey("left")) {
            velocity = new Vector3(-1f * speed, 0f, 0f);  
        //    anim.Play("PacManLeft");    
        }
        if (Input.GetKey("right")) {
            velocity = new Vector3(1f * speed, 0f, 0f);   
        //    anim.Play("PacManRight");    
        }
        if (Input.GetKey("down")) {
            velocity = new Vector3(0f, -1f * speed, 0f); 
        //    anim.Play("PacManDown");    
        }
        if (Input.GetKey("up")) {
            velocity = new Vector3(0f, 1f * speed, 0f);
        //    anim.Play("PacManUp");    
        }

        //move the player
        transform.position += velocity * Time.deltaTime;
        //transform.position = transform.position + velocity * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "stat_obj") {
            velocity = new Vector3(0f, 0f, 0f);
        }

        if(other.gameObject.tag == "KitchenNote") {
            gameControl.kitchenList();
        }
        
    }
}