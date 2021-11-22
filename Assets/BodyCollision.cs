using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    public Transform headObject; // Represents the Camera
    public Transform feetObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position = new Vector3(headObject.position.x, feetObject.position.y, headObject.position.z);
        
    }
}
