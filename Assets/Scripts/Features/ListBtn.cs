// Script for a single button that represents a list in the shopping list menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListBtn : MonoBehaviour
{
    protected ShoppingList list;
    [SerializeField]
    protected ShoppingListController controller;
    [SerializeField]
    protected ChooseListMenu menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = GetComponentInParent<ChooseListMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Constructor
    public ListBtn(ShoppingList list)
    {
        this.list = list;
        // Set the button's text
        TMPro.TextMeshProUGUI btnText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        btnText.text = list.date.ToString();
    }

    // Set the list this button is associated with. Does all constructor functions.
    public void SetList(ShoppingList list)
    {
        this.list = list;
        // Set the button's text
        TMPro.TextMeshProUGUI btnText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        btnText.text = list.name;
    }

    // Activate the button to view the list
    public void ViewList()
    {
        if (list == null)
        {
            Debug.LogError("Invalid shopping list button!");
            return;
        }
        else
        {
            controller.ViewShoppingList(list.id);
            menu.gameObject.SetActive(false);
        }
    }

}
