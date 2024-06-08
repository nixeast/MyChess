using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject imgGameBoardTilePrefab_white;
    public GameObject imgGameBoardTilePrefab_black;
    public GameObject ChessPiecePrefab;
    public GameObject CurrentSelectedPiece;
    public GameObject chessPieceMovablePointPrefab;

    public Canvas CurrentCanvas;

    public Sprite[] arPieceSprite = new Sprite[12];

    GameObject[] chessBoardTile = new GameObject[64];
    GameObject[] chessPiece = new GameObject[32];
    GameObject currentPieceMovablePoint;

    float fPosXCorrection = -175.0f;
    float fPosYCorrection = -175.0f;


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
        CreateChessPieces();
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
                else if (nSumTileXY % 2 == 1)
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

    void CreateChessPieces()
    {
        int nTileNumber = 0;
        int nPieceNumber = 0;

        while (nTileNumber < 64)
        {
            if (nTileNumber < 16 || nTileNumber >= 48)
            {
                Vector3 posCurrentPiece = Vector3.zero;
                chessPiece[nPieceNumber] = Instantiate(ChessPiecePrefab);
                chessPiece[nPieceNumber].transform.SetParent(CurrentCanvas.transform);


                posCurrentPiece = chessBoardTile[nTileNumber].GetComponent<RectTransform>().localPosition;
                chessPiece[nPieceNumber].GetComponent<RectTransform>().localPosition = posCurrentPiece;

                chessPiece[nPieceNumber].GetComponent<ChessPiece>().nCurrentTileNumber = nTileNumber;


                nPieceNumber++;
            }

            nTileNumber++;
        }

        nPieceNumber = 0;
        while (nPieceNumber < 32)
        {

            if (nPieceNumber < 16)
            {
                chessPiece[nPieceNumber].GetComponent<ChessPiece>().nOwnPlayerNumber = 1;
            }
            else if (nPieceNumber >= 16)
            {
                chessPiece[nPieceNumber].GetComponent<ChessPiece>().nOwnPlayerNumber = 2;
            }

            nPieceNumber++;
        }

        nPieceNumber = 0;
        while (nPieceNumber < 32)
        {

            if (nPieceNumber == 3 || nPieceNumber == 27)
            {
                chessPiece[nPieceNumber].GetComponent<ChessPiece>().currentPieceType = ChessPiece.MyPieceTypes.King;
            }

            else if (nPieceNumber == 4 || nPieceNumber == 28)
            {
                chessPiece[nPieceNumber].GetComponent<ChessPiece>().currentPieceType = ChessPiece.MyPieceTypes.Queen;
            }

            else if (nPieceNumber == 2 || nPieceNumber == 5 || nPieceNumber == 26 || nPieceNumber == 29)
            {
                chessPiece[nPieceNumber].GetComponent<ChessPiece>().currentPieceType = ChessPiece.MyPieceTypes.Bishop;
            }

            else if (nPieceNumber == 1 || nPieceNumber == 6 || nPieceNumber == 25 || nPieceNumber == 30)
            {
                chessPiece[nPieceNumber].GetComponent<ChessPiece>().currentPieceType = ChessPiece.MyPieceTypes.Knight;
            }

            else if (nPieceNumber == 0 || nPieceNumber == 7 || nPieceNumber == 24 || nPieceNumber == 31)
            {
                chessPiece[nPieceNumber].GetComponent<ChessPiece>().currentPieceType = ChessPiece.MyPieceTypes.Rook;
            }

            else if (nPieceNumber >= 8 && nPieceNumber < 24)
            {
                chessPiece[nPieceNumber].GetComponent<ChessPiece>().currentPieceType = ChessPiece.MyPieceTypes.Pawn;
                chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[11];
            }

            nPieceNumber++;
        }

        nPieceNumber = 0;
        while (nPieceNumber < 32)
        {
            int nCurrentPiecePlayerNumber = 0;
            ChessPiece.MyPieceTypes CurrentPieceType = 0;

            nCurrentPiecePlayerNumber = chessPiece[nPieceNumber].GetComponent<ChessPiece>().nOwnPlayerNumber;
            CurrentPieceType = chessPiece[nPieceNumber].GetComponent<ChessPiece>().currentPieceType;

            if(nCurrentPiecePlayerNumber == 1)
            {
                if(CurrentPieceType == ChessPiece.MyPieceTypes.King)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[0];
                }
                else if(CurrentPieceType == ChessPiece.MyPieceTypes.Queen)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[1];
                }
                else if (CurrentPieceType == ChessPiece.MyPieceTypes.Bishop)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[2];
                }
                else if (CurrentPieceType == ChessPiece.MyPieceTypes.Knight)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[3];
                }
                else if (CurrentPieceType == ChessPiece.MyPieceTypes.Rook)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[4];
                }
                else if (CurrentPieceType == ChessPiece.MyPieceTypes.Pawn)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[5];
                }
            }
            else if(nCurrentPiecePlayerNumber == 2)
            {
                if (CurrentPieceType == ChessPiece.MyPieceTypes.King)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[6];
                }
                else if (CurrentPieceType == ChessPiece.MyPieceTypes.Queen)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[7];
                }
                else if (CurrentPieceType == ChessPiece.MyPieceTypes.Bishop)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[8];
                }
                else if (CurrentPieceType == ChessPiece.MyPieceTypes.Knight)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[9];
                }
                else if (CurrentPieceType == ChessPiece.MyPieceTypes.Rook)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[10];
                }
                else if (CurrentPieceType == ChessPiece.MyPieceTypes.Pawn)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[11];
                }
            }

            nPieceNumber++;
        }
    }

    public void ShowCurrentPieceMoveRange(ChessPiece.MyPieceTypes pieceType)
    {
        Vector3 posParentPosition = Vector3.zero;
        Vector3 targetPosition = Vector3.zero;
        int nTargetTileNumber = 0;

        if(pieceType == ChessPiece.MyPieceTypes.Pawn)
        {
            currentPieceMovablePoint = Instantiate(chessPieceMovablePointPrefab);
        
            nTargetTileNumber = CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber + 8;
            currentPieceMovablePoint.transform.SetParent(chessBoardTile[nTargetTileNumber].transform);

            currentPieceMovablePoint.GetComponent<RectTransform>().localPosition = posParentPosition;

            currentPieceMovablePoint.GetComponent<Button>().onClick.AddListener(() => MovePieceToPoint(currentPieceMovablePoint));
        }


    }

    public void DestroyCurrentPieceMoveRange()
    {
        CurrentSelectedPiece.GetComponent<ChessPiece>().ChangePieceColorTransparency(false);
        Destroy(currentPieceMovablePoint);
        CurrentSelectedPiece = null;
    }
    public void MovePieceToPoint(GameObject pointGameObject)
    {
        int nCurrentPointTileNumber;

        Vector3 testPos = pointGameObject.GetComponent<RectTransform>().localPosition;
        nCurrentPointTileNumber = pointGameObject.GetComponentInParent<BoardTile>().nMyTileNmber;
        Debug.Log("nCurrentPointTileNumber : " + nCurrentPointTileNumber);

        CurrentSelectedPiece.GetComponent<RectTransform>().localPosition = chessBoardTile[nCurrentPointTileNumber].GetComponent<RectTransform>().localPosition;
        CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber = nCurrentPointTileNumber;
        DestroyCurrentPieceMoveRange();
    }

    void TestFunc()
    {
        Debug.Log("this is AddListener test");
    }
}