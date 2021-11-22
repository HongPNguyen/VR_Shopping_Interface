using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specialty : MonoBehaviour
{
    public string id;
    public string specialtyName;
    public List<Category> categories;

    // Constructor
    public Specialty(string id, string name)
    {
        this.id = id;
        this.specialtyName = name;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Automatically assign categories
        Component[] childCategories = GetComponentsInChildren(typeof(Category));
        foreach (Category category in childCategories)
        {
            if (!categories.Contains(category))
                categories.Add(category);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
