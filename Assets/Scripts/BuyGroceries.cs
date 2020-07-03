﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGroceries : GAction
{
    SpeechBubble speechBubble;
    Person thisPerson;
    Obj_Food targetFridge;

    void Start()
    {
        thisPerson = GetComponent<Person>();
        speechBubble = GetComponent<SpeechBubble>();
        targetFridge = thisPerson.myFridge;
    }

    public override bool PrePerform()
    {
        speechBubble.Speak("We need groceries...");

        return true;

    }

    public override bool PostPerform()
    {
        beliefs.RemoveState("needGroceries");
        targetFridge.quantity = 10;
        return true;
    }
}