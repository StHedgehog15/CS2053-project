using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteGlow;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    private Vector2 velocity;

    private SpriteRenderer rend;
    private Animator anim;
    public float speed;
    public GameController gameControl;
    private Rigidbody2D rb;
    private Collider2D co;
    public AudioSource loudScarySound;
    public GameObject floatingText;
    private GameObject floatingTextInstance;
    public GameObject coach;
    bool isFloatingNote = false;
    bool isFloatingPainting = false;
    bool atDoor = false;
    private Vector3 offset;
    private bool lastWasRight = true;
    private bool canGoLeft, canGoRight, canGoUp, canGoDown = true;
    public int groceriesAcquired;


    // Use this for initialization
    void Start() {
        velocity = new Vector2(0f, 0f);
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        co = GetComponent<Collider2D>();
        //loudScarySound = GetComponent<AudioSource>();
        offset = new Vector2(0, 2.5f);
        groceriesAcquired = 3;

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp("left"))
            canGoLeft = true;
        if (Input.GetKeyUp("right"))
            canGoRight = true;
        if (Input.GetKeyUp("up"))
            canGoUp = true;
        if (Input.GetKeyUp("down"))
            canGoDown = true;

        velocity = new Vector2(0f, 0f);
        //set the direction based on  input
       // anim.enabled = true;
        if (Input.GetKey("left") && canGoLeft) {
            velocity = new Vector2(-1f * speed, 0f);
            //anim.Play("walk_right");  
            lastWasRight = false;
        }
        if (Input.GetKey("right") && canGoRight) {
            velocity = new Vector2(1f * speed, 0f);
            //anim.Play("walk_right");
            lastWasRight = true;
        }
        if (Input.GetKey("down") && canGoDown) {
            velocity = new Vector2(0f, -1f * speed); 
            //anim.Play("walk_right");   
        }
        if (Input.GetKey("up") && canGoUp) {
            velocity = new Vector2(0f, 1f * speed);
            //anim.Play("walk_right"); 
        }
        if(velocity.x == 0 && velocity.y == 0) {
            if (lastWasRight)
                anim.Play("idle_right");
            else
                anim.Play("idle_left");
        } else {
            if (lastWasRight)
                anim.Play("walk_right");
            else
                anim.Play("walk_left");
        }
        
      
        // user interaction and pressing E
        if(Input.GetKey("e")) {
            if (isFloatingNote) {
                gameControl.kitchenList();
                floatingTextInstance.SetActive(false);
                isFloatingNote = false;
                Destroy(floatingTextInstance);
            } 
            else if (isFloatingPainting) {
                gameControl.paintingStory();
                floatingTextInstance.SetActive(false);
                isFloatingPainting = false;
                Destroy(floatingTextInstance);
            } 
            else if (atDoor) {
                //load market scene;
            } 
        }

        /*
        if (lastWasRight)
        {
            anim.Play("walk_right");
        }
        else
        {
            anim.Play("walk_left");
        }
        */
        //move the player
        //transform.position += velocity * Time.deltaTime;

        //Use .velocity or .MovePosition to use rb's collision detection smoothly
        rb.velocity = velocity;
        //rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
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
        if (other.gameObject.tag == "BlockingElement")
        {
            if (Input.GetKey("left"))
                canGoLeft = false;
            if (Input.GetKey("right"))
                canGoRight = false;
            if (Input.GetKey("down"))
                canGoDown = false;
            if (Input.GetKey("up"))
                canGoUp = false;
        }

        if (other.gameObject.tag == "houseDoor")
        {
            if (Input.GetKey("left"))
                canGoLeft = false;
            if (Input.GetKey("right"))
                canGoRight = false;
            if (Input.GetKey("down"))
                canGoDown = false;
            if (Input.GetKey("up"))
                canGoUp = false;
            SceneManager.LoadScene("MarketLevel");
        }

        if (other.gameObject.tag == "VeggieStand")
        {
            if (Input.GetKey("left"))
                canGoLeft = false;
            if (Input.GetKey("right"))
                canGoRight = false;
            if (Input.GetKey("down"))
                canGoDown = false;
            if (Input.GetKey("up"))
                canGoUp = false;
            groceriesAcquired--;
            gameControl.kitchenNote.text = "Groceries left: " + (groceriesAcquired).ToString();
            other.gameObject.tag = "Untagged";
            if (groceriesAcquired <= 0) {
                SceneManager.LoadScene("IntramuralScene");
            }
        }

        if (other.gameObject.tag == "coach")
        {
            coach.GetComponent<AudioSource>().Play();
            // stop music 
            GameObject.Find("IntramuralMusic").GetComponent<AudioSource>().Stop();
            GameObject.Find("IntramuralAmbience").GetComponent<AudioSource>().Stop();
            GameObject.Find("InteractionMusic").GetComponent<AudioSource>().Play();
            // remove glow 
            coach.GetComponent<SpriteGlowEffect>().enabled = false;
            // wait until audio is done to change scene
            StartCoroutine(ExecuteAfterTime(16.0f));
        }

    }
    /**
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "BlockingElement")
        {
            if (Input.GetKey("left"))
                canGoLeft = false;
            if (Input.GetKey("right"))
                canGoRight = false;
            if (Input.GetKey("down"))
                canGoDown = false;
            if (Input.GetKey("up"))
                canGoUp = false;
        }
    }**/

    IEnumerator ExecuteAfterTime(float time) {
        yield return new WaitForSeconds(time);
        // load the next scene, unload the current scene
        SceneManager.LoadScene("BattlefieldScene");
    }

}