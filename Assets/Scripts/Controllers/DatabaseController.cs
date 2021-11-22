using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseController : MonoBehaviour
{
    public List<Item> items; // TEMPORARILY PUBLIC FOR TESTING, PROTECTED RECOMMENDED.
    public List<Specialty> specialties;
    public List<Category> categories;
    protected List<Shopper> shoppers;
    protected List<Manager> managers;
    protected Manager currentManager;
    protected string activeShopperId = "1";
    public bool initializationDone = false;

    // Start is called before the first frame update
    void Awake()
    {
        // Initialize existing data
        Component[] childSpecialties = GetComponentsInChildren(typeof(Specialty));
        Component[] childCategories = GetComponentsInChildren(typeof(Category));
        Component[] childItems = GetComponentsInChildren(typeof(Item));
        foreach (Specialty specialty in childSpecialties)
        {
            if (!specialties.Contains(specialty))
                specialties.Add(specialty);
        }
        foreach (Category category in childCategories)
        {
            if (!categories.Contains(category))
                categories.Add(category);
        }
        foreach (Item item in childItems)
        {
            if (!items.Contains(item))
                items.Add(item);
        }
        initializationDone = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Add a new specialty
    public void AddSpecialty(string id, string name)
    {
        foreach (Specialty s in specialties)
        {
            if (s.id == id)
            {
                Debug.Log("Specialty already exists!");
                return;
            }
        }
        specialties.Add(new Specialty(id, name));
    }

    // Add a new category and assign it to an existing specialty
    public void AddCategory(string id, string name, string specialtyId)
    {
        foreach (Category c in categories)
        {
            if (c.id == id)
            {
                Debug.Log("Category already exists!");
                return;
            }
        }
        Category newCategory = new Category(id, name);
        bool warning = true;
        foreach (Specialty s in specialties)
        {
            if (s.id == specialtyId)
            {
                newCategory.specialty = s;
                newCategory.AddToSpecialty();
                warning = false;
                break;
            }
        }
        if (warning)
            Debug.Log("WARNING: Newly added category " + name + " does not belong to a specialty!");
        categories.Add(newCategory);
    }

    // Add a new item type and assign it a category
    public void AddItem(string id, string name, string unit, float unitPrice, string categoryId)
    {
        foreach (Item i in items)
        {
            if (i.id == id)
            {
                Debug.Log("Item type already exists!");
                return;
            }
        }
        Item newItem = new Item(id, name, unit, unitPrice);
        bool warning = true;
        foreach (Category c in categories)
        {
            if (c.id == categoryId)
            {
                newItem.category = c;
                warning = false;
                break;
            }
        }
        if (warning)
            Debug.Log("WARNING: Newly added item " + name + " does not belong to a category!");
        items.Add(newItem);
    }

    // Modify an item type
    public void ModifyItem(string id, string name = "", string unit = "", float unitPrice = -1, string categoryName = "")
    {
        foreach (Item i in items)
        {
            if (i.id == id)
            {
                if (name != "" && i.itemName != name)
                    i.itemName = name;
                if (unit != "" && i.unit != unit)
                    i.unit = unit;
                if (unitPrice != -1 && i.unitPrice != unitPrice)
                    i.unitPrice = unitPrice;
                bool warning = true;
                foreach (Category c in categories)
                {
                    if (categoryName != "" && c.categoryName == categoryName)
                    {
                        i.category = c;
                        warning = false;
                        break;
                    }
                }
                if (warning)
                    Debug.Log("WARNING: Newly modified item " + name + " does not belong to a category!");
                return;
            }
        }
        Debug.Log("Item " + name + " not found.");
        return;
    }

    public void RemoveItem(string itemId)
    {
        foreach (Item i in items)
        {
            if (i.id == itemId)
            {
                items.Remove(i);
                return;
            }
        }
        return;
    }

    public List<Specialty> GetSpecialties()
    {
        return specialties;
    }

    public Item FindItem(string itemId)
    {
        foreach (Item item in items)
        {
            if (item.id == itemId)
                return item;
        }
        return null;
    }

    public Specialty FindSpecialty(string specialtyId)
    {
        foreach (Specialty specialty in specialties)
        {
            if (specialty.id == specialtyId)
                return specialty;
        }
        return null;
    }

    public Category FindCategory(string categoryId)
    {
        foreach (Category category in categories)
        {
            if (category.id == categoryId)
                return category;
        }
        return null;
    }

    // Find a shopper
    public Shopper FindShopper(string shopperId)
    {
        foreach (Shopper shopper in shoppers)
        {
            if (shopper.id == shopperId)
                return shopper;
        }
        return null;
    }

    // Add a new shopper
    public void AddShopper(string id, string givenName, string familyName)
    {
        foreach (Shopper s in shoppers)
        {
            if (s.id == id)
            {
                Debug.Log("Shopper already exists!");
                return;
            }
        }
        shoppers.Add(new Shopper(id, givenName, familyName));
    }

    // Get current shopper's ID
    public string GetActiveShopperId()
    {
        return activeShopperId;
    }
}
