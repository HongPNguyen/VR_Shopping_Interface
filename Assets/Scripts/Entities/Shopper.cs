// Script to represent a shopper (FOR TESTING ONLY!!!)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopper : MonoBehaviour
{
    public string id;
    public string givenName;
    public string familyName;
    public bool current;

    public Shopper(string id, string givenName, string familyName)
    {
        this.id = id;
        this.givenName = givenName;
        this.familyName = familyName;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetFullName()
    {
        return givenName + " " + familyName;
    }
}
