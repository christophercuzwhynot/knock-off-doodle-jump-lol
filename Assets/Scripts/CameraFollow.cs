using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Target object position
    [Header ("Target Object")]
    public Transform target;
    // Start is called before the first frame update 
    void Start()
    {
        
    }
    void Update()
    {
        //Target position on the y axis is greater
        ///than the camera position
        if (target.position.y > transform.position.y)
        {
            // the camera will follow the position of the target 
            transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);        
        }
    }
}
