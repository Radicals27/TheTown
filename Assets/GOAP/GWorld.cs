using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceQueue
{
    public Queue<GameObject> que = new Queue<GameObject>();
    public string tag;
    public string modState;

    public ResourceQueue(string t, string ms, WorldStates w)
    {
        tag = t;
        modState = ms;
        if(tag != "")
        {
            GameObject[] resources = GameObject.FindGameObjectsWithTag(tag);
            foreach(GameObject r in resources)
                que.Enqueue(r);
        }
        if(modState != "")
        {
            w.ModifyState(modState, que.Count);
        }
    }
    public void AddResource(GameObject r)
    {
        que.Enqueue(r);
    }

    public void RemoveResource(GameObject r)
    {
        que = new Queue<GameObject>(que.Where(p => p != r));
    }

    public GameObject RemoveResource()
    {
        if (que.Count == 0) return null;
        return que.Dequeue();
    }
}

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static ResourceQueue patients;
    private static ResourceQueue cubicles;
    private static ResourceQueue offices;
    private static ResourceQueue toilets;
    private static ResourceQueue puddles;
    private static ResourceQueue foods;
    private static Dictionary<string, ResourceQueue> resources = new Dictionary<string, ResourceQueue>();

    static GWorld()
    {
        world = new WorldStates();

        patients = new ResourceQueue("","",world);
        resources.Add("patients", patients);

        cubicles = new ResourceQueue("Cubicle", "FreeCubicle", world);
        resources.Add("cubicles", cubicles);

        offices = new ResourceQueue("Office", "FreeOffice", world);
        resources.Add("offices", offices);

        toilets = new ResourceQueue("Toilet", "FreeToilet", world);
        resources.Add("toilets", toilets);

        puddles = new ResourceQueue("Puddle", "FreePuddle", world);
        resources.Add("puddles", puddles);

        foods = new ResourceQueue("Food", "FreeFood", world);
        resources.Add("foods", foods);

        //Time.timeScale = 5;    //Speeds up time
    }

    public ResourceQueue GetQueue(string type)
    {
        return resources[type];
    }

    private GWorld()
    {
    }

    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }

}