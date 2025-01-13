using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TrojanPawn : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves()
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        // Movement direction based on color
        int direction = isWhite ? -1 : 1;

        // Forward move
        Vector2Int forwardMove = new Vector2Int(currentPosition.x, currentPosition.y + direction);
        if (gameManager == null)
        {
            Debug.LogError("GameManager is null,in available moves");

        }

        if (gameManager.IsInBounds(forwardMove) && gameManager.IsSquareEmpty(forwardMove))
        {
            moves.Add(forwardMove);
        }
        // Capture moves (diagonal)
        Vector2Int[] captureMoves = {
            new Vector2Int(currentPosition.x - 1, currentPosition.y + direction),
            new Vector2Int(currentPosition.x + 1, currentPosition.y + direction)
        };

        foreach (var captureMove in captureMoves)
        {
            if (gameManager == null)
            {
                Debug.LogError("GameManager is null.cannot check for enemy pieces");
                break;
            }
            if (gameManager.IsInBounds(captureMove) && gameManager.IsEnemyPiece(captureMove, isWhite))
            {
                moves.Add(captureMove);
            }
        }

        return moves;
    }

    public override void MoveTo(Vector2Int newPosition)
    {
        base.MoveTo(newPosition);
        Debug.Log($"TrojanPawn moved to {newPosition}");
    }
}
