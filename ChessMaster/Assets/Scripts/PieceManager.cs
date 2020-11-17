using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    public GameObject piecePrefab;
    private List<BasePiece> whitePieces = null;
    private List<BasePiece> blackPieces = null;

    private string[] pieceOrder = new string[16]
    {
        "P","P","P","P","P","P","P","P",
        "R","Kn","B","Q","Q","B","Kn","R"
    };

    private Dictionary<string, Type> pieceLibrary = new Dictionary<string, Type>
    {
        {"P", typeof(Pawn)},
        {"R", typeof(Rook)},
        {"Kn", typeof(Knight)},
        {"B", typeof(Bishop)},
        {"K", typeof(King)},
        {"Q", typeof(Queen)}

    };

    public void Setup(Board board)
    {
        whitePieces = CreatePieces(Color.white, new Color32(80, 124, 159, 255), board);
        blackPieces = CreatePieces(Color.black, new Color32(210, 95, 64, 255), board);

        PlacePieces(1, 0, whitePieces, board);
        PlacePieces(6, 7, blackPieces, board);
    }

    private List<BasePiece> CreatePieces(Color teamColor, Color32 spriteColor, Board board)
    {
        List<BasePiece> pieces = new List<BasePiece>();
        for(int i=0; i<pieceOrder.Length; i++)
        {
            GameObject pieceObject = Instantiate(piecePrefab);
            pieceObject.transform.SetParent(transform);

            pieceObject.transform.localScale = new Vector3(1, 1, 1);
            pieceObject.transform.localRotation = Quaternion.identity;
            string key = pieceOrder[i];
            Type pieceType = pieceLibrary[key];
            BasePiece newPiece = (BasePiece)pieceObject.AddComponent(pieceType);
            pieces.Add(newPiece);
            newPiece.Setup(teamColor, spriteColor, this);
        }

        return pieces;
    }

    private void PlacePieces(int pawnRow, int royaltyRow, List<BasePiece> basePieces, Board board)
    {
        for(int i=0; i<8; i++)
        {
            basePieces[i].Place(board.mAllCells[i, pawnRow]);
            basePieces[i + 8].Place(board.mAllCells[i, royaltyRow]);
        }
    }
}
