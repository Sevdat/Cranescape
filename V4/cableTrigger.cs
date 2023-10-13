using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cableTrigger : MonoBehaviour
{
    public GameObject forklift;
    public GameObject box;
    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.tag == "rackZ"){
           if (Random.Range(-2,2)> 0) crane.directionZ *= -1; else crane.directionX *= -1;
        };
        if (collision.gameObject.tag == "rackX"){
            if (Random.Range(-2,2)> 0) crane.directionX *= -1; else crane.directionZ *= -1;
        };
        if(collision.gameObject.name == forklift.gameObject.name || collision.gameObject.name == box.gameObject.name){
            boxTrigger.stayWithBox = false;
            box.transform.position = crane.boxStart;
            forklift.transform.position = crane.forkliftStart;
            timer.timeCount = 0;
        }

    }
}
