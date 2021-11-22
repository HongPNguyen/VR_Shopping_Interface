using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Category : MonoBehaviour
{
    public string id;
    public string categoryName;
    public List<Item> items;
    public Specialty specialty;

    // Constructor
    public Category(string id, string name)
    {
        this.id = id;
        this.categoryName = name;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Automatically assign specialty
        if (transform.parent.GetComponent<Specialty>() != null)
        {
            specialty = transform.parent.GetComponent<Specialty>();
        }
        // Automatically assign items
        Component[] childItems = GetComponentsInChildren(typeof(Item));
        foreach (Item item in childItems)
        {
            if(!items.Contains(item))
                items.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Check if specialty assignment is consistent with the specialty's data
    public void AddToSpecialty()
    {
        if (specialty != null && !specialty.categories.Contains(this))
            specialty.categories.Add(this);
    }
}
