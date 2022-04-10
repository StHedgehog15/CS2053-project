using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
 
public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    public PlayableAsset cutscene;
    public bool hasPlayed = false;
    public GameObject textBar;
    public Dialogue dialogue;

    void Start() {

    }

    void Update() {
        // if textBar is disabled
        if(!textBar.activeSelf) {
            SceneManager.LoadScene("Credits");
        }
    }
 
    void OnTriggerEnter2D(Collider2D c)
    {
        if (!hasPlayed && c.gameObject.tag == "Player")
        {
            StartCoroutine(StartCutscene());
        }
    }
 
    IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(.2f);
 
        hasPlayed = true;
        timeline.GetComponent<DialogueTrigger>().dialogue = dialogue;
        timeline.playableAsset = cutscene;
        timeline.Play();
    }
}