using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BasePiece : EventTrigger
{
    public Color color = Color.clear;

    protected Cell originalCell = null, currentCell = null;
    protected RectTransform rectTransform = null;
    protected PieceManager pieceManager;

    protected Vector3Int movement = Vector3Int.one;
    protected List<Cell> cells = new List<Cell>();


    public virtual void Setup(Color teamColor, Color32 spriteColor, PieceManager newPieceManager)
    {
        pieceManager = newPieceManager;
        color = teamColor;
        GetComponent<Image>().color = spriteColor;
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

    private void CreatePath(int x, int y, int movement)
    {
        int posX = currentCell.mBoardPosition.x;
        int posY = currentCell.mBoardPosition.y;

        for (int i=1; i<=movement; i++)
        {
            posX += x;
            posY += y;

            try
            {
                cells.Add(currentCell.mBoard.mAllCells[x, y]);
            }
            catch { };

        }
    }

    protected virtual void CheckingPath()
    {
        CreatePath(1, 0, movement.x);
        CreatePath(-1, 0, movement.x);

        CreatePath(0, 1, movement.y);
        CreatePath(0, -1, movement.y);

        CreatePath(1, 1, movement.z);
        CreatePath(-1, 1, movement.z);

        CreatePath(-1, -1, movement.z);
        CreatePath(1, -1, movement.z);
    }

    protected void Show()
    {
        foreach (Cell cell in cells)
            cell.mOutlineImage.enabled = true;
    }

    protected void DeleteCells()
    {
        foreach (Cell cell in cells)
            cell.mOutlineImage.enabled = true;

        cells.Clear();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("StartBegin");
        base.OnBeginDrag(eventData);
        CheckingPath();
        Show();
        Debug.Log("StopBegin");
    }

    public override void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Start");
        base.OnDrag(eventData);
        transform.position += (Vector3)eventData.delta;
        Debug.Log("Stop");
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("StartEnd");
        base.OnEndDrag(eventData);
        DeleteCells();
        Debug.Log("End");
    }
}
