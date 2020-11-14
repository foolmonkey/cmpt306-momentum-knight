using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    // public Transform target;
    
    private void OnTriggerEnter2D(Collider2D collision){
       if (collision.gameObject.CompareTag("Player")){
            // code to pickup item goes here
            //    target = collision.gameObject.attachedRigidbody.Transform;
            //    Debug.Log(target);
            Debug.Log("");


       }
   }

   private void RemoveItem(){
       Destroy(gameObject);
   }
}
