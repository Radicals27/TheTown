using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("foods").RemoveResource();
        if (target == null)
            return false;
        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeFood", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetQueue("foods").AddResource(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeFood", 1);
        beliefs.RemoveState("isHungry");
        return true;
    }
}
