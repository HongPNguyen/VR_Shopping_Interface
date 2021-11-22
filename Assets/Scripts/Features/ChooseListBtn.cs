// List to control the "Choose List" button in the Shopping List Menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseListBtn : MonoBehaviour
{
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

    // Activate the button and call the Choose List Menu
    public void Activate()
    {
        menu.gameObject.SetActive(true);
        menu.Refresh();
    }
}
