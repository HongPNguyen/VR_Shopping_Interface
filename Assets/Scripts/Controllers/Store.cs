using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public DatabaseController database;
    public List<Aisle> aisles;
    public List<PurchaseHistory> shopperHistories;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Make a new purchase for a shopper
    public Purchase MakePurchase(string shopperId)
    {
        return new Purchase(shopperId);
    }

    // Add an item to a purchase
    public void AddItemToPurchase(Purchase purchase, string itemId, float quantity)
    {
        // Check if item exists
        Item itemToAdd = database.FindItem(itemId);
        if (itemToAdd == null)
        {
            Debug.Log("ERROR: Item " + itemId + " not found. Cannot add to purchase.");
            return;
        }
        Item[] itemArr = purchase.GetItems();
        float[] quantArr = purchase.GetQuantities();
        // Check status of array and extend as needed
        int arrLen = 0;
        if (itemArr != null)
            arrLen = itemArr.Length;
        if (arrLen == 0)
        {
            itemArr = new Item[1];
            quantArr = new float[1];
        }
        else if (itemArr[arrLen - 1] != null)
        {
            Item[] newArr = new Item[arrLen + 1];
            float[] newQuantArr = new float[arrLen + 1];
            System.Array.Copy(itemArr, newArr, arrLen);
            System.Array.Copy(quantArr, newQuantArr, arrLen);
            itemArr = newArr;
            quantArr = newQuantArr;
        }
        // Add item & quantity to arrays
        for (int i = 0; i < itemArr.Length; i++)
        {
            if (itemArr[i] == null)
            {
                itemArr[i] = itemToAdd;
                quantArr[i] = quantity;
                return;
            }
        }
        Debug.Log("Error adding item to purchase.");
        return;
    }

    public void FinalizePurchase(Purchase purchase)
    {

    }

    public PurchaseHistory CheckPurchaseHistory(string shopperId)
    {
        foreach (PurchaseHistory history in shopperHistories)
        {
            if (history.shopperId == shopperId)
                return history;
        }
        Debug.Log("Shopper " + shopperId + " not found!");
        return null;
    }
}
