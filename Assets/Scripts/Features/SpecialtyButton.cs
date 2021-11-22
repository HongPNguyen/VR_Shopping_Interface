/* Script to control a specialty button. The specialty button is itself the controller of its associated
 * category submenu. */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpecialtyButton : MonoBehaviour
{
    // Specialty associated with button.
    // PUBLIC FOR DEBUG ONLY!!!
    protected Specialty specialty;
    [SerializeField]
    protected GameObject buttonTemplate; // Sample CATEGORY button for template.
    [SerializeField]
    protected GameObject categoryMenu; // Sample CATEGORY button for template.

    // Constructor
    public SpecialtyButton(Specialty s)
    {
        this.specialty = s;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpecialty(Specialty s)
    {
        this.specialty = s;
    }

    public void GenerateCategoryMenu()
    {
        Debug.Log("Click success");

        // Check for Category button component in button template
        if (buttonTemplate == null || buttonTemplate.GetComponent<CategoryButton>() == null)
        {
            Debug.Log("ERROR: Invalid category button template.");
            return;
        }

        // Clear buttons list but ignore the buttons template
        if (categoryMenu.GetComponentInChildren<CategoryButton>() != null)
        {
            CategoryButton[] oldButtons = categoryMenu.GetComponentsInChildren<CategoryButton>();
            foreach (CategoryButton b in oldButtons)
            {
                if (b != buttonTemplate.GetComponent<CategoryButton>())
                    Destroy(b.gameObject);
            }
        }

        // Create Category buttons from database
        int i = 0;
        foreach (Category c in specialty.categories)
        {
            GameObject button = Instantiate(buttonTemplate);
            Debug.Log(c.categoryName);
            button.GetComponent<CategoryButton>().SetCategory(c);
            // Place button
            button.GetComponent<RectTransform>().localPosition = buttonTemplate.GetComponent<RectTransform>().localPosition + i * new Vector3(0, -8, 0);
            i++;
            // Set text on button
            button.name = c.categoryName;
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = c.name;
            // Initialize button
            button.transform.SetParent(categoryMenu.transform, false);
            button.SetActive(true);
        }

        // Now destroy and reassign the template
        //Destroy(buttonTemplate.gameObject);
        //buttonTemplate = categoryMenu.GetComponentInChildren<CategoryButton>().gameObject;
    }
}
