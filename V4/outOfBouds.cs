using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outOfBouds : MonoBehaviour
{
    public GameObject fork;
    public GameObject craneBody;
    public GameObject craneCart;
    public GameObject craneCable;
void OnTriggerEnter(Collider collision){
    if (collision.gameObject.name == fork.gameObject.name){
        fork.transform.position = crane.forkliftStart;
    }
}
void OnTriggerExit(Collider collision){
    if (collision.gameObject.name == craneCable.gameObject.name){
     craneBody.GetComponent<Rigidbody>().transform.position = crane.craneBodyStart;
     craneCart.GetComponent<Rigidbody>().transform.position = crane.cartStart;
     craneCable.GetComponent<Rigidbody>().transform.position = crane.cableStart; 
    }
}
}
