using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBed : GAction
{
    SpeechBubble speechBubble;
    Person thisPerson;

    private void Start()
    {
        thisPerson = GetComponent<Person>();
        speechBubble = GetComponent<SpeechBubble>();
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
        beliefs.RemoveState("isTired");
        thisPerson.sleep();
        return true;
    }
}
