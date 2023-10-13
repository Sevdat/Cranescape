using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walls : MonoBehaviour
{
 public GameObject craneCable;

 void OnTriggerEnter(Collider collision){
    if (collision.gameObject.name == craneCable.gameObject.name){
    crane.directionZ *= -1;
    }
 }

}
