using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    private GameField gameField;
    private bool whoIsNext;
    public event System.Action<int, int, CellType> onCellUpdated;

    public GameManager() {
        gameField = new GameField();
        whoIsNext = true;
    }

    public void NextAction (GameAction action) {
        if (gameField.IsEmpty(action.col, action.row)) {
            var type = whoIsNext ? CellType.X : CellType.O;
            gameField.Put(action.col, action.row, type);
            onCellUpdated?.Invoke(action.col, action.row, type);
            whoIsNext = !whoIsNext;
        }
    }

    public bool IsOver() {
        return gameField.Has3InLine() || gameField.GetPossibleAction().Count == 0;
    }
}