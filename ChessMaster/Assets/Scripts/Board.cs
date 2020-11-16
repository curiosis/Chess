using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public static int boardSize = 8;
    public GameObject mCellPrefab;
    public Cell[,] mAllCells = new Cell[boardSize, boardSize];

    public void Create()
    {
        for(int i=0; i< boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                GameObject newCell = Instantiate(mCellPrefab, transform);
                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((i * 100) + 50, (j * 100) + 50);
                mAllCells[i, j] = newCell.GetComponent<Cell>();
                mAllCells[i, j].Setup(new Vector2Int(i, j), this);
                mAllCells[i, j].GetComponent<Image>().color = new Color32(83, 62, 45, 255);
            }
        }
        
        for (int i=0; i< boardSize; i += 2)
        {
            for(int j=0; j< boardSize; j++)
            {
                int offset = (j % 2 != 0) ? 0 : 1;
                int finalX = i + offset;
                mAllCells[finalX, j].GetComponent<Image>().color = new Color32(221, 202, 125, 255);
            }
        }
    }

}
