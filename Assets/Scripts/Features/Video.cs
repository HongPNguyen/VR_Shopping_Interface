using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    // Folder to search for picture in. Picture shown will be the first picture in the folder.
    public string videoFolder;
    public bool loopVideo;
    public float width = 10;
    public float height = 10;

    // Active picture to show
    protected VideoClip activeVideo;
    protected RectTransform rectTransform;
    protected VideoPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        // Initializations
        rectTransform = gameObject.GetComponent<RectTransform>();
        player = gameObject.GetComponent<VideoPlayer>();

        if (rectTransform == null || player == null)
        {
            Debug.Log("ERROR: Missing components in video frame.");
            return;
        }

        // Set looping parameter
        player.isLooping = loopVideo;

        // Set initial picture (Currently from folder.)
        LoadVideo();

        // Show picture
        ShowVideo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set initial picture (Currently from folder.)
    // CAN BE MODIFIED TO GRAB PICTURE FROM AN ONLINE STREAM AS NEEDED.
    virtual protected void LoadVideo()
    {
        string[] videoFiles = System.IO.Directory.GetFiles("Assets/Resources/Videos/" + videoFolder);
        try
        {
            player.url = videoFiles[0];
        }
        catch (System.Exception e)
        {
            Debug.Log("ERROR: Video file not supported, cannot convert to video.");
        }
        // Change frame size
        if (width > 0 && height > 0)
        {
            rectTransform.localScale = new Vector3(width, -height, 0.01f);
        }
    }

    protected void ShowVideo()
    {
        if (activeVideo != null)
        {
            player.clip = activeVideo;
            if (width > 0 && height > 0)
            {
                rectTransform.localScale = new Vector3(width, -height, 0.01f);
            }
            player.Play();
        }
    }
}
