using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRTouchSample;
namespace OculusSampleFramework
{
    public class playerDetect : OVRGrabbable
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "PlayerController")
            {

            }
        }
    }
}