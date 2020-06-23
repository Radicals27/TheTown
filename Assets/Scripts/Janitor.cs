using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor : GAgent
{
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("cleanFloor", 1, false);
        goals.Add(s1, 1);
    }
}
