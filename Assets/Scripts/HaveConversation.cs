using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveConversation : GAction
{
    SpeechBubble speechBubble;              //The speaker's speech bubble
    SpeechBubble recipientSpeechBubble;     //The person being spoken to's bubble
    Person thisPerson;

    void Start()
    {
        thisPerson = GetComponent<Person>();
        speechBubble = GetComponent<SpeechBubble>();
    }

    public override bool PrePerform()
    {
        //target = gworld.instance.getqueue("people").removeresource();   //the target/recipient becomes the last person on the queue

        //if (target == null)   //if there is no one waiting on the queue, this conversation can't happen
            return false;

        //recipientspeechbubble = target.getcomponent<speechbubble>();

        //speechbubble.speak("hello!");
        //recipientspeechbubble.speak("goodbye!");

        //return true;
    }

    public override bool PostPerform()
    {
        //GWorld.Instance.GetWorld().ModifyState("Waiting", -1);
        return true;
    }
}
