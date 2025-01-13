using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves()
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        // All possible L-shaped moves relative to the Knight's position
        Vector2Int[] knightMoves = {
            new Vector2Int(2, 1),   // Move 2 right, 1 up
            new Vector2Int(2, -1),  // Move 2 right, 1 down
            new Vector2Int(-2, 1),  // Move 2 left, 1 up
            new Vector2Int(-2, -1), // Move 2 left, 1 down
            new Vector2Int(1, 2),   // Move 1 right, 2 up
            new Vector2Int(-1, 2),  // Move 1 left, 2 up
            new Vector2Int(1, -2),  // Move 1 right, 2 down
            new Vector2Int(-1, -2)  // Move 1 left, 2 down
        };

        // Check each potential move
        foreach (var move in knightMoves)
        {
            Vector2Int targetPosition = currentPosition + move;

            if (gameManager.IsInBounds(targetPosition))
            {
                // If the square is empty or contains an enemy piece, it's valid
                if (gameManager.IsSquareEmpty(targetPosition) || gameManager.IsEnemyPiece(targetPosition, isWhite))
                {
                    moves.Add(targetPosition);
                }
            }
        }
        Debug.Log($"Knight's available moves: {string.Join(", ", moves)}");
        return moves;
    }
}
