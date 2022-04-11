using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using SpriteGlow;

public class GameController : MonoBehaviour
{
    //public SpriteGlowEffect spriteGlowEffect;
    public GameObject note;
    public GameObject painting;
    public GameObject player;
    public Text kitchenNote;
    public Text kitchenPainting;
    public GameObject paintingBackdrop;
    //private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // to be fixed later on 
        //spriteGlowEffect = GetComponent<SpriteGlowEffect>();
        //audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        // randomly change glow brightness 
        //spriteGlowEffect.GlowBrightness = Random.Range(1.0f, 5.0f);
        //note.GetComponent<SpriteGlowEffect>().GlowBrightness = Random.Range(1.0f, 5.0f);

    }

    public void kitchenList() {
        // remove glow from note by turning off Sprite Glow component
        //note.GetComponent<SpriteGlowEffect>().enabled = false;
        // update kitchen note
        kitchenNote.text = "To-do: \n\n Pick up vegetables from market \n\n Pick up son from practice \n\n";
        // play sound
        note.GetComponent<AudioSource>().Play();
    }

    public void paintingStory() {
        paintingBackdrop.SetActive(true);
        kitchenPainting.text = "Ah, my family... \n\nNot much else keeping me together\n\nthese days";
        // to-do: maybe scrolling text?
        StartCoroutine(ExecuteAfterTime(10));
    }

    void FixedUpdate() {
        //note.GetComponent<SpriteGlowEffect>().GlowBrightness = Random.Range(4.0f, 5.0f);
        //painting.GetComponent<SpriteGlowEffect>().GlowBrightness = Random.Range(2.0f, 3.0f);
    }

    IEnumerator ExecuteAfterTime(float time) {
        yield return new WaitForSeconds(time);
        paintingBackdrop.SetActive(false);
 }


}
