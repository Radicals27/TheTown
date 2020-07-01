using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class GAction : MonoBehaviour
{
    public string actionName = "Action";    //Creates the textbox "Action Name" in Unity for any action
    public float cost = 1.0f;               //Creates the textbox "Cost" in Unity for any action
    public GameObject target;               //Creates the slot for a "Target" in Unity for any action
    public string targetTag;                //Creates the slot for a "Target Tag" in Unity for any action
    public float duration = 0;              //How long the action will last
    public WorldState[] preConditions;      //Which conditions need to exist in the world for the action to happen
    public WorldState[] afterEffects;       //How the world state will change once the action is completed
    public NavMeshAgent agent;              // ?  Haven't used

    public Dictionary<string, int> preconditions;   //A dictionary holding all of the preconditions for any action
    public Dictionary<string, int> effects;         //A dictionary holding all of the effects of the action

    public WorldStates agentBeliefs;            //  ??

    public GInventory inventory;                // Sets up an inventory (list) which will become the associates agents' inventory later
    public WorldStates beliefs;                 // The beliefs of the associated agent

    public bool running = false;                //Sets up a checkbox in Unity for "Running" when the action is running

    //Constructor method that initialises the empty preconditions and effects 
    public GAction()
    {
        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
    }

    //Runs when an instance of Action is created
    public void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();  //Connects "agent" with the actual navmeshAgent component

        if (preConditions != null)                  //If there ARE preconditions (set in the Unity interface)
            foreach(WorldState w in preConditions)  //Iterate through the preConditions and
            {
                preconditions.Add(w.Key, w.value);  //Add the WORLD STATE preconditions to the preconditions of this action
            }

        if (afterEffects != null)                   //Do the same for the after effects
            foreach (WorldState w in afterEffects)
            {
                effects.Add(w.Key, w.value);
            }

        inventory = this.GetComponent<GAgent>().inventory;  //Establish the inventory of the attached agent
        beliefs = this.GetComponent<GAgent>().beliefs;      //And their beliefs
    }

    public bool isAchievable()
    {
        return true;
    }

    //Returns true if a given action is achievable based on it's conditions
    public bool isAchievableGiven(Dictionary<string, int> conditions)
    {
        foreach(KeyValuePair<string, int> p in preconditions)
        {
            if (!conditions.ContainsKey(p.Key))
                return false;
        }
        return true;
    }

    public GameObject FindClosestObject(string tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public abstract bool PrePerform();
    public abstract bool PostPerform();
}
