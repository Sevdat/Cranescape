using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crane : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject forklift;
    public static Vector3 forkliftStart;
    public GameObject craneBody;
    public static Vector3 craneBodyStart;
    public GameObject cart;
    public static Vector3 cartStart;
    public GameObject cable;
    public GameObject box;
    public static Vector3 boxStart;
    public static Vector3 cableStart;
    public static float directionX = 1f;
    public static float directionZ = 1f;
    public static float speedX = 5;
    public static float speedZ = 5;
    public static bool inZone = false;
    public static bool cableInZone = true;
    float boundryX = 0.03f;
    float boundryZ = 0.03f;
    
    void movementXZ(GameObject craneBody, GameObject cart,GameObject cable, float speedX, float speedZ){
        craneBody.GetComponent<Rigidbody>().velocity = new Vector3(speedX*directionX, 0,0);
        cart.GetComponent<Rigidbody>().velocity = new Vector3(speedX*directionX, 0,speedZ*directionZ);
        cable.GetComponent<Rigidbody>().velocity = new Vector3(speedX*directionX, 0, speedZ*directionZ);
    }

    void positionTracker(GameObject forklift, GameObject cable){
    Vector3 forkPos = forklift.transform.position;
    Vector3 cablePos = cable.transform.position;
    float disX = forkPos.x - cablePos.x;
    float disZ = forkPos.z - cablePos.z;
    float vecX = Mathf.Clamp((disX)*40,-speedX,speedX);
    float vecZ = Mathf.Clamp((disZ)*40,-speedZ,speedZ);
    if (!cableInZone){
        directionX = 1;
        directionZ = 1;
    }
    movementXZ(craneBody,cart,cable,vecX,vecZ);
    }
    
    void Start()
    {
     craneBodyStart = craneBody.GetComponent<Rigidbody>().transform.position;
     cartStart = cart.transform.GetComponent<Rigidbody>().position;
     cableStart = cable.GetComponent<Rigidbody>().transform.position;  
     forkliftStart = forklift.transform.position;
     boxStart = box.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inZone){
            positionTracker(forklift,cable);
            // Time.time = 0;
        } else { 
        movementXZ(craneBody,cart,cable,speedX,speedZ);
        }
        
    }

}

    // void movementX(GameObject craneBody, float speedX){
    //     craneBody.GetComponent<Rigidbody>().MovePosition(
    //         craneBody.transform.position + new Vector3(speedX*directionX, 0,0) * Time.deltaTime
    //         );
    // }
    // void movementXZ(GameObject cart,GameObject cable, float speedX, float speedZ){

    //     cart.GetComponent<Rigidbody>().MovePosition(
    //         cart.transform.position + new Vector3(speedX*directionX, 0,speedZ*directionZ) * Time.deltaTime
    //     );
    //     cable.GetComponent<Rigidbody>().MovePosition(
    //         cable.transform.position + new Vector3(speedX*directionX, 0, speedZ*directionZ) * Time.deltaTime
    //     );
    //     movementX(craneBody,speedX);
    // }


//         void movementY(float vecY){
//        if (vecY > boundryY) forwardOrBackward(craneVertical,directionY); else 
//        if (vecY < -boundryY) {
//         forwardOrBackward(craneVertical,-directionY);
//         speedY = -1f;
//         }
//     }
//     void movementX(float vecX){
//        if (vecX > boundryX) leftOrRight(craneHorizontal,directionX); else 
//        if (vecX < -boundryX) {
//         leftOrRight(craneHorizontal,-directionX);
//         speedX = -1f;
//         }
//     }

//     void positionTracker(GameObject forklift, GameObject craneCable){
//         Vector3 fork = forklift.transform.position;
//         Vector3 crane = craneCable.transform.position;
//         float vecY = (fork.x - crane.x);
//         float vecX = (fork.z - crane.z);
// speedY = 1f;
// speedX = 1f;
//        if (!rackGroupY && !rackGroupX) {
//         movementY(vecY);
//         movementX(vecX);
//         } else if (rackGroupX) {
//             leftOrRight(craneHorizontal,directionX);
//         } else if (rackGroupY) {
//             forwardOrBackward(craneVertical,directionY);
//         }
//     }