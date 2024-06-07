using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public enum MyPieceTypes
    {
        King,
        Queen,
        Bishop,
        Knight,
        Rook,
        Pawn
    }

    public MyPieceTypes currentPieceType;
    public int nOwnPlayerNumber = 0;
    //public int nMyTypeNumber = 0;
    public GameObject currentGameManagerObject;
    public GameManager currentGameManager;
    public int nCurrentTileNumber;

    // Start is called before the first frame update
    void Start()
    {
        currentGameManagerObject = GameObject.Find("GameManager");
        currentGameManager = currentGameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMyInfo()
    {
        Debug.Log("Owner:" + nOwnPlayerNumber + ", Piecetype:" + currentPieceType);
    }

    public void SetThisPieceSelectedPiece()
    {
        currentGameManager.CurrentSelectedPiece = this.gameObject;
        currentGameManager.ShowCurrentPieceMoveRange();
    }
}
