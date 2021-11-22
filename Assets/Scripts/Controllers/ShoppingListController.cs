using System.Collections;
using System.Collections.Generic;
using static System.DateTime;
using UnityEngine;

public class ShoppingListController : MonoBehaviour
{
    public DatabaseController database;
    [SerializeField]
    protected List<ShoppingList> shoppingLists;
    protected int curId = 2;
    [SerializeField]
    protected ShoppingListMenu listMenu;

    // Start is called before the first frame update
    void Start()
    {
        shoppingLists = new List<ShoppingList>();
        // Automatically add children to list of shopping lists
        ShoppingList[] childLists = gameObject.GetComponentsInChildren<ShoppingList>();
        foreach (ShoppingList list in childLists)
        {
            shoppingLists.Add(list);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ShoppingList MakeShoppingList()
    {
        //ShoppingList newList = new ShoppingList(database.GetActiveShopperId());
        curId++;
        GameObject newListContainer = new GameObject("Shopping List: " + System.DateTime.Now.ToString());
        newListContainer.transform.SetParent(transform, false); 
        ShoppingList newList = newListContainer.AddComponent<ShoppingList>() as ShoppingList;
        newList.id = curId.ToString();
        newList.name = System.DateTime.Now.ToString(); // Use time of creation as a TEMPORARY name
        newList.date = System.DateTime.Now;
        newList.time = System.DateTime.Now.TimeOfDay;
        shoppingLists.Add(newList);
        return newList;
    }

    public ShoppingList ViewShoppingList(string listId)
    {
        ShoppingList ret = null;
        foreach (ShoppingList list in shoppingLists)
        {
            list.current = false; // If not the list being called, set to not current
            if (list.id == listId)
            {
                list.current = true; // Set list to current and every other list to not current
                listMenu.SetList(list);
                listMenu.Refresh();
                ret = list;
            }
        }
        return ret;
    }

    // View all the shopping lists for a shopper
    public List<ShoppingList> ViewShoppingLists(/*string shopperId*/)
    {
        /*List<ShoppingList> returnList = new List<ShoppingList>();
        foreach (ShoppingList list in shoppingLists)
        {
            //if (list.GetShopper() == shopperId)
                returnList.Add(list);
        }
        return returnList;*/
        return shoppingLists;
    }

    public ShoppingList ViewCurrentShoppingList(string shopperId)
    {
        foreach (ShoppingList list in shoppingLists)
        {
            if (list.GetShopper() == shopperId && list.current)
                return list;
        }
        return null;
    }

    public void RemoveShoppingList(string listId)
    {
        foreach (ShoppingList list in shoppingLists)
        {
            if (list.id == listId)
            {
                shoppingLists.Remove(list);
                return;
            }
        }
    }

    // View all the shopping lists created between two dates
    public List<ShoppingList> ViewShoppingListsBetween(string shopperId, string startDate, string endDate)
    {
        List<ShoppingList> returnList = new List<ShoppingList>();
        var realStartDate = System.DateTime.Parse(startDate);
        var realEndDate = System.DateTime.Parse(endDate);
        foreach (ShoppingList list in shoppingLists)
        {
            if (list.GetShopper() == shopperId && list.date >= realStartDate && list.date <= realEndDate)
                returnList.Add(list);
        }
        return returnList;
    }

    void SetUpGuideProcess(ShoppingList currentList)
    {

    }

    void GuideUserToItem(string itemId)
    {

    }

    string ReportItemUnavailable(Quote quote)
    {
        return "";
    }
}
