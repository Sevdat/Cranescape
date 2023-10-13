using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winBoxTrigge : MonoBehaviour
{
    public GameObject forklift;
void OnTriggerEnter(Collider collision){
        if (collision.gameObject.name == forklift.gameObject.name){
   boxTrigger.stayWithBox = true;
    }
}
}
