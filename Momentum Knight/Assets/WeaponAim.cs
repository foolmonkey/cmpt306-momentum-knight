using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    [SerializeField]
    private Transform weaponTransform;
    [SerializeField]
    private Transform playerCurrentPosition;

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);

        //up and to the right
        if (inputVector == new Vector2(1, 1))
        {
            weaponTransform.position = playerCurrentPosition.position + new Vector3(0.4f, -0.4f, 0);
            weaponTransform.rotation = Quaternion.Euler(0, 0, 260f);
        } 
        //move down and to the left
        else if (inputVector == new Vector2(-1, -1))
        {
            weaponTransform.position = playerCurrentPosition.position + new Vector3(0, -0.5f, 0);
            weaponTransform.rotation = Quaternion.Euler(0, 0, 45f);
        }
        //move down and to the right
        else if (inputVector == new Vector2(1, -1))
        {
            weaponTransform.position = playerCurrentPosition.position + new Vector3(0, -0.5f, 0);
            weaponTransform.rotation = Quaternion.Euler(0, 0, 190f);
        }
        //move up and to the left
        else if (inputVector == new Vector2(-1, 1))
        {
            weaponTransform.position = playerCurrentPosition.position + new Vector3(-0.4f, -0.4f, 0);
            weaponTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //move to the left
        else if (inputVector == new Vector2(-1, 0))
        {
            weaponTransform.position = playerCurrentPosition.position + new Vector3(-0.1f, -0.5f, 0);
            weaponTransform.rotation = Quaternion.Euler(0, 0, 45f);
        }
        //move up
        else if (inputVector == new Vector2(0, 1))
        {
            weaponTransform.position = playerCurrentPosition.position + new Vector3(-0.3f, -0.2f, 0);
            weaponTransform.rotation = Quaternion.Euler(0, 0, 320f);
        }
        //move right
        else if (inputVector == new Vector2(1, 0))
        {
            weaponTransform.position = playerCurrentPosition.position + new Vector3(0.1f, -0.5f, 0);
            weaponTransform.rotation = Quaternion.Euler(0, 0, 220f);
        }
        //move down
        else if (inputVector == new Vector2(0, -1))
        {
            weaponTransform.position = playerCurrentPosition.position + new Vector3(-0.3f, -0.5f, 0);
            weaponTransform.rotation = Quaternion.Euler(0, 0, 130f);

        }
    }
}
