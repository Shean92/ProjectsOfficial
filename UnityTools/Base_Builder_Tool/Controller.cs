using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private int buildSelect;
    private int totalStructures;
    public float wheelThreshold;
    public float rotateSpeed;
    public float transparency;
    public List<string> resources;

    [System.Serializable]
    public class Structure
    {
        public GameObject structureObject;
        public int cost;

        public Structure(GameObject structureObject)
        {
            this.structureObject = structureObject;
        }
    };

    public GameObject currentObject;
    public List<Structure> structureList;

    private void Start()
    {
        totalStructures = structureList.Count - 1;
        buildSelect = 0;
        MakePhantom();
    }
    private void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > wheelThreshold)
        {
            DestroyPhantom();
            buildSelect++;
            MaintainBuildSelect();
            MakePhantom();
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < -wheelThreshold)
        {
            DestroyPhantom();
            buildSelect--;
            MaintainBuildSelect();
            MakePhantom();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0.0f;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.z = 0.0f;
            Quaternion currentRotation = currentObject.GetComponent<Transform>().rotation;
            PlaceStructure(objectPos, currentRotation);
        }

        if (Input.GetMouseButton(1))
        {
            currentObject.GetComponent<Transform>().Rotate(Vector3.back * rotateSpeed);
        }
    }

    void MaintainBuildSelect()
    {
        if (buildSelect > totalStructures) buildSelect = 0;
        else if (buildSelect < 0) buildSelect = totalStructures;
    }

    void PlaceStructure(Vector3 objectPos, Quaternion currentRotation)
    {
        Instantiate(structureList[buildSelect].structureObject, objectPos, currentRotation);
    }

    void MakePhantom()
    {
        currentObject = (GameObject)GameObject.Instantiate(structureList[buildSelect].structureObject);
        Color currentObjectTransparent = currentObject.GetComponent<SpriteRenderer>().color;
        currentObjectTransparent.a = transparency;
        currentObject.GetComponent<SpriteRenderer>().color = currentObjectTransparent;
        currentObject.GetComponent<PhantomStructure>().enabled = true;
    }

    void DestroyPhantom()
    {
        Destroy(currentObject);
    }
}

