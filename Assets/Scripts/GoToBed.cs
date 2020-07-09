using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBed : GAction
{
    SpeechBubble speechBubble;
    Person thisPerson;
    Animator personAnimator;

    private void Start()
    {
        thisPerson = GetComponent<Person>();
        speechBubble = GetComponent<SpeechBubble>();
        personAnimator = GetComponent<Animator>();
    }

    public override bool PrePerform()
    {
        speechBubble.Speak("I'm so tired!");

        target = inventory.FindItemWithTag("Bed");
        if(target == null)
            return false;
        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
