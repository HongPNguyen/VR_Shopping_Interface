using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string id;
    public string itemName;
    public string unit;
    public float unitPrice;
    public string imageFolder;
    public string videoUrl;
    [TextArea]
    public string description;
    public Category category;

    // Constructor
    public Item(string id, string name, string unit, float unitPrice)
    {
        this.id = id;
        this.itemName = name;
        this.unit = unit;
        this.unitPrice = unitPrice;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Automatically assign category
        if (transform.parent.GetComponent<Category>() != null)
        {
            category = transform.parent.GetComponent<Category>();
        }
        // If image folder name is not specified, default to folder with item name
        if (imageFolder == null || imageFolder == "")
        {
            imageFolder = itemName;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Check if category assignment is consistent with the category's data
    public void AddToCategory()
    {
        if (category != null && !category.items.Contains(this))
            category.items.Add(this);
    }
}
