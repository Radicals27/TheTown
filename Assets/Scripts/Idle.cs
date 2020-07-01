using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : GAction
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
        speechBubble.Speak("I'm sitting down.");
        return true;
    }

    public override bool PostPerform()
    {
        //GWorld.Instance.GetQueue("people").AddResource(this.gameObject);
        beliefs.RemoveState("isIdle");
        return true;
    }
}
