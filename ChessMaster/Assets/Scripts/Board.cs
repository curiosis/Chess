using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject mCellPrefab;
    public Cell[,] mAllCells = new Cell[12, 12];

    public void Create()
    {
        for(int i=0; i<12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                GameObject newCell = Instantiate(mCellPrefab, transform);
                RectTransform rectTransform = newCell.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((i * 100) + 50, (j * 100) + 50);
                mAllCells[i, j] = newCell.GetComponent<Cell>();
                mAllCells[i, j].Setup(new Vector2Int(i, j), this);
            }
        }

        for(int i=0; i<12; i += 2)
        {
            for(int j=0; j<12; j++)
            {
                int offset = (j % 2 != 0) ? 0 : 1;
                int finalX = i + offset;

                mAllCells[finalX, j].GetComponent<Image>().color = new Color32(230, 220, 187, 255);
            }
        }
    }

}
