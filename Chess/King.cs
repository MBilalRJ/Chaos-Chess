using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class King : ChessPiece
{
   
    public override List<Vector2Int> GetAvailableMoves()
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        // All 8 possible directions the King can move
        Vector2Int[] directions = {
            new Vector2Int(1, 0),   // Right
            new Vector2Int(-1, 0),  // Left
            new Vector2Int(0, 1),   // Up
            new Vector2Int(0, -1),  // Down
            new Vector2Int(1, 1),   // Top-right
            new Vector2Int(1, -1),  // Bottom-right
            new Vector2Int(-1, 1),  // Top-left
            new Vector2Int(-1, -1)  // Bottom-left
        };

        // Check each direction
        foreach (var direction in directions)
        {
            Vector2Int targetPosition = currentPosition + direction;

            // If it's within bounds and either empty or contains an enemy piece, add it
            if (gameManager.IsInBounds(targetPosition) && (gameManager.IsSquareEmpty(targetPosition) || gameManager.IsEnemyPiece(targetPosition, isWhite)))
            {
                moves.Add(targetPosition);
            }
        }

        return moves;
    }
}

