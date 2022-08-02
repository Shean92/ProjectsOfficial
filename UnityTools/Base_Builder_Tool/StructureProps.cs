using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureProps : MonoBehaviour
{
    public int health;
    public GameObject[] resources;
    public int[] costs;

    void Start()
    {
        resources = GameObject.FindGameObjectsWithTag("Resources");
    }

    public bool PayCost()
    {
        int i = 0;
        foreach (GameObject resource in resources)
        {
            int resourceAmount = resource.GetComponent<ResourceProps>().amount;
            if (resourceAmount < costs[i])
            {
                return false;
            }
            resourceAmount -= costs[i];
            i++;
        }
        return true;
    }
}
