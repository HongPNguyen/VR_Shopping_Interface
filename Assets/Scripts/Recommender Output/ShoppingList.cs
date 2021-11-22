using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingList : MonoBehaviour
{
    public string id;
    public System.DateTime date;
    public System.TimeSpan time;
    public string dateTimeStr;
    public bool current;
    protected string shopperId;
    [SerializeField]
    protected List<Item> items;
    [SerializeField]
    protected List<float> quantities;

    // Constructor based on shopper ID
    public ShoppingList(string shopperId)
    {
        this.shopperId = shopperId;
        if (items == null)
        {
            items = new List<Item>();
        }
        if (quantities == null)
        {
            quantities = new List<float>();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        // FOR TESTING
        if (dateTimeStr != null)
        {
            date = System.DateTime.Parse(dateTimeStr);
            time = date.TimeOfDay;
        }
        if (items == null)
            items = new List<Item>();
        if (quantities == null)
            quantities = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCurrent(bool current)
    {
        this.current = current;
    }

    public void AddItem(Item item, float quantity)
    {
        // Check if item is already in list
        int index = items.FindIndex(i => i.id == item.id);
        // If exists, simply increment the quantity
        if (index >= 0)
        {
            quantities[index] += quantity;
        }
        // Else add item to list
        else
        {
            items.Add(item);
            quantities.Add(quantity);
        }
    }

    public void RemoveItem(Item item, float quantity)
    {
        items.Remove(item);
        quantities.Remove(quantity);
    }

    public void Clear()
    {
        items.Clear();
        quantities.Clear();
    }

    public string GetShopper()
    {
        return shopperId;
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public List<float> GetQuantities()
    {
        return quantities;
    }
}
