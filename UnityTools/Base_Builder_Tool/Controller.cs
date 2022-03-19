using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private int buildSelect;
    private int totalStructures;
    public float wheelThreshold;
    public float rotateSpeed;
    public List<string> resources;

    [System.Serializable]
    public class Structure
    {
        public GameObject phantomStructureObject;
        public GameObject structureObject;
        public int cost;

        public Structure(GameObject structureObjectPhantom, GameObject structureObject)
        {
            this.phantomStructureObject = structureObjectPhantom;
            this.structureObject = structureObject;
        }
    };

    public GameObject currentObject;
    public List<Structure> structureList;

    private void Start()
    {
        totalStructures = structureList.Count - 1;
        buildSelect = 0;
        currentObject = (GameObject)GameObject.Instantiate(structureList[buildSelect].structureObject);
        Color currentObjectTransparent = currentObject.GetComponent<SpriteRenderer>().color;
        currentObjectTransparent.a = .21f;
        currentObject.GetComponent<SpriteRenderer>().color = currentObjectTransparent;
    }
    private void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > wheelThreshold)
        {
            destroyPhantom();
            buildSelect++;
            maintainBuildSelect();
            currentObject = (GameObject)GameObject.Instantiate(structureList[buildSelect].structureObject);
            Color currentObjectTransparent = currentObject.GetComponent<SpriteRenderer>().color;
            currentObjectTransparent.a = .21f;
            currentObject.GetComponent<SpriteRenderer>().color = currentObjectTransparent;
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < -wheelThreshold)
        {
            destroyPhantom();
            buildSelect--;
            maintainBuildSelect();
            currentObject = (GameObject)GameObject.Instantiate(structureList[buildSelect].phantomStructureObject);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0.0f;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.z = 0.0f;
            Quaternion currentRotation = currentObject.GetComponent<Transform>().rotation;
            Instantiate(structureList[buildSelect].structureObject, objectPos, currentRotation);
        }

        if (Input.GetMouseButton(1))
        {
            currentObject.GetComponent<Transform>().Rotate(Vector3.back * rotateSpeed);
        }
    }

    void maintainBuildSelect()
    {
        if (buildSelect > totalStructures) buildSelect = 0;
        else if (buildSelect < 0) buildSelect = totalStructures;
    }

    void destroyPhantom()
    {
        Destroy(currentObject);
    }
}

