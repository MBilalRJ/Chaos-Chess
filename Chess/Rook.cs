using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves()
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        // Directions the rook can move: up, down, left, right
        Vector2Int[] directions = {
            new Vector2Int(0, 1),   // Up
            new Vector2Int(0, -1),  // Down
            new Vector2Int(1, 0),   // Right
            new Vector2Int(-1, 0)   // Left
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
                    // Check if it’s an enemy piece
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
