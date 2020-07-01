using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GInventory
{
    public List<GameObject> items = new List<GameObject>();     //A list called "items" which is made up of game Objects

    //Adds a game object to "items"
    public void AddItem(GameObject i)
    {
        items.Add(i);
    }

    //returns a gameobject matching a given tag, from 'items'
    public GameObject FindItemWithTag(string tag)
    {
        foreach(GameObject i in items)
        {
            if (i == null) break;   //required in case we delete a target object while someone has it in their infventory

            if (i.tag == tag)
                return i;
        }
        return null;
    }

    //Removes a given game object from 'items'
    public void RemoveItem(GameObject i)
    {
        int indexToRemove = -1;
        foreach(GameObject g in items)
        {
            indexToRemove++;
            if (g == i)
                break;
        }
        if (indexToRemove >= -1)
            items.RemoveAt(indexToRemove);
    }
}
