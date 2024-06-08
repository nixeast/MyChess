using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject currentGameManagerObject;
    public GameManager currentGameManager;
    public int nCurrentTileNumber;
    //bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        currentGameManagerObject = GameObject.Find("GameManager");
        currentGameManager = currentGameManagerObject.GetComponent<GameManager>();
        //isSelected = false;
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
        if(currentGameManager.CurrentSelectedPiece == null)
        {
            currentGameManager.CurrentSelectedPiece = this.gameObject;
            currentGameManager.ShowCurrentPieceMoveRange(currentPieceType);

            ChangePieceColorTransparency(true);

        }
        else if(currentGameManager.CurrentSelectedPiece == true)
        {
            currentGameManager.DestroyCurrentPieceMoveRange();
        }

    }

    public void ChangePieceColorTransparency(bool isTransparency)
    {
        Color changedColor = this.GetComponent<Image>().color;

        if (isTransparency == true)
        {
            changedColor.a = 0.5f;
        }
        else if (isTransparency == false)
        {
            changedColor.a = 1.0f;
        }

        this.GetComponent<Image>().color = changedColor;

    }
}
