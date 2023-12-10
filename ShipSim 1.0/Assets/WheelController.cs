using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour {

    float ho;
    float speed = 70.0f;
    Quaternion currentRotation;
    Quaternion lastRotation;
    float rotationCount;


    // Use this for initialization
    void Start () {

        Debug.Log(lastRotation.z);
    }
	
	// Update is called once per frame
	void Update () {

        ho = Input.GetAxis("Horizontal");      
        Quaternion currentRotation = transform.rotation;
        float rotationChange = Mathf.Abs(Quaternion.Angle(lastRotation, currentRotation));

        //这里的问题是，ho在从-1向正1过渡的时候，有一个短暂的时间还是在正的-0.0x的位置上，
        //所以负数的角度还在增加，直到ho变为正值，程序才会转换if block。用Mathf.FloorToInt()
        //问题依旧
        /*
        if (ho < 0 && rotationCount < 540)
        {
            transform.Rotate(Vector3.forward, -speed * Time.deltaTime * ho);

            rotationCount += rotationChange;
            lastRotation = currentRotation;
            Debug.Log(rotationCount - 180);
        }
        else if (ho > 0 && rotationCount > -540)
        {
            transform.Rotate(Vector3.forward, -speed * Time.deltaTime * ho);
            
            rotationCount -= rotationChange;
            lastRotation = currentRotation;
            Debug.Log(rotationCount - 180);
        }
        else
        {
            
        }
        */
        //下面这段对了。为什么对，也不清楚，反正能正负旋转720°了！
        //左右各转两圈限位
        if (ho < 0 && rotationCount < 900)
        {
            transform.Rotate(Vector3.forward, -speed * Time.deltaTime * ho);

            rotationCount += rotationChange;
            lastRotation = currentRotation;
            Debug.Log(rotationCount - 180);
        }
        else if (ho > 0 && rotationCount > -540)
        {
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
