using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Food : MonoBehaviour
{
    public GameObject purchaser;
    public GameObject foodPrefab;
    public int quantity;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(foodPrefab, this.transform.position, Quaternion.identity);
    }

    public void SpawnFood(Person targetPerson)
    {
        Instantiate(foodPrefab, targetPerson.transform.position, Quaternion.identity);
    }
}
