using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
 
public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    public PlayableAsset cutscene;
    public bool hasPlayed = false;
 
    public Dialogue dialogue;
 
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