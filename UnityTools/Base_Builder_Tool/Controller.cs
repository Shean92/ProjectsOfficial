using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public bool BuildingModeEnabled = false;

    private void Start()
    {
        this.GetComponent<BuildingMode>().enabled = BuildingModeEnabled;
    }
    void Update()
    {
        if (BuildingModeEnabled == false && this.GetComponent<BuildingMode>().currentObject)
        {
            Destroy(this.GetComponent<BuildingMode>().currentObject);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            BuildingModeEnabled = !BuildingModeEnabled;
            Destroy(this.GetComponent<BuildingMode>().currentObject);
            this.GetComponent<BuildingMode>().enabled = BuildingModeEnabled;
        }
    }
}

