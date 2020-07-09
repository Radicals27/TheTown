using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sleep : GAction
{
    SpeechBubble speechBubble;
    Person thisPerson;
    NavMeshAgent myNavMeshAgent;
    Animator personAnimator;

    void Start()
    {
        thisPerson = GetComponent<Person>();
        speechBubble = GetComponent<SpeechBubble>();
        personAnimator = GetComponent<Animator>();
        myNavMeshAgent = thisPerson.GetComponent<NavMeshAgent>();
    }

    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Bed");
        speechBubble.Speak("Zzzzzzzz...");
        personAnimator.SetBool("isSleeping", true);

        thisPerson.transform.rotation = target.transform.rotation;   //match rotation of bed
        thisPerson.transform.rotation *= Quaternion.Euler(0, 90f, 0);

        return true;
    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("isTired");
        thisPerson.sleep();
        personAnimator.SetBool("isSleeping", false);
        return true;
    }
}
