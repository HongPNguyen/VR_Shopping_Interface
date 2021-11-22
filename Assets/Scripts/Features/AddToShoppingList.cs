// Script to control the "Add to Shopping List" button

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddToShoppingList : MonoBehaviour
{
    Item item;
    public float shoppingListDisplayTime = 2f;
    [SerializeField]
    protected ShoppingListMenu listMenu; // Shopping list menu that is displaying the active shopping list
    [SerializeField]
    protected GameObject specialtyMenu; // Specialty menu reference
    [SerializeField]
    protected GameObject categoryMenu; // Category menu
    [SerializeField]
    protected GameObject itemMenu; // Item menu
    [SerializeField]
    protected Text numpadText; // Grab numpad's text

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItem(Item i)
    {
        this.item = i;
    }

    public void Activate()
    {
        // Add item to shopping list according to numpad data
        if (numpadText.text == "")
        {
            listMenu.AddItemToList(item, 1);
        }
        else
        {
            listMenu.AddItemToList(item, int.Parse(numpadText.text));
        }
        // Temporarily show shopping list
        if (!listMenu.gameObject.activeSelf)
        {
            StartCoroutine(ShowShoppingList());
        }
    }

    private IEnumerator ShowShoppingList()
    {
        // Disable item menus
        if (specialtyMenu.activeSelf)
            specialtyMenu.SetActive(false);
        if (categoryMenu.activeSelf)
            categoryMenu.SetActive(false);
        if (itemMenu.activeSelf)
            itemMenu.SetActive(false);
        // Show the shopping list
        listMenu.gameObject.SetActive(true);
        // Wait, then disable shopping list and enable item menus again
        yield return new WaitForSeconds(shoppingListDisplayTime);
        listMenu.gameObject.SetActive(false);
        specialtyMenu.gameObject.SetActive(true);
        categoryMenu.gameObject.SetActive(true);
        itemMenu.gameObject.SetActive(true);
        yield return null;
    }
}
