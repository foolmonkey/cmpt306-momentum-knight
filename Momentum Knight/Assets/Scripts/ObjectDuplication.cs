using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDuplication : MonoBehaviour
{
    public Transform objectsToCreate;
    public Transform parent;
    public int numRows = 1;
    public int numColumns = 1;
    public float offset = 0.5f;
    private float offsetY;

    void Start()
    {
        offsetY = offset / 2f;
        if (!parent)
        {
            parent = objectsToCreate.parent;
        }

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numColumns; j++)
            {
                Instantiate(objectsToCreate, new Vector3((j * offset) + (i * offset), (j * offsetY) - (i * offsetY), 0), Quaternion.identity, parent);
            }
        }
    }
}
