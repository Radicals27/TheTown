using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWork : GAction
{
    SpeechBubble speechBubble;
    Person thisPerson;

    void Start()
    {
        thisPerson = GetComponent<Person>();
        speechBubble = GetComponent<SpeechBubble>();
    }

    public override bool PrePerform()
    {
        speechBubble.Speak("Time to go to work!");
        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
