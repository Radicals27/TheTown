using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseToilet : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetQueue("toilets").RemoveResource();
        if (target == null)
            return false;
        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeToilet", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetQueue("toilets").AddResource(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeToilet", 1);
        beliefs.RemoveState("busting");
        return true;
    }
}
