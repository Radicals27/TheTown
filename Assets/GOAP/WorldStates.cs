using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldState
{
    public string Key;      //Holds the "FreeCubicles" value for example
    public int value;       //5 free cubicles, for example
}

public class WorldStates
{
    public Dictionary<string, int> states;          //Holds all of our world states

    public WorldStates()
    {
        states = new Dictionary<string, int>();     //Stores the actual intsance of states
    }

    //Checks if a certain state exists, by it's key
    public bool HasState(string key)
    {
        return states.ContainsKey(key);
    }

    //Add a new state, given a key and value
    void AddState(string key, int value)
    {
        states.Add(key, value);
    }

    //Either modifies the value of a given state, or adds a state if it doesn't exist
    public void ModifyState(string key, int value)
    {
        if(states.ContainsKey(key))
        {
            states[key] += value;
            if(states[key] <= 0)
            {
                RemoveState(key);
            }
        }
        else
        {
            states.Add(key, value);
        }
    }

    //Removes a state
    public void RemoveState(string key)
    {
        if (states.ContainsKey(key))
        {
            states.Remove(key);
        }
    }

    //Sets a state to a hard value
    public void SetState(string key, int value)
    {
        if (states.ContainsKey(key))
            states[key] = value;
        else
            states.Add(key, value);
    }

    //Returns a list of all states
    public Dictionary<string, int> GetStates()
    {
        return states;
    }
}
