 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start() {
        offset = transform.position - player.transform.position;
    }

    void Update() {
        
    }

    // Update is called once per frame - LateUpdate is the same, but is guaranteed to run after all items have been run
    void LateUpdate() {
        transform.position = player.transform.position + offset;
    }

}
