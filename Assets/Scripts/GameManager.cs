using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject imgGameBoardTilePrefab_white;
    public GameObject imgGameBoardTilePrefab_black;

    public Canvas CurrentCanvas;

    GameObject[] chessBoardTile = new GameObject[64];


    // Start is called before the first frame update
    void Start()
    {
        /*
        GameObject myTestTile = Instantiate(imgGameBoardTilePrefab_white);
        myTestTile.transform.SetParent(CurrentCanvas.transform);
        Vector3 testLocation = new Vector3(-350.0f, 0, 0);

        myTestTile.GetComponent<RectTransform>().localPosition = testLocation;

        testLocation = new Vector3(-150.0f, 0, 0);
        GameObject myTestTile1 = Instantiate(imgGameBoardTilePrefab_white);

        myTestTile1.transform.SetParent(CurrentCanvas.transform);
        myTestTile1.GetComponent<RectTransform>().localPosition = testLocation;
      
        */

        CreateMap();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateMap()
    {
        int nIndexNumber = 0;
        Vector3 targetLocation = new Vector3(0, 0, 0);
        int nColumnCount = 0;
        int nRowCount = 0;
        float nTileInterval = 50.0f;
        int nSumTileXY = 0;

        float fPosXCorrection = -175.0f;
        float fPosYCorrection = -175.0f;

        for (int i = 0; i < 8; i++)
        {
            nColumnCount = 0;

            for (int j = 0; j < 8; j++)
            {
                nSumTileXY = nRowCount + nColumnCount;

                if (nSumTileXY % 2 == 0)
                {
                    chessBoardTile[nIndexNumber] = Instantiate(imgGameBoardTilePrefab_white);
                }
                else if(nSumTileXY % 2 == 1)
                {
                    chessBoardTile[nIndexNumber] = Instantiate(imgGameBoardTilePrefab_black);
                }

                chessBoardTile[nIndexNumber].GetComponent<BoardTile>().nMyTileNmber = nIndexNumber;

                chessBoardTile[nIndexNumber].transform.SetParent(CurrentCanvas.transform);

                targetLocation.x = nColumnCount * nTileInterval + fPosXCorrection;
                targetLocation.y = nRowCount * nTileInterval + fPosYCorrection;

                chessBoardTile[nIndexNumber].GetComponent<RectTransform>().localPosition = targetLocation;

                nIndexNumber++;
                nColumnCount++;
            }

            nRowCount++;

        }
    }
}
