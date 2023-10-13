using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unsafeZone : MonoBehaviour
{
 public GameObject forklift;
 public GameObject cable;

 void OnTriggerStay(Collider collision){
    if (collision.gameObject.name == forklift.gameObject.name){
    crane.inZone = true;
    }
   if (collision.gameObject.name == cable.gameObject.name){
    crane.cableInZone = true;
    }
 }
 void OnTriggerExit(Collider collision){
    if (collision.gameObject.name == forklift.gameObject.name){
    crane.inZone = false;
    }
   if (collision.gameObject.name == cable.gameObject.name){
     crane.cableInZone = false;
    }
 }
}
