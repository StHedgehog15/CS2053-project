using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI; 
 
public class DialogueTrigger: MonoBehaviour
{
    public PlayableDirector director;
    public Dialogue dialogue;
    private Queue<string> sentences;
    public string sentence;
    public GameObject textBar;
    public Text textBarDialogue;
     
    void Start() 
    {
        sentences = new Queue<string>();
        //textBar.GetComponent<Text>().text = "";
    }
 
    public void TriggerDialogue()
    {
        //Pause();
 
        sentences.Clear();
         
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
 
        DisplayNextSentence();
    }
 
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            Resume();
            return;
        }
 
        sentence = sentences.Dequeue();
        //textBarDialogue.text = sentence;
        Debug.Log(sentence);
        //textBar.text = sentence;
        textBarDialogue.text = sentence;
    }
 
    void Pause()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(0);
    }
 
    void Resume()
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(1);
    }
 
}