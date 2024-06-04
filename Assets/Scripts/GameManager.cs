using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject imgGameBoardTilePrefab;
    public Canvas CurrentCanvas;


    // Start is called before the first frame update
    void Start()
    {
        GameObject myTestTile = Instantiate(imgGameBoardTilePrefab);
        myTestTile.transform.SetParent(CurrentCanvas.transform);
        Vector3 testLocation = new Vector3(-350.0f, 0, 0);

        myTestTile.GetComponent<RectTransform>().localPosition = testLocation;

        testLocation = new Vector3(-150.0f, 0, 0);
        GameObject myTestTile1 = Instantiate(imgGameBoardTilePrefab);

        myTestTile1.transform.SetParent(CurrentCanvas.transform);
        myTestTile1.GetComponent<RectTransform>().localPosition = testLocation;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
