using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SpriteGlow;

public class GameController : MonoBehaviour
{
    //public SpriteGlowEffect spriteGlowEffect;
    public GameObject note;
    public GameObject player;
    public Text kitchenNote;
    // Start is called before the first frame update
    void Start()
    {
        // to be fixed later on 
        //spriteGlowEffect = GetComponent<SpriteGlowEffect>();

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
        note.GetComponent<SpriteGlowEffect>().enabled = false;



        // update kitchen note
        kitchenNote.text = "To-do: \n\n Pick up vegetables from market \n\n Pick up son from practice \n\n";
    }

    void FixedUpdate() {
        note.GetComponent<SpriteGlowEffect>().GlowBrightness = Random.Range(4.0f, 5.0f);
    }


}
