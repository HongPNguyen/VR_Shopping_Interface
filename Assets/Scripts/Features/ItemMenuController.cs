/* Script to control the ITEM SELECTOR menu
 * (Where the top-level buttons are names of specialties) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenuController : MonoBehaviour
{
    protected DatabaseController database;
    [SerializeField]
    protected GameObject buttonTemplate; // Sample SPECIALTY button for template.
    [SerializeField]
    protected List<GameObject> buttons; // Specialty buttons


    // Start is called before the first frame update
    void Start()
    {
        // Initialize database
        database = GameObject.Find("Database").GetComponent<DatabaseController>();

        // Generate Buttons
        StartCoroutine(GenerateButtons());
    }

    public IEnumerator GenerateButtons()
    {
        yield return new WaitUntil(() => database.initializationDone);


        // Check for specialty button component in button template
        if (buttonTemplate == null || buttonTemplate.GetComponent<SpecialtyButton>() == null)
        {
            Debug.Log("ERROR: Invalid specialty button template.");
            yield break;
        }

        // Clear buttons list but ignore the buttons template
        if (GetComponentInChildren<SpecialtyButton>() != null)
        {
            SpecialtyButton[] oldButtons = GetComponentsInChildren<SpecialtyButton>();
            foreach (SpecialtyButton b in oldButtons)
            {
                if (b != buttonTemplate.GetComponent<SpecialtyButton>())
                    Destroy(b.gameObject);
            }
        }

        // Create specialty buttons from database
        int i = 0;
        foreach (Specialty s in database.GetSpecialties())
        {
            GameObject button = Instantiate(buttonTemplate);
            button.GetComponent<SpecialtyButton>().SetSpecialty(s);
            // Place button
            button.GetComponent<RectTransform>().localPosition = buttonTemplate.GetComponent<RectTransform>().localPosition + i * new Vector3(0, -10, 0);
            i++;
            // Set text on button
            button.name = s.specialtyName;
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = s.name;
            // Initialize button
            button.transform.SetParent(buttonTemplate.transform.parent, false);
            buttons.Add(button);
            button.SetActive(true);
        }

        // Now destroy the template
        Destroy(buttonTemplate.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Main event listener for button
    public void SpecialtyButtonClick(string specialty)
    {

    }
}
