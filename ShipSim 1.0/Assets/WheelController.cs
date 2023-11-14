using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour {

    float ho;
    
	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {

        ho = Input.GetAxis("Horizontal");
        
        transform.Rotate(0, -1 * ho, 0 );
	}
}
