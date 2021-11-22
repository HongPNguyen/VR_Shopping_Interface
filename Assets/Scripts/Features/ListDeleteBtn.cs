// Button to delete a certain shopping list

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDeleteBtn : MonoBehaviour
{
    protected ShoppingList list;
    [SerializeField]
    protected ShoppingListController controller;
    [SerializeField]
    protected ShoppingListMenu shoppingListMenu;
    [SerializeField]
    protected ChooseListMenu chooseListMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Set the list the delete button is associated with
    public void SetList(ShoppingList list)
    {
        this.list = list;
    }

    // Activate the button and delete the list
    public void Activate()
    {
        // If the list being deleted is the list shown in the menu, auto-replace with latest list
        bool replace = (list.id == shoppingListMenu.GetList().id);
        controller.RemoveShoppingList(list.id);
        if (replace)
        {
            int lastIndex = controller.ViewShoppingLists().Count - 1;
            controller.ViewShoppingList(controller.ViewShoppingLists()[lastIndex].id);
            // Also refresh the menus
            shoppingListMenu.Refresh();
        }
        chooseListMenu.Refresh();
    }
}
