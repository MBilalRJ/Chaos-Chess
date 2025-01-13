using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves()
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        // Directions the bishop can move diagonally
        Vector2Int[] directions = {
            new Vector2Int(1, 1),   // Top-right
            new Vector2Int(1, -1),  // Bottom-right
            new Vector2Int(-1, 1),  // Top-left
            new Vector2Int(-1, -1)  // Bottom-left
        };

        foreach (var direction in directions)
        {
            Vector2Int current = currentPosition;

            while (true)
            {
                current += direction;

                // Stop if out of bounds
                if (!gameManager.IsInBounds(current))
                    break;

                // Stop if square is occupied
                if (!gameManager.IsSquareEmpty(current))
                {
                    // Check if it's an enemy piece
                    if (gameManager.IsEnemyPiece(current, isWhite))
                        moves.Add(current);

                    break; // Stop after finding a piece (can't move past it)
                }

                // Add the empty square as a valid move
                moves.Add(current);
            }
        }

        return moves;
    }
}
