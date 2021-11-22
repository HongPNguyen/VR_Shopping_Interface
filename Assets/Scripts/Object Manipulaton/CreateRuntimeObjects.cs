using UnityEngine;
using Assets;
public class CreateRuntimeObjects : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject runtimePrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        GameObject testShelf = GameObject.Find("test-shelf");
        GameObject topBox = GameObject.Find("test-shelf/Box005");

        if (testShelf == null)
        {
            Debug.Log("Cannot find test-shelf");
        }

        if (topBox == null)
        {
            Debug.Log("Cannot find top-box");
        }

        Vector3 runtimePrefabPosition = topBox.transform.position + Vector3.up * 2.0f;

        Instantiate(runtimePrefab, runtimePrefabPosition, Quaternion.identity);

        /*if (runtimePrefab == null)
        {
            Debug.log("The Shopping Car Does not Exist");
        }
        else
        {
            double distance = checkCartShelfDistance(runtimePrefab);
        }*/

    }

    void update()
    {

    }

    /*double checkCartShelfDistance(GameObject shoppingCart)
    {
        GameObject testShelf = GameObject.find("test-shelf");

        if (testShelf == null)
        {
            Debug.log("Cannot find the test-shelf");
        }
        else
        {
            GameObject topBox = GameObject.find("test-shelf/Box005");

            if (topBox == null)
            {
                Debug.log("Cannot find the top-box");
            }
        }
    }*/
    
}