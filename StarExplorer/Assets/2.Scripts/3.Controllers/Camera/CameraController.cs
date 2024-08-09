using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offsetPosition;
    public Transform target;
    public float SmoothSpeed;
   

    
    void LateUpdate()
    {
        FollowCamera();   
    }

    void FollowCamera()
    {

        Vector3 pos = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * SmoothSpeed);
        transform.position = new Vector3(pos.x, pos.y,offsetPosition.z);
    }
}
