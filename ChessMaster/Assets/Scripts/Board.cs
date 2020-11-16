using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject mCellPrefab;
    public Cell[,] mAllCells = new Cell[8, 8];

    public void Create()
    {
        for(int i=0; i< 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject newCell = Instantiate(mCellPrefab, transform);
                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((j * 100) + 50, (i * 100) + 50);
                mAllCells[j, i] = newCell.GetComponent<Cell>();
                mAllCells[j, i].Setup(new Vector2Int(j, i), this);
                mAllCells[j, i].GetComponent<Image>().color = new Color32(83, 62, 45, 255);
            }
        }
        
        for (int i=0; i< 8; i += 2)
        {
            for(int j=0; j< 8; j++)
            {
                int offset = (j % 2 != 0) ? 0 : 1;
                int finalX = i + offset;
                mAllCells[finalX, j].GetComponent<Image>().color = new Color32(221, 202, 125, 255);
            }
        }
    }

}
