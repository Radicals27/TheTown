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

    //NEED to redo this class - find closest food item that has QUANTITY > 0!
    public override bool PrePerform()
    {
        target = FindClosestFood();

        if (target == null)
        {
            speechBubble.Speak("******No food!*****");
            return false;
        }
        else
            thisFood = target.GetComponent<Obj_Food>();

        inventory.AddItem(target);

        speechBubble.Speak("I'm hungry!");

        return true;
    }

    public override bool PostPerform()
    {
        inventory.RemoveItem(target);

        beliefs.RemoveState("isHungry");
        thisPerson.eat();

        thisFood.consume(1);
        return true;
    }

}
