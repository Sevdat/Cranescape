using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class forkliftMovement : MonoBehaviour
{
        // Start is called before the first frame update
    public GameObject forkLiftMovement;
    Rigidbody forkliftRigid;
    public Camera cam;
    public CinemachineFreeLook cinemachineCam;

    // Update is called once per frame
    float xLimit = 2.3f;
    float zLimit = 2.5f;
    float speed = 0.5f;
    float currentPointX = 0;
    float currentPointY = 0;
    bool changePoint = false;
    float moveX = 0;
    
void Start(){
    forkliftRigid = forkLiftMovement.GetComponent<Rigidbody>();
}

void LateUpdate(){
     forkliftRigid.MoveRotation(
        Quaternion.Slerp(
            forkliftRigid.transform.rotation, 
            Quaternion.AngleAxis(cam.transform.eulerAngles.y + 2.5f*moveX, Vector3.up), 
            speed
        )
    ); 
}
    
    void FixedUpdate(){
        
        Rigidbody forkliftRigid = forkLiftMovement.GetComponent<Rigidbody>();
        Vector3 forkliftVelocity = forkliftRigid.velocity;
if (Input.touchCount > 0) {
	Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
	if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) 
	{
        if (changePoint == false) {
            currentPointX = touch.position.x;
            currentPointY = touch.position.y;
            }
        moveX = Mathf.Clamp(5f*(touch.position.x - currentPointX)/Screen.width, -xLimit,xLimit); 
        float moveY = Mathf.Clamp(70*(touch.position.y - currentPointY)/Screen.height, -zLimit,zLimit);
        if (Mathf.Abs(moveX) > 0.005f) cinemachineCam.m_XAxis.Value += moveX; 
        if (Mathf.Abs(moveY) > 0.005f) forkliftRigid.velocity = transform.forward * moveY;  
        changePoint = true;
	}
} else {
    changePoint = false;
    moveX = 0;
    
}
        

    }

}
