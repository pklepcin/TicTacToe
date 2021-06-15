using System.Collections;
using System.Collections.Generic;

public enum CellType {
    X,
    O,
    Empty
}
public class GameField {
    private CellType[,] field;

    public GameField() {
        field = new CellType[3, 3];
        for (var i = 0; i < field.GetLength(0); i++) {
            for (var j = 0; j < field.GetLength(1); j++) {
                field[i, j] = CellType.Empty;
            }
        }
    }

    public void Put(int col, int row, CellType cell) {
        field[col, row] = cell;
    }

    public bool IsEmpty (int col, int row) {
        return field[col, row] == CellType.Empty;
    }

    public List<GameAction> GetPossibleAction() {
        var res = new List<GameAction>();
        for (var i = 0; i < field.GetLength(0); i++) {
            for (var j = 0; j < field.GetLength(1); j++) {
                if (field[i, j] == CellType.Empty) {
                    res.Add(new GameAction(i, j));
                }
            }
        }
        return res;
    }

    public bool Has3InLine() {
        var case1 = field[0, 0] == field[0, 1] && field[0, 0] == field[0, 2] && field[0, 0] != CellType.Empty;
        var case2 = field[1, 0] == field[1, 1] && field[1, 0] == field[1, 2] && field[1, 0] != CellType.Empty;
        var case3 = field[2, 0] == field[2, 1] && field[2, 0] == field[2, 2] && field[2, 0] != CellType.Empty;

        var case4 = field[0, 0] == field[1, 0] && field[0, 0] == field[2, 0] && field[0, 0] != CellType.Empty;
        var case5 = field[0, 1] == field[1, 1] && field[0, 1] == field[2, 1] && field[0, 1] != CellType.Empty;
        var case6 = field[0, 2] == field[1, 2] && field[0, 2] == field[2, 2] && field[0, 2] != CellType.Empty;

        var case7 = field[0, 0] == field[1, 1] && field[0, 0] == field[2, 2] && field[0, 0] != CellType.Empty;
        var case8 = field[0, 2] == field[1, 1] && field[0, 2] == field[2, 0] && field[0, 2] != CellType.Empty;

        return case1 || case2 || case3 || case4 || case5 || case6 || case7 || case8;
    }
}