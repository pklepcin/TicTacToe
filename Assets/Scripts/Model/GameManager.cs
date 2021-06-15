using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
    private static GameManager instance = null;

    public static GameManager GetInstance() {
        if (instance == null) {
            instance = new GameManager();
        }
        return instance;
    }

    private GameField gameField;
    private bool whoIsNext;
    public event System.Action<int, int, CellType> onCellUpdated;

    private GameManager() {
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