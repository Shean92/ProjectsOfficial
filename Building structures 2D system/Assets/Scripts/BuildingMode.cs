using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMode : MonoBehaviour
{

    private int buildSelect;
    private int totalStructures;
    public float rotateSpeed;
    public float transparency;

    public GameObject currentObject;
    public List<GameObject> structureList;

    private void Start()
    {
        totalStructures = structureList.Count - 1;
        buildSelect = 0;
    }

    private void OnEnable()
    {
        MakePhantom();
    }
    private void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            Destroy(currentObject);
            buildSelect++;
            MaintainBuildSelect();
            MakePhantom();
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            Destroy(currentObject);
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
        if (currentObject.GetComponent<StructureProps>().PayCost())
        {
            Instantiate(structureList[buildSelect], objectPos, currentRotation);
        }
        else
        {
            Debug.Log("Not enough resources");
        }
    }

    void MakePhantom()
    {
        currentObject = (GameObject)GameObject.Instantiate(structureList[buildSelect]);
        currentObject.GetComponent<Collider2D>().enabled = false;
        Color currentObjectTransparent = currentObject.GetComponent<SpriteRenderer>().color;
        currentObjectTransparent.a = transparency;
        currentObject.GetComponent<SpriteRenderer>().color = currentObjectTransparent;
        currentObject.GetComponent<PhantomStructure>().enabled = true;
    }
}

