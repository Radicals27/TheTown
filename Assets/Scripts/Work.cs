using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Work : GAction
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
        speechBubble.Speak("I'm working.");
        personAnimator.SetBool("isWorking", true);
        return true;
    }

    public override bool PostPerform()
    {
        personAnimator.SetBool("isWorking", false);
        return true;
    }
}
