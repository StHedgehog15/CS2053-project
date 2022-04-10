using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() {
    //    Destroy(gameObject);

    }

    public void InitPosition(Vector3 p) {
        transform.position = p; 
    }  

    public void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }
}
