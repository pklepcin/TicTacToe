using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    const int FILED_WIDTH = 3;
    [SerializeField]
    private SpriteRenderer[] cells;
    [SerializeField]
    private Sprite[] cellSprites;
    void Start() {
        for (var i = 0; i < cells.Length; i++ ) {
            cells[i].sprite = GetSpriteByType(CellType.Empty);
        }
    }

    public void SetCell(int col, int row, CellType type) {
        var cell = cells[col + row * FILED_WIDTH];
        cell.sprite = GetSpriteByType(type);
    }

    private Sprite GetSpriteByType(CellType type) {
        switch (type) {
            case CellType.X: return cellSprites[0];
            case CellType.O: return cellSprites[1];
            default: return cellSprites[2];
        }
    }
    public (int col, int row) GetCellByCoord(float x, float y) {
        var col = Mathf.FloorToInt(x - transform.position.x);
        var row = Mathf.FloorToInt(transform.position.y - y);
        return (col, row);
    }
}
