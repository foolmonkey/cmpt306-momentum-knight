using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDuplication : MonoBehaviour
{
    public Transform objectsToCreate;
    public int numRows = 1;
    public int numColumns = 1;
    public float offsetX = -1f;
    public float offsetY = -0.5f;

    void Start()
    {
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numColumns; j++)
            {
                Instantiate(objectsToCreate, new Vector3(j * offsetX - (offsetX * i), j * offsetY, 0), Quaternion.identity);
            }
        }
    }
}
