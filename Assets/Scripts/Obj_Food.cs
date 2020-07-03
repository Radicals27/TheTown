using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Food : MonoBehaviour
{
    [SerializeField]
    public int quantity;

    public bool consume(int amount)
    {
        if (quantity == 0 || quantity - amount < 0)
            return false;
        else
            quantity -= amount;

        return true;
    }
}
