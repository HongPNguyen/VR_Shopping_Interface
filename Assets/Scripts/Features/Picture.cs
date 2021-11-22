using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picture : MonoBehaviour
{
    // Folder to search for picture in. Picture shown will be the first picture in the folder.
    public string pictureFolder;
    public float width = 10;
    public float height = 10;

    // Active picture to show
    protected Texture activePicture;
    protected RectTransform rectTransform;
    protected RawImage rawImage;

    // Start is called before the first frame update
    void Start()
    {
        // Initializations
        rectTransform = gameObject.GetComponent<RectTransform>();
        rawImage = gameObject.GetComponent<RawImage>();

        if (rectTransform == null || rawImage == null)
        {
            Debug.Log("ERROR: Missing components in picture frame.");
            return;
        }

        // Set initial picture (Currently from folder.)
        LoadTextures();

        // Show picture
        ShowPicture();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set initial picture (Currently from folder.)
    // CAN BE MODIFIED TO GRAB PICTURE FROM AN ONLINE STREAM AS NEEDED.
    virtual protected void LoadTextures()
    {
        string imagePath = "Images/" + pictureFolder;
        Object[] rawTextures = Resources.LoadAll(imagePath, typeof(Texture2D));
        try
        {
            activePicture = (Texture)rawTextures[0];
        }
        catch (System.Exception e)
        {
            Debug.Log("ERROR: Image file not supported, cannot convert to picture.");
        }
    }

    protected void ShowPicture()
    {
        if (activePicture != null)
        {
            rawImage.texture = activePicture;
            if (width > 0 && height > 0)
            {
                rectTransform.sizeDelta = new Vector2(width, height);
            }
        }
    }
}
