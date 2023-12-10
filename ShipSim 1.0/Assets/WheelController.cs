//************************************************************
//this is a rudder wheel script for control the wheel        *
//the max limt is two turns on both sides                    *
//finished on 2023-12-10                                     *
//by tech26z                                                 *
//************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour {

    float ho;                       //controlled by key arrow key, left/right
    float speed = 70.0f;            //control the wheel angular speed
    Quaternion currentRotation;     //position of the wheel
    Quaternion lastRotation;        //same as above 
    float rotationCount;            //total wheel turning angle


    // Use this for initialization
    void Start () {

        Debug.Log(lastRotation.z);
    }
	
	// Update is called once per frame
	void Update () {

        ho = Input.GetAxis("Horizontal");      
        Quaternion currentRotation = transform.rotation;
        //find the absolute difference, if you remove the Mathf.Abs, you get the same result
        float rotationChange = Mathf.Abs(Quaternion.Angle(lastRotation, currentRotation)); 

        if (ho < 0 && rotationCount < 900)
        {
            //turning the wheel by keyboard, this part limit the max port turning to 720°，two revs
            transform.Rotate(Vector3.forward, -speed * Time.deltaTime * ho);

            rotationCount += rotationChange;
            lastRotation = currentRotation;
            Debug.Log(rotationCount - 180);
        }
        else if (ho > 0 && rotationCount > -540)
        {
            //same as above but limit the max of starboard turn
            transform.Rotate(Vector3.forward, -speed * Time.deltaTime * ho);

            rotationCount -= rotationChange;
            lastRotation = currentRotation;
            Debug.Log(rotationCount - 180);
        }
        else
        {

        }
    }

}
