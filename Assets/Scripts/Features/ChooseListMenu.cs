// Script to control the Choose List Menu (the list of shopping lists)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseListMenu : MonoBehaviour
{
    protected ListBtn[] buttons;
    protected ListDeleteBtn[] deleteBtns;
    [SerializeField]
    protected ShoppingListController controller;
    [SerializeField]
    protected GameObject listBtnTemplate; // Sample list button for template
    [SerializeField]
    protected GameObject deleteBtnTemplate; // Sample delete list button for template
    [SerializeField]
    protected GameObject newListBtn; // "New List" button

    // Start is called before the first frame update
    void Awake()
    {
        buttons = gameObject.GetComponentsInChildren<ListBtn>();
        deleteBtns = gameObject.GetComponentsInChildren<ListDeleteBtn>();
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Refresh and show the list of shopping lists
    public void Refresh()
    {
        // First clear menu before repopulating
        ClearMenu();
        int i = 0;
        // For each list in menu, create and place a button
        foreach (ShoppingList list in controller.ViewShoppingLists())
        {
            GameObject listBtn = Instantiate(listBtnTemplate);
            GameObject deleteBtn = Instantiate(deleteBtnTemplate);
            listBtn.GetComponent<ListBtn>().SetList(list);
            deleteBtn.GetComponent<ListDeleteBtn>().SetList(list);
            // Place button
            listBtn.GetComponent<RectTransform>().localPosition = listBtnTemplate.transform.GetComponent<RectTransform>().localPosition + i * new Vector3(0, -10, 0);
            deleteBtn.GetComponent<RectTransform>().localPosition = deleteBtnTemplate.transform.GetComponent<RectTransform>().localPosition + i * new Vector3(0, -10, 0);
            // Set name on button
            listBtn.name = list.name;
            deleteBtn.name = "Delete " + list.name;
            // Initialize button
            listBtn.transform.SetParent(transform, false);
            listBtn.SetActive(true);
            deleteBtn.transform.SetParent(transform, false);
            deleteBtn.SetActive(true);
            // Increment index to iterate next item in list
            i++;
        }
        // Update buttons list
        buttons = gameObject.GetComponentsInChildren<ListBtn>();
        deleteBtns = gameObject.GetComponentsInChildren<ListDeleteBtn>();
        // Create the "New List" button and place it
        newListBtn.GetComponent<RectTransform>().localPosition = listBtnTemplate.transform.GetComponent<RectTransform>().localPosition + i * new Vector3(0, -10, 0);
        newListBtn.transform.SetParent(transform, false);
        newListBtn.SetActive(true);
        Debug.Log("Choose list menu refresh finish");
    }

    // Clear the menu only
    void ClearMenu()
    {
        if (buttons != null)
        {
            foreach (ListBtn button in buttons)
            {
                if (button != null && button != listBtnTemplate)
                    Destroy(button.gameObject);
            }
        }
        if (deleteBtns != null)
        {
            foreach (ListDeleteBtn button in deleteBtns)
            {
                if (button != null && button != deleteBtnTemplate)
                    Destroy(button.gameObject);
            }
        }
        // Update buttons list
        buttons = gameObject.GetComponentsInChildren<ListBtn>();
        deleteBtns = gameObject.GetComponentsInChildren<ListDeleteBtn>();
    }
}
