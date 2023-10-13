using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject winZone;
    public GameObject forkliftDetection;
    public GameObject stayAtCoordinate;
    public static bool stayWithBox = true;
    
    void OnTriggerEnter(Collider collision){
    if (collision.gameObject.name == winZone.gameObject.name){
    stayWithBox = false;
    timer.boxOut = true;
    transform.position = crane.boxStart;
    }
    }
    void OnTriggerStay(Collider collision){
    if (collision.gameObject.name == forkliftDetection.gameObject.name && stayWithBox == true){
        transform.position = stayAtCoordinate.transform.position;
    }
    }
}
