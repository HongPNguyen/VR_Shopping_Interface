// Script to control the "New List" button in the Choose List Menu.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewListBtn : MonoBehaviour
{
    [SerializeField]
    protected ShoppingListController controller;
    [SerializeField]
    protected ChooseListMenu menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Activate the button and create a new list
    public void Activate()
    {
        controller.MakeShoppingList();
        menu.Refresh();
    }
}
