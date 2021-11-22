using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    public string id;
    protected string date;
    protected string time;
    protected float totalPrice = 0;
    protected Payment paymentSrc;
    protected string shopperId;
    protected Item[] items;
    protected float[] quantities; // Item and quantity index should always be aligned

    public Purchase(string shopperId)
    {
        this.shopperId = shopperId;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item[] GetItems()
    {
        return items;
    }

    public float[] GetQuantities()
    {
        return quantities;
    }
}
