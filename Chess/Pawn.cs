using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public bool hasMoved = false;

    public override List<Vector2Int> GetAvailableMoves()
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        // Movement direction based on color
        int direction = isWhite ? 1 : -1;

        // Forward move
        Vector2Int forwardMove = new Vector2Int(currentPosition.x, currentPosition.y + direction);
        if (gameManager == null)
        {
            Debug.LogError("GameManager is null,in available moves");

        }

            if (gameManager.IsInBounds(forwardMove) && gameManager.IsSquareEmpty(forwardMove))
            {
                moves.Add(forwardMove);

                // Double forward move (only if the pawn hasn't moved)
                Vector2Int doubleForwardMove = new Vector2Int(currentPosition.x, currentPosition.y + 2 * direction);
                if (!hasMoved && gameManager.IsInBounds(doubleForwardMove) && gameManager.IsSquareEmpty(doubleForwardMove))
                {
                    moves.Add(doubleForwardMove);
                }
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
        hasMoved = true;
        Debug.Log($"Pawn moved to {newPosition}");
    }
}
