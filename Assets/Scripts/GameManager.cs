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
    //GameObject currentPieceMovablePoint;
    public List<GameObject> createdMovablePoint = new List<GameObject>();

    float fPosXCorrection = -175.0f;
    float fPosYCorrection = -175.0f;

    //GameObject[] UpSideMovablePoint;


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

            if (nCurrentPiecePlayerNumber == 1)
            {
                if (CurrentPieceType == ChessPiece.MyPieceTypes.King)
                {
                    chessPiece[nPieceNumber].GetComponent<Image>().sprite = arPieceSprite[0];
                }
                else if (CurrentPieceType == ChessPiece.MyPieceTypes.Queen)
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
            else if (nCurrentPiecePlayerNumber == 2)
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

        if (pieceType == ChessPiece.MyPieceTypes.Pawn)
        {

            MakeMovePoint_Pawn(nTargetTileNumber, posParentPosition);

        }
        else if (pieceType == ChessPiece.MyPieceTypes.Rook)
        {

            MakeMovePoint_Rook(nTargetTileNumber, posParentPosition);

        }
        else if (pieceType == ChessPiece.MyPieceTypes.Knight)
        {

            MakeMovePoint_Knight(nTargetTileNumber, posParentPosition);

        }
        else if (pieceType == ChessPiece.MyPieceTypes.Bishop)
        {

            MakeMovePoint_Bishop(nTargetTileNumber, posParentPosition);

        }
        else if (pieceType == ChessPiece.MyPieceTypes.Queen)
        {

            //MakeMovePoint_Rook(nTargetTileNumber, posParentPosition);

        }
        else if (pieceType == ChessPiece.MyPieceTypes.King)
        {

            //MakeMovePoint_Rook(nTargetTileNumber, posParentPosition);

        }



    }

    public void DestroyCurrentPieceMoveRange()
    {

        CurrentSelectedPiece.GetComponent<ChessPiece>().ChangePieceColorTransparency(false);

        //if (currentPieceMovablePoint != null)
        //{
        //    Destroy(currentPieceMovablePoint);
        //}

        if (createdMovablePoint.Capacity > 0)
        {
            for (int i = 0; i < createdMovablePoint.Count; i++)
            {
                Destroy(createdMovablePoint[i]);
            }
            createdMovablePoint.Clear();
            Debug.Log("Movable points are cleared and destroyed..");
        }

        CurrentSelectedPiece = null;
    }

    public void MovePieceToPoint(GameObject pointGameObject)
    {
        if (pointGameObject == null)
        {
            Debug.Log("null ptr..");
        }
        else if (pointGameObject != null)
        {
            Debug.Log("pointGameObject exist..");

            int nCurrentPointTileNumber;

            Vector3 testPos = pointGameObject.GetComponent<RectTransform>().localPosition;
            nCurrentPointTileNumber = pointGameObject.GetComponentInParent<BoardTile>().nMyTileNmber;
            Debug.Log("nCurrentPointTileNumber : " + nCurrentPointTileNumber);

            CurrentSelectedPiece.GetComponent<RectTransform>().localPosition = chessBoardTile[nCurrentPointTileNumber].GetComponent<RectTransform>().localPosition;
            CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber = nCurrentPointTileNumber;
            DestroyCurrentPieceMoveRange();

        }

    }

    void TestFunc()
    {
        Debug.Log("this is AddListener test");
    }

    void MakeMovePoint_Pawn(int nTargetTileNumber, Vector3 posParentPosition)
    {
        int nCountUp = 1;
        int nUpInterval = 8;
        GameObject[] UpSideMovablePoint = new GameObject[nCountUp];

        for (int i = 0; i < nCountUp; i++)
        {

            UpSideMovablePoint[i] = Instantiate(chessPieceMovablePointPrefab);
            createdMovablePoint.Add(UpSideMovablePoint[i]);

            nTargetTileNumber = CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber + (nUpInterval * i) + nUpInterval;
            UpSideMovablePoint[i].transform.SetParent(chessBoardTile[nTargetTileNumber].transform);
            UpSideMovablePoint[i].GetComponent<RectTransform>().localPosition = posParentPosition;

        }

        //currentPieceMovablePoint = Instantiate(chessPieceMovablePointPrefab);

        //nTargetTileNumber = CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber + 8;
        //currentPieceMovablePoint.transform.SetParent(chessBoardTile[nTargetTileNumber].transform);
        //currentPieceMovablePoint.GetComponent<RectTransform>().localPosition = posParentPosition;
        //currentPieceMovablePoint.GetComponent<Button>().onClick.AddListener(() => MovePieceToPoint(currentPieceMovablePoint));
    }

    void MakeMovePoint_Rook(int nTargetTileNumber, Vector3 posParentPosition)
    {
        int ThisPieceTileNumber = 0;
        int nCountUp = 0;
        int nCountUpStartNumber = 0;
        int nCountLeft = 0;
        int nCountLeftStartNumber = 0;
        int nRemainderDividedByEight = 0;
        int nCountDown = 0;
        int nCountDownStartNumber = 0;
        int nCountRight = 0;
        int nCountRightStartNumber = 0;
        int nUpInterval = 8;
        int nDownInterval = -8;
        int nLeftInterval = -1;
        int nRightInterval = 1;

        ThisPieceTileNumber = CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber;
        nCountUpStartNumber = ThisPieceTileNumber + nUpInterval;

        while (nCountUpStartNumber < 64)
        {
            nCountUp++;
            nCountUpStartNumber += nUpInterval;
        }

        Debug.Log("Up direction count : " + nCountUp);

        GameObject[] UpSideMovablePoint = new GameObject[nCountUp];

        for (int i = 0; i < nCountUp; i++)
        {

            UpSideMovablePoint[i] = Instantiate(chessPieceMovablePointPrefab);
            createdMovablePoint.Add(UpSideMovablePoint[i]);

            nTargetTileNumber = CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber + (nUpInterval * i) + nUpInterval;
            UpSideMovablePoint[i].transform.SetParent(chessBoardTile[nTargetTileNumber].transform);
            UpSideMovablePoint[i].GetComponent<RectTransform>().localPosition = posParentPosition;

        }

        nCountDownStartNumber = ThisPieceTileNumber + nDownInterval;
        while (nCountDownStartNumber >= 0)
        {
            nCountDown++;
            nCountDownStartNumber += nDownInterval;
        }
        Debug.Log("Down direction count : " + nCountDown);

        GameObject[] DownSideMovablePoint = new GameObject[nCountDown];
        for (int i = 0; i < nCountDown; i++)
        {
            DownSideMovablePoint[i] = Instantiate(chessPieceMovablePointPrefab);
            createdMovablePoint.Add(DownSideMovablePoint[i]);

            nTargetTileNumber = CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber + (nDownInterval * i) + nDownInterval;
            DownSideMovablePoint[i].transform.SetParent(chessBoardTile[nTargetTileNumber].transform);
            DownSideMovablePoint[i].GetComponent<RectTransform>().localPosition = posParentPosition;

        }

        nRemainderDividedByEight = ThisPieceTileNumber % 8;
        nCountLeftStartNumber = nRemainderDividedByEight - 1;
        while (nCountLeftStartNumber >= 0)
        {
            nCountLeft++;
            nCountLeftStartNumber--;
        }
        Debug.Log("Left direction count : " + nCountLeft);

        GameObject[] LeftSideMovablePoint = new GameObject[nCountLeft];
        for (int i = 0; i < nCountLeft; i++)
        {
            LeftSideMovablePoint[i] = Instantiate(chessPieceMovablePointPrefab);
            createdMovablePoint.Add(LeftSideMovablePoint[i]);

            nTargetTileNumber = CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber + (nLeftInterval * i) + nLeftInterval;
            LeftSideMovablePoint[i].transform.SetParent(chessBoardTile[nTargetTileNumber].transform);
            LeftSideMovablePoint[i].GetComponent<RectTransform>().localPosition = posParentPosition;

        }

        nCountRightStartNumber = nRemainderDividedByEight + 1;
        while (nCountRightStartNumber < 8)
        {
            nCountRight++;
            nCountRightStartNumber++;
        }
        Debug.Log("Right direction count : " + nCountRight);

        GameObject[] RightSideMovablePoint = new GameObject[nCountRight];
        for (int i = 0; i < nCountRight; i++)
        {
            RightSideMovablePoint[i] = Instantiate(chessPieceMovablePointPrefab);
            createdMovablePoint.Add(RightSideMovablePoint[i]);

            nTargetTileNumber = CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber + (nRightInterval * i) + nRightInterval;
            RightSideMovablePoint[i].transform.SetParent(chessBoardTile[nTargetTileNumber].transform);
            RightSideMovablePoint[i].GetComponent<RectTransform>().localPosition = posParentPosition;

        }
    }

    void MakeMovePoint_Knight(int nTargetTileNumber, Vector3 posParentPosition)
    {
        int ThisPieceTileNumber = 0;
        int nCountUpStartNumber = 0;
        int nUpInterval = 16;
        int nDownInterval = -16;
        int nLeftInterval = -2;
        int nRightInterval = 2;
        int nMaxMovePointCount = 8;


        ThisPieceTileNumber = CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber;
        nCountUpStartNumber = ThisPieceTileNumber;

        int[] arFirstStepTargetPosition = new int[nMaxMovePointCount];
        int[] arSecondStepTargetPosition = new int[nMaxMovePointCount];

        int nRightSideLimit = 0;
        nRightSideLimit = ThisPieceTileNumber % 8 + 2;
        int nLeftSideLimit = 0;
        nLeftSideLimit = ThisPieceTileNumber % 8 - 2;
        int nUpSideLimit = 0;
        nUpSideLimit = ThisPieceTileNumber + nUpInterval;
        int nDownSideLimit = 0;
        nDownSideLimit = ThisPieceTileNumber + nDownInterval;

        if (nUpSideLimit < 64)
        {
            Debug.Log("nUpSideLimit < 64");

            arFirstStepTargetPosition[0] = ThisPieceTileNumber + nUpInterval;
            int nNextStepPosition = arFirstStepTargetPosition[0] % 8 - 1;

            if (nNextStepPosition >= 0)
            {
                arSecondStepTargetPosition[0] = arFirstStepTargetPosition[0] - 1;
            }
            else
            {
                arSecondStepTargetPosition[0] = -1;
            }

            arFirstStepTargetPosition[1] = ThisPieceTileNumber + nUpInterval;
            nNextStepPosition = arFirstStepTargetPosition[1] % 8 + 1;
            if (nNextStepPosition < 8)
            {
                arSecondStepTargetPosition[1] = arFirstStepTargetPosition[1] + 1;
            }
            else
            {
                arSecondStepTargetPosition[1] = -1;
            }


        }
        else if(nUpSideLimit >= 64)
        {
            arSecondStepTargetPosition[0] = -1;
            arSecondStepTargetPosition[1] = -1;
        }

        if (nDownSideLimit >= 0)
        {
            Debug.Log("nDownSideLimit >= 0");

            arFirstStepTargetPosition[2] = ThisPieceTileNumber + nDownInterval;
            int nNextStepPosition = arFirstStepTargetPosition[2] % 8 - 1;

            if (nNextStepPosition >= 0)
            {
                arSecondStepTargetPosition[2] = arFirstStepTargetPosition[2] - 1;
            }
            else
            {
                arSecondStepTargetPosition[2] = -1;
            }

            arFirstStepTargetPosition[3] = ThisPieceTileNumber + nDownInterval;
            nNextStepPosition = arFirstStepTargetPosition[3] % 8 + 1;
            if (nNextStepPosition < 8)
            {
                arSecondStepTargetPosition[3] = arFirstStepTargetPosition[3] + 1;
            }
            else
            {
                arSecondStepTargetPosition[3] = -1;
            }


        }
        else if (nDownSideLimit < 0)
        {
            arSecondStepTargetPosition[2] = -1;
            arSecondStepTargetPosition[3] = -1;
        }

        if(nRightSideLimit < 8)
        {
            arFirstStepTargetPosition[4] = ThisPieceTileNumber + nRightInterval;
            int nNextStepPosition = arFirstStepTargetPosition[4] + 8;
            if(nNextStepPosition < 64)
            {
                arSecondStepTargetPosition[4] = arFirstStepTargetPosition[4] + 8;
            }
            else
            {
                arSecondStepTargetPosition[4] = -1;
            }

            arFirstStepTargetPosition[5] = ThisPieceTileNumber + nRightInterval;
            nNextStepPosition = arFirstStepTargetPosition[5] - 8;
            if (nNextStepPosition >= 0)
            {
                arSecondStepTargetPosition[5] = arFirstStepTargetPosition[5] - 8;
            }
            else
            {
                arSecondStepTargetPosition[5] = -1;
            }

        }
        else if(nRightSideLimit >= 8)
        {
            arSecondStepTargetPosition[4] = -1;
            arSecondStepTargetPosition[5] = -1;
        }

        if (nLeftSideLimit >= 0)
        {
            arFirstStepTargetPosition[6] = ThisPieceTileNumber + nLeftInterval;
            int nNextStepPosition = arFirstStepTargetPosition[6] + 8;
            if (nNextStepPosition < 64)
            {
                arSecondStepTargetPosition[6] = arFirstStepTargetPosition[6] + 8;
            }
            else
            {
                arSecondStepTargetPosition[6] = -1;
            }

            arFirstStepTargetPosition[7] = ThisPieceTileNumber + nLeftInterval;
            nNextStepPosition = arFirstStepTargetPosition[7] - 8;
            if (nNextStepPosition >= 0)
            {
                arSecondStepTargetPosition[7] = arFirstStepTargetPosition[7] - 8;
            }
            else
            {
                arSecondStepTargetPosition[7] = -1;
            }

        }
        else if (nLeftSideLimit < 0)
        {
            arSecondStepTargetPosition[6] = -1;
            arSecondStepTargetPosition[7] = -1;
        }


        int nPossibleTargetPosition = 0;

        for (int i = 0; i < nMaxMovePointCount; i++)
        {
            if(arSecondStepTargetPosition[i] >=0 && arSecondStepTargetPosition[i] < 64)
            {
                nPossibleTargetPosition++;
            }
        }

        Debug.Log("Possible target pos : " + nPossibleTargetPosition);

        GameObject[] MovablePoint = new GameObject[nMaxMovePointCount];

        for (int i = 0; i < nMaxMovePointCount; i++)
        {

            MovablePoint[i] = Instantiate(chessPieceMovablePointPrefab);
            createdMovablePoint.Add(MovablePoint[i]);

            nTargetTileNumber = arSecondStepTargetPosition[i];


            if (nTargetTileNumber < 64 && nTargetTileNumber >= 0)
            {

                MovablePoint[i].transform.SetParent(chessBoardTile[nTargetTileNumber].transform);

            }
            else
            {
                Debug.Log("nTargetTileNumber is out of range.. : " + nTargetTileNumber);
                MovablePoint[i].SetActive(false);
            }

            MovablePoint[i].GetComponent<RectTransform>().localPosition = posParentPosition;

        }


    }

    void MakeMovePoint_Bishop(int nTargetTileNumber, Vector3 posParentPosition)
    {
        int nThisPieceTileNumber;
        nThisPieceTileNumber = CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber;

        int nCurrentPieceTileNumber = 0;
        nCurrentPieceTileNumber = nThisPieceTileNumber;

        int nNextNumber = 0;
        nNextNumber = nCurrentPieceTileNumber + 8;

        int nRemainder = 0;
        nRemainder = (nCurrentPieceTileNumber - 1) % 8;

        int nBishopMovePointCount = 0;

        while(nRemainder != 7 && nNextNumber < 64)
        {
            nBishopMovePointCount++;
            nCurrentPieceTileNumber = (nCurrentPieceTileNumber - 1) + 8;
            nRemainder = (nCurrentPieceTileNumber - 1) % 8;
            nNextNumber = nCurrentPieceTileNumber + 8;

            Debug.Log("nCurrentPieceTileNumber : " + nCurrentPieceTileNumber);
        }

        Debug.Log("Left Up Movable point count : " + nBishopMovePointCount);

        GameObject[] LeftUpMovablePoint = new GameObject[nBishopMovePointCount];

        int nUpInterval = 8;
        int nLeftInterval = -1;

        nTargetTileNumber = CurrentSelectedPiece.GetComponent<ChessPiece>().nCurrentTileNumber;

        for (int i = 0; i < nBishopMovePointCount; i++)
        {
            LeftUpMovablePoint[i] = Instantiate(chessPieceMovablePointPrefab);
            createdMovablePoint.Add(LeftUpMovablePoint[i]);

            nTargetTileNumber = nTargetTileNumber + nUpInterval + nLeftInterval;
            LeftUpMovablePoint[i].transform.SetParent(chessBoardTile[nTargetTileNumber].transform);
            LeftUpMovablePoint[i].GetComponent<RectTransform>().localPosition = posParentPosition;

        }


    }

    void MakeMovePoint_Queen(int nTargetTileNumber, Vector3 posParentPosition)
    {

    }

    void MakeMovePoint_King(int nTargetTileNumber, Vector3 posParentPosition)
    {

    }

}