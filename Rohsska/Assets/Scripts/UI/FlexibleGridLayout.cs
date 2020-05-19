using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    public enum FitTyp
    {
        Uniform,
        Width,
        Height,
        FixedRows,
        FixedColoums
    }

    public FitTyp fitType;
    public int rows;
    public int coloums;
    public Vector2 cellSize;
    public Vector2 spacing;
    public bool fitX;
    public bool fitY;

    public override void CalculateLayoutInputVertical()
    {
        base.CalculateLayoutInputHorizontal();
        
        if (fitType == FitTyp.Width || fitType == FitTyp.Height || fitType == FitTyp.Uniform)
        {
            float sqrRt = Mathf.Sqrt(transform.childCount);
            rows = Mathf.CeilToInt(sqrRt);
            coloums = Mathf.CeilToInt(sqrRt);
        }

        if (fitType == FitTyp.Width || fitType == FitTyp.FixedColoums)
        {
            rows = Mathf.CeilToInt(transform.childCount / (float)coloums);
        }

        if (fitType == FitTyp.Height || fitType == FitTyp.FixedRows)
        {
            coloums = Mathf.CeilToInt(transform.childCount / (float)rows);
        }

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cellWidth = (parentWidth / (float)coloums) - ((spacing.x / (float)coloums) * 2) - (padding.left / (float)coloums) - (padding.right / (float)coloums);
        float cellHeight = (parentHeight / (float)rows) - ((spacing.y / (float)rows) * 2) - (padding.top / (float)rows) - (padding.bottom / (float)rows);

        cellSize.x = fitX ? cellWidth : cellSize.x;
        cellSize.y = fitY ? cellHeight : cellSize.y;

        int columnCount = 0;
        int rowCount = 0;

        for (int i = 0; i < rectChildren.Count; i++)
        {
            rowCount = i / coloums;
            columnCount = i % coloums;

            var item = rectChildren[i];

            var xPos = (cellSize.x * columnCount) + (spacing.x * columnCount) + padding.left;
            var yPos = (cellSize.y * rowCount) + (spacing.y * rowCount) + padding.top;

            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);
        }
    }

    public override void SetLayoutHorizontal()
    {

    }

    public override void SetLayoutVertical()
    {

    }


}
