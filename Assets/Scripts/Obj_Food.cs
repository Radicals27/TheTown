using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Food : MonoBehaviour
{
    [SerializeField]
    public int quantity;

    public GameObject foodObject;

    public void consume(int amount)
    {
        if (quantity - amount <= 0)
            Destroy(foodObject);
        else
            quantity -= amount;
        Debug.Log("Definitely eaten 1 Food");
    }
}
