using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : GAgent
{
    private float stomach = 100.00f;
    private float hydration = 100.00f;
    private float energy = 100.00f;   //Used for sleep (0 = go to bed)

    public bool isTalking = false;   //When they enter a conversation, this is set to true
    public int MyMoney { get; set; } = 100;  //Does this need to be public or can it be private?

    GameObject myBed;
    Person thisPerson;
    SpeechBubble speechBubble;
    Animator personAnimator;
    NavMeshAgent myNavMeshAgent;

    public ConversationHandler myConversation;

    new void Start()
    {
        thisPerson = GetComponent<Person>();
        personAnimator = GetComponent<Animator>();
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        speechBubble = GetComponent<SpeechBubble>();
        myConversation = GetComponent<ConversationHandler>();

        myBed = FindClosestObject("Bed");
        if (myBed != null)
            thisPerson.inventory.AddItem(myBed);

        base.Start();

        SubGoal s1 = new SubGoal("isFull", 1, false);
        goals.Add(s1, 8);

        SubGoal s2 = new SubGoal("isHydrated", 1, false);
        goals.Add(s2, 9);

        SubGoal s3 = new SubGoal("isIdle", 1, false);
        goals.Add(s3, 1);

        SubGoal s4 = new SubGoal("hasWorked", 1, false);
        goals.Add(s4, 5);

        SubGoal s5 = new SubGoal("hasEnergy", 1, false);   //sleep goal
        goals.Add(s5, 10);

        InvokeRepeating("Entropy", 0, 1);   //Happens every 1 second
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "NPC_Collider" && !thisPerson.isTalking && !other.GetComponentInParent<Person>().isTalking)
        {
            myConversation.ManageConversation(myNavMeshAgent, other.gameObject);
        }
    }

    private void Entropy()
    {
        thisPerson.stomach -= 0.1f;
        thisPerson.hydration -= 0.2f;
        thisPerson.energy -= 15.0f;
    }

    private void Update()
    {
        if(thisPerson.stomach < 90.0f)
            beliefs.ModifyState("isHungry", 0);

        if (thisPerson.hydration < 90.0f)
            beliefs.ModifyState("isThirsty", 0);

        if (thisPerson.energy < 10.0f)
            beliefs.ModifyState("isTired", 0);

        //Start or stop walking animation when navagent is moving
        if (myNavMeshAgent.velocity.sqrMagnitude > 1.0f && !personAnimator.GetBool("isWalking"))
            personAnimator.SetBool("isWalking", true);
        else if (myNavMeshAgent.velocity.sqrMagnitude < 1.0f && personAnimator.GetBool("isWalking"))
            personAnimator.SetBool("isWalking", false);
    }

    public void eat()
    {
        thisPerson.stomach = 100.0f;
    }

    public void drink()
    {
        thisPerson.hydration = 100.0f;
    }

    public void sleep()
    {
        thisPerson.energy = 100.0f;
    }

}
