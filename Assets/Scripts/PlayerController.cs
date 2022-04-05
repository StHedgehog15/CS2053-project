using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Vector3 velocity;

    private SpriteRenderer rend;
    private Animator anim;
    public float speed;
    private bool nearInteract;

    // Start is called before the first frame update
    void Start() {
        velocity = new Vector3(0f, 0f, 0f);
        rend = GetComponent<SpriteRenderer> ();
        anim = GetComponent<Animator>();
        nearInteract = false;
    }

    // Update is called once per frame
    void Update() {
        velocity = new Vector3(0f, 0f, 0f);  

       // calculate location of screen borders
        // this will make more sense after we discuss vectors and 3D
        
        //get the width of the object

            //set the direction based on  input
            if (Input.GetKey("left")) {
                velocity = new Vector3(-1f, 0f, 0f);  
            //    anim.Play("PacManLeft");    
            }
            if (Input.GetKey("right")) {
                velocity = new Vector3(1f, 0f, 0f);   
            //    anim.Play("PacManRight");    
            }
            if (Input.GetKey("down")) {
                velocity = new Vector3(0f, -1f, 0f); 
            //    anim.Play("PacManDown");    
            }
            if (Input.GetKey("up")) {
                velocity = new Vector3(0f, 1f, 0f);
             //   anim.Play("PacManUp");    
            }

        transform.position = transform.position + velocity * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Dresser") {
            nearInteract = true;
        }
        
        
    }

    
    void ExitTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "") {
            nearInteract = false;
        }
        
        
    }
}
