using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccerController : MonoBehaviour
{
    private Vector3 velocity;
    private SpriteRenderer rend;
    public float speed = 4.0f;
    //public GameController gameController;
    //public GameObject soccerNPC;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0f, 0f, 0f);
        velocity.x = speed;
        rend = GetComponent<SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity != null)
            transform.Translate(velocity * Time.deltaTime * speed);



        //1% of the time, switch the direction: 
        int change = Random.Range(0,100);
        if (change == 0)
        {
            velocity = new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), 0f);
            //velocity = new Vector3(-velocity.x, 0f, 0f);
            //velocity.x *= -1;
            //anim.Play("Ghost_1_Left");
        } else {
            //velocity.x *= -1;
        }
    }
}
