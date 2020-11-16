using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Board mBoard;
    public PieceManager pieceManager;

    private void Start()
    {
        mBoard.Create();
        pieceManager.Setup(mBoard);

    }
}
