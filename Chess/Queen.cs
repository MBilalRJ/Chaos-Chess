using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Queen : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves()
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        // Directions for Rook-like movement (horizontal and vertical)
        Vector2Int[] rookDirections = {
            new Vector2Int(1, 0),   // Right
            new Vector2Int(-1, 0),  // Left
            new Vector2Int(0, 1),   // Up
            new Vector2Int(0, -1)   // Down
        };

        // Directions for Bishop-like movement (diagonals)
        Vector2Int[] bishopDirections = {
            new Vector2Int(1, 1),   // Top-right
            new Vector2Int(1, -1),  // Bottom-right
            new Vector2Int(-1, 1),  // Top-left
            new Vector2Int(-1, -1)  // Bottom-left
        };

        // Combine Rook and Bishop directions
        Vector2Int[] directions = new Vector2Int[rookDirections.Length + bishopDirections.Length];
        rookDirections.CopyTo(directions, 0);
        bishopDirections.CopyTo(directions, rookDirections.Length);

        // Add all valid moves for the Queen
        foreach (var direction in directions)
        {
            Vector2Int current = currentPosition;
            while (true)
            {
                current += direction;

                // Break if out of bounds
                if (!gameManager.IsInBounds(current))
                    break;

                // Break if encountering another piece
                if (!gameManager.IsSquareEmpty(current))
                {
                    // Check if it's an enemy piece
                    if (gameManager.IsEnemyPiece(current, isWhite))
                        moves.Add(current); // Add enemy square as a valid move

                    break;
                }

                // Add empty square
                moves.Add(current);
            }
        }

        return moves;
    }
}

