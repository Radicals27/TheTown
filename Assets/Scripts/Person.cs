using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : GAgent
{
    [SerializeField]
    float stomach = 100.00f;

    new void Start()
    {
        base.Start();

        SubGoal s1 = new SubGoal("isFull", 1, false);
        goals.Add(s1, 9);

        InvokeRepeating("hungerDeprecate", 0, 1);

    }

    void hungerDeprecate()
    {
        stomach -= 1.0f;
        Debug.Log("Stomach: " + stomach);
    }

    private void Update()
    {
        if(stomach < 95.0f)
            beliefs.ModifyState("isHungry", 0);
    }

}
