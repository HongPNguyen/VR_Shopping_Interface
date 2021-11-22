using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPicture : Picture
{
    public float timeBetweenFrames = 0.5f;
    public int initialIndex = 0;
    protected float timer = 0f;

    protected Texture[] textures;

    // Update is called once per frame
    new void Update()
    {
        // Change the picture every time the timer reaches timeBetweenFrames
        timer += Time.deltaTime;
        if (timer >= timeBetweenFrames)
        {
            ChangePicture();
            timer = 0f;
        }
    }

    // Loat textures into array
    override protected void LoadTextures()
    {
        string imagePath = "Images/" + pictureFolder;
        Object[] rawTextures = Resources.LoadAll(imagePath, typeof(Texture2D));
        try
        {
            textures = new Texture[rawTextures.Length];
            for (int i = 0; i < rawTextures.Length; i++)
            {
                textures[i] = (Texture)rawTextures[i];
            }
            activePicture = (Texture)textures[initialIndex];
        }
        catch (System.Exception e)
        {
            Debug.Log("ERROR: Image file not supported, cannot convert to picture.");
        }
    }

    /* Change the active picture based on some criteria
    (Currently just loop through folder, can be modified to, for example,
    update from a live stream as needed.) */
    void ChangePicture()
    {
        initialIndex = (initialIndex + 1) % textures.Length;
        activePicture = (Texture)textures[initialIndex];
        ShowPicture();
    }
}
