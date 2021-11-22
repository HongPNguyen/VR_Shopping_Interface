// Script to control the main radial menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRadialMenu : MonoBehaviour
{
    [SerializeField]
    protected GameObject specialtyMenu;
    [SerializeField]
    protected GameObject categoryMenu;
    [SerializeField]
    protected GameObject itemMenu;
    [SerializeField]
    protected GameObject shoppingListMenu;
    [SerializeField]
    protected Transform specialtyAnchor1;
    [SerializeField]
    protected Transform categoryAnchor1;
    [SerializeField]
    protected Transform specialtyAnchor2;
    [SerializeField]
    protected Transform categoryAnchor2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call the main (item) menu
    // Item menus are moved to Position 1
    public void CallItemMenu()
    {
        specialtyMenu.transform.localPosition = specialtyAnchor1.localPosition;
        categoryMenu.transform.localPosition = categoryAnchor1.localPosition;
        specialtyMenu.SetActive(true);
        categoryMenu.SetActive(true);
        itemMenu.SetActive(true);
        shoppingListMenu.SetActive(false);
    }

    // Call the shopping list menu
    public void CallListMenu()
    {
    specialtyMenu.SetActive(false);
    categoryMenu.SetActive(false);
    itemMenu.SetActive(false);
    shoppingListMenu.SetActive(true);
    }

    // Display both the main menu and the shopping list menu
    // Item menus will be moved to Position 2
    public void CallBothMenus()
    {
        specialtyMenu.transform.localPosition = specialtyAnchor2.localPosition;
        categoryMenu.transform.localPosition = categoryAnchor2.localPosition;
        specialtyMenu.SetActive(true);
        categoryMenu.SetActive(true);
        itemMenu.SetActive(true);
        shoppingListMenu.SetActive(true);
    }
}
