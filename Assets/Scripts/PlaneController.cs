using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class PlaneController : MonoBehaviour
{
    public float speed;
    private bool isDestroyed;
    private SpriteRenderer rend;
    private Animator anim;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start() {
        isDestroyed = false;
        velocity = new Vector3(speed, 0f, 0f);
        rend = GetComponent<SpriteRenderer> ();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

       // calculate location of screen borders
        // this will make more sense after we discuss vectors and 3D
        var dist = (transform.position - Camera.main.transform.position).z;
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        
        //get the width of the object
        float width = rend.bounds.size.x;
        float height = rend.bounds.size.y;

        //1% of the time, switch the direction: 
        int change = Random.Range(0,100);
        if (change == 0) {
            velocity = new Vector3(-velocity.x, 0, -velocity.z);
        }
        
        //make sure the obect is inside the borders... if edge is hit reverse direction

        //hits left border - should go right
        if((transform.position.x <= leftBorder + width/2.0) && velocity.x < 0f) {
            velocity = new Vector3(-speed, 0f, 0f);
        //    anim.Play("GhostRightOrange");    
        }

        //hits right border - should go left
        if((transform.position.x >= rightBorder - width/2.0) && velocity.x > 0f) {
            velocity = new Vector3(speed, 0f, 0f);
        //    anim.Play("GhostLeftBlue");
        }

        //hits bottom border - should go up
        if((transform.position.y <= bottomBorder + height/2.0) && velocity.y < 0f) {
            velocity = new Vector3(0f, 1f, 0f);
        //    anim.Play("GhostUpRed");    
        }

        //hits top border - should go down
        if((transform.position.y >= topBorder - height/2.0) && velocity.y > 0f) {
            velocity = new Vector3(0f, -1f, 0f);
        //    anim.Play("GhostDownPink");
        }
        transform.position = transform.position + velocity * Time.deltaTime * speed;

    }

    bool isHit(Vector3 cursor) {
        if (cursor.x == transform.position.x) {
            return true;
        }

        return false;
    }
}
