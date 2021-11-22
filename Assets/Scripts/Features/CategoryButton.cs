using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CategoryButton : MonoBehaviour
{
    // Specialty associated with button.
    // PUBLIC FOR DEBUG ONLY!!!
    protected Category category;
    [SerializeField]
    protected GameObject buttonTemplate; // Sample ITEM button with image for template.
    [SerializeField]
    protected GameObject itemMenu; // Sample ITEM menu for template.

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCategory(Category c)
    {
        this.category = c;
    }

    public void GenerateItemMenu()
    {
        Debug.Log("Click success");
        // Create item menu
        if (!itemMenu.gameObject.activeSelf)
            itemMenu.gameObject.SetActive(true);

        // Check for Category button component in button template
        if (buttonTemplate == null || buttonTemplate.transform.GetChild(0).GetComponent<ShoppingListItem>() == null)
        {
            Debug.Log("ERROR: Invalid item image template.");
            return;
        }

        // Clear buttons list but ignore the buttons template
        if (itemMenu.GetComponentInChildren<ShoppingListItem>() != null)
        {
            ShoppingListItem[] oldButtons = itemMenu.GetComponentsInChildren<ShoppingListItem>();
            foreach (ShoppingListItem ii in oldButtons)
            {
                if (ii != buttonTemplate.transform.GetChild(0).GetComponent<ShoppingListItem>())
                    Destroy(ii.gameObject);
            }
        }

        // Create Category buttons from database
        int i = 0;
        foreach (Item item in category.items)
        {
            GameObject button = Instantiate(buttonTemplate);
            GameObject image = button.transform.GetChild(0).gameObject;
            image.GetComponent<ShoppingListItem>().SetItem(item);
            // Place button
            image.GetComponent<RectTransform>().localPosition = buttonTemplate.transform.GetChild(0).GetComponent<RectTransform>().localPosition + i * new Vector3(-10, 0, 0);
            i++;
            // Set image on button
            button.name = item.itemName + " Canvas";
            image.name = item.itemName;
            image.GetComponent<Picture>().pictureFolder = item.itemName;
            // Initialize button
            button.transform.SetParent(buttonTemplate.transform.parent, false);
            button.SetActive(true);
        }

        // Now destroy the template
        //Destroy(buttonTemplate.gameObject);
    }
}
