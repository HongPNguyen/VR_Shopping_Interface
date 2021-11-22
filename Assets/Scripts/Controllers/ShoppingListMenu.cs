using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShoppingListMenu : MonoBehaviour
{
    protected ShoppingListItem[] buttons;
    [SerializeField]
    protected TMPro.TextMeshProUGUI titleText;
    [SerializeField]
    protected ShoppingList list;
    [SerializeField]
    protected GameObject listItemTemplate; // Sample item listing in shopping list for template

    // Start is called before the first frame update
    void Awake()
    {
        buttons = gameObject.GetComponentsInChildren<ShoppingListItem>();
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when there's a change in the list (not every frame)
    public void Refresh()
    {
        // First clear menu before repopulating
        ClearMenu();
        if (list != null)
        {
            int i = 0;
            // For each item in list, create and place a button
            foreach (Item item in list.GetItems())
            {
                GameObject listItem = Instantiate(listItemTemplate);
                listItem.GetComponent<ShoppingListItem>().SetItem(item);
                // Place button
                listItem.GetComponent<RectTransform>().localPosition = listItemTemplate.transform.GetComponent<RectTransform>().localPosition + i * new Vector3(0, -2, 0);
                // Set image on button
                listItem.name = item.itemName;
                listItem.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "- " + item.itemName + ": " + list.GetQuantities()[i] + " " + item.unit;
                // Initialize button
                listItem.transform.SetParent(transform, false);
                listItem.SetActive(true);
                listItem.GetComponent<UnityEngine.UI.Button>().enabled = true;
                listItem.GetComponent<UnityEngine.UI.Image>().enabled = true;
                listItem.GetComponent<ShoppingListItem>().enabled = true;
                listItem.GetComponentInChildren<TMPro.TextMeshProUGUI>().enabled = true;
                // Increment index to iterate next item in list
                i++;
            }
            // Update buttons list
            buttons = gameObject.GetComponentsInChildren<ShoppingListItem>();
            // Set the title text
            titleText.text = "Shopping List\n" + list.date.ToString();
        }
    }

    // Generate item in shopping list
    public void AddItemToList(Item item, float quantity)
    {
        // Formally add item to list
        list.AddItem(item, quantity);
        // Refresh list display
        Refresh();
    }

    // Clear the menu AND the shopping list.
    public void Clear()
    {
        list.Clear();
        Refresh();
    }

    // Clear the menu only
    void ClearMenu()
    {
        if (buttons != null)
        {
            foreach (ShoppingListItem button in buttons)
            {
                if (button != null && button != listItemTemplate)
                    Destroy(button.gameObject);
            }
        }
        // Update buttons list
        buttons = gameObject.GetComponentsInChildren<ShoppingListItem>();
    }

    // Set the list to be viewed
    public void SetList(ShoppingList list)
    {
        this.list = list;
    }

    public ShoppingList GetList()
    {
        return list;
    }

}
