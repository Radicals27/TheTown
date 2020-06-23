using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : GAgent
{
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("treatPatient", 1, false);
        goals.Add(s1, 3);

        SubGoal s2 = new SubGoal("rested", 1, false);
        goals.Add(s2, 1);

        SubGoal s3 = new SubGoal("relieved", 1, false);
        goals.Add(s3, 5);

        Invoke("GetTired", Random.Range(10, 20));
        Invoke("NeedRelief", Random.Range(10, 20));
    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(10, 20));
    }

    void NeedRelief()
    {
        beliefs.ModifyState("busting", 0);
        Invoke("NeedRelief", Random.Range(10, 20));
    }

}
