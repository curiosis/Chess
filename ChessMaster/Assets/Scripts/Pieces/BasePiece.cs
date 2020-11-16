using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasePiece : EventTrigger
{
    public Color color = Color.clear;

    protected Cell originalCell = null, currentCell = null;
    protected RectTransform rectTransform = null;
    protected PieceManager pieceManager;

    public virtual void Setup(Color teamColor, Color32 spriteColor, PieceManager newPieceManager)
    {
        pieceManager = newPieceManager;
        color = teamColor;
        rectTransform = GetComponent<RectTransform>();
    }

    public void Place(Cell cell)
    {
        currentCell = cell;
        originalCell = cell;
        currentCell.mCurrentPiece = this;

        transform.position = cell.transform.position;
        gameObject.SetActive(true);
    }

}
