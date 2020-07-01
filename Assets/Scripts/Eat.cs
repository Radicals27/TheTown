using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : GAction
{
    SpeechBubble speechBubble;
    Person thisPerson;
    Obj_Food thisFood;

    void Start()
    {
        thisPerson = GetComponent<Person>();
        speechBubble = GetComponent<SpeechBubble>();
    }

    public override bool PrePerform()
    {
        target = FindClosestObject("Food");
            
        if (target == null)
            return false;
        else
            thisFood = target.GetComponent<Obj_Food>();

        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeFood", -1);

        speechBubble.Speak("I'm hungry!");

        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetQueue("foods").AddResource(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeFood", 1);
        beliefs.RemoveState("isHungry");
        thisPerson.eat();
        thisFood.consume(1);
        return true;
    }

}
