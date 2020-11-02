using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowObject : MonoBehaviour
{
    // Camera where UI will be positioned
    private Camera aCamera;

    // Positions to offset the UI element
    [SerializeField] public Transform objectToFollow;
    [SerializeField] public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        aCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = aCamera.WorldToScreenPoint(objectToFollow.position + offset);
        
        if(transform.position != pos){
            transform.position = pos;
        }
    }
}
