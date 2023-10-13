using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safezone : MonoBehaviour
{
 public GameObject craneCable;

 void OnTriggerEnter(Collider collision){
    if (collision.gameObject.name == craneCable.gameObject.name){
    crane.directionX *= -1;
    }
 }
}
