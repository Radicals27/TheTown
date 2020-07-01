using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : GAction
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
        target = FindClosestObject("Water");

        if (target == null)
            return false;
        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeWater", -1);

        speechBubble.Speak("I'm thirsty!");

        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetQueue("waters").AddResource(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeWater", 1);
        beliefs.RemoveState("isThirsty");
        thisPerson.drink();
        return true;
    }
}
