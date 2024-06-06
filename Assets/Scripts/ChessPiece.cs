using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMyInfo()
    {
        Debug.Log("Owner:" + nOwnPlayerNumber + ", Piecetype:" + currentPieceType);
    }
}
