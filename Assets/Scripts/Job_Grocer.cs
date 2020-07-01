using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Job_Grocer : GAction
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
        speechBubble.Speak("I'm stacking shelves!");
        personAnimator.SetBool("isWorking", true);
        return true;
    }

    public override bool PostPerform()
    {
        personAnimator.SetBool("isWorking", false);
        thisPerson.MyMoney += 10;
        return true;
    }
}
