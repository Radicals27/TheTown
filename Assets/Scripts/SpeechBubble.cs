using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    public Text speechBubbleContents;
    public CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup.alpha = 0f;
        Speak("I was just created!");
    }

    public void Speak(string speech)
    {
        speechBubbleContents.text = speech;
        canvasGroup.alpha = 1f;

        Invoke("clearSpeechBubble", 3);
    }

    void clearSpeechBubble()
    {
        speechBubbleContents.text = "";
        canvasGroup.alpha = 0f;
    }

    void Update()
    {
       
    }
}
