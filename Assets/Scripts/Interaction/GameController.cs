using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private FieldController fieldController;
    [SerializeField]
    private GameObject gameOverObject;
    void Start ()
    {
        var manager = GameManager.GetInstance();
        manager.onCellUpdated += UpdateField;
        StartCoroutine(GameLoop());
    }
    private void UpdateField (int col, int row, CellType type) {
        fieldController.SetCell (col, row, type);
    }
    private IEnumerator GameLoop() {
        var manager = GameManager.GetInstance();
        while (!manager.IsOver()) {
            yield return StartCoroutine(playerController.NextTurn());
            var lastAction = playerController.GetLastAction();
            var cell = fieldController.GetCellByCoord(lastAction.x, lastAction.y);
            manager.NextAction(new GameAction(cell.col, cell.row));
            yield return null;
        }
        gameOverObject.SetActive(true);
    }
}
