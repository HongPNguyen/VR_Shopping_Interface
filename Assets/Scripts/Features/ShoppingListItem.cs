// Script for an item in the shopping list.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingListItem : MonoBehaviour
{
    protected Item item;
    [SerializeField]
    protected GameObject canvasTemplate; // Sample VIDEO canvas for template.
    [SerializeField]
    protected GameObject descriptionArea; // Sample description area for video and information
    [SerializeField]
    protected InputField numpadTextField; // Grab numpad's text to clear upon click
    [SerializeField]
    protected AddToShoppingList addToListBtn; // Reference to button to add this item to shopping list

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

    // Function to generate item info in the description panel, same as in ItemImage
    public void GenerateItemInfo()
    {
        Debug.Log("Click success");

        // Check for Category button component in button template
        if (canvasTemplate == null || canvasTemplate.GetComponentInChildren<YoutubePlayer.YoutubePlayer>() == null)
        {
            Debug.LogError("ERROR: Invalid video canvas template.");
            return;
        }

        // Clear video in description area
        if (descriptionArea.GetComponentInChildren<Canvas>() != null)
        {
            YoutubePlayer.YoutubePlayer[] oldCanvas = descriptionArea.GetComponentsInChildren<YoutubePlayer.YoutubePlayer>();
            foreach (YoutubePlayer.YoutubePlayer c in oldCanvas)
            {
                if (c != canvasTemplate.transform.GetChild(0).GetComponent<YoutubePlayer.YoutubePlayer>())
                    Destroy(c.transform.parent.gameObject);
            }
        }

        // Create new video canvas from database and input URL
        GameObject canvas = Instantiate(canvasTemplate);
        GameObject video = canvas.transform.GetChild(0).gameObject;
        string fullDescription = "";
        // Assign video URL
        video.GetComponent<YoutubePlayer.YoutubePlayer>().youtubeUrl = item.videoUrl;
        if (item.videoUrl == "")
            fullDescription += "VIDEO NOT FOUND!\n";
        // Place video
        video.GetComponent<RectTransform>().localPosition = canvasTemplate.transform.GetChild(0).GetComponent<RectTransform>().localPosition;
        // Set image on button
        canvas.name = item.itemName + " Canvas";
        video.name = item.itemName;
        // Set description text
        fullDescription += "ITEM NAME: " + item.itemName + "\n" +
                           "PRICE: $" + item.unitPrice + "/" + item.unit + "\n\n" +
                           item.description +"\n\nChoose amount in numpad.";
        // Initialize canvas
        descriptionArea.SetActive(true);
        canvas.transform.SetParent(canvasTemplate.transform.parent, false);
        SetActiveAllChildren(descriptionArea.transform, true);
        descriptionArea.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = fullDescription;

        // Clear numpad text
        numpadTextField.Select();
        numpadTextField.text = string.Empty;

        // Initialize "Add to List Button"
        addToListBtn.gameObject.SetActive(true);
        addToListBtn.SetItem(item);
        // Now destroy the template
        //Destroy(canvasTemplate.gameObject);
    }

    // Set active all children of description area, excluding the video template
    private void SetActiveAllChildren(Transform transform, bool value)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject != canvasTemplate)
            {
                child.gameObject.SetActive(value);
                SetActiveAllChildren(child, value);
            }
        }
    }
}
