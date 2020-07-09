using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour
{
    public GameObject prefab;
    public int numberToCreate;
    void Start()
    {
        Populate();
    }

    void Populate()
    {
        GameObject newObj;

        for (int i = 0; i < numberToCreate; i++)
        {
            newObj = (GameObject) Instantiate(prefab, transform);
            newObj.GetComponentInChildren<Text>().text = "Level " + (i+1);
        }
    }
}
