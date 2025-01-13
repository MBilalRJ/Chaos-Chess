using System.Collections.Generic;
using UnityEngine;

public class AtomicPawn : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves()
    {
        List<Vector2Int> moves = new List<Vector2Int>();
        Vector2Int forwardMove = currentPosition + Vector2Int.up * (isWhite ? 1 : -1);

        Debug.Log($"Calculating moves for AtomicPawn at {currentPosition}");

        // Forward move
        if (GameManager.Instance.IsSquareEmpty(forwardMove))
        {
            moves.Add(forwardMove);
            Debug.Log($"Added forward move to {forwardMove}");

            // Allow double move if the pawn is on its starting row
            if ((isWhite && currentPosition.y == 1) || (!isWhite && currentPosition.y == 6))
            {
                Vector2Int doubleMove = forwardMove + Vector2Int.up * (isWhite ? 1 : -1);
                if (GameManager.Instance.IsSquareEmpty(doubleMove))
                {
                    moves.Add(doubleMove);
                    Debug.Log($"Added double forward move to {doubleMove}");
                }
            }
        }

        // Capture diagonally
        Vector2Int[] diagonalMoves = {
            currentPosition + new Vector2Int(1, isWhite ? 1 : -1),
            currentPosition + new Vector2Int(-1, isWhite ? 1 : -1)
        };

        foreach (Vector2Int move in diagonalMoves)
        {
            if (GameManager.Instance.IsEnemyPiece(move, isWhite))
            {
                moves.Add(move);
                Debug.Log($"Added capture move for AtomicPawn to {move}");
            }
        }

        Debug.Log($"Available moves for AtomicPawn: {string.Join(", ", moves)}");
        return moves;
    }

    public override void MoveTo(Vector2Int newPosition)
    {
        Debug.Log($"Moving AtomicPawn from {currentPosition} to {newPosition}");

        Vector2Int oldPosition = currentPosition;

        GameObject targetPiece = GameManager.Instance.board[newPosition.x, newPosition.y];
        if (targetPiece != null)
        {
            ChessPiece targetChessPiece = targetPiece.GetComponent<ChessPiece>();
            if (targetChessPiece != null)
            {
                if (targetChessPiece != null && targetChessPiece.isWhite != this.isWhite)
                {
                    Debug.Log($"Capturing piece at {newPosition}");
                    Explode(newPosition);

                }

            }
            
        }
        // Update board state
        GameManager.Instance.board[oldPosition.x, oldPosition.y] = null;
        GameManager.Instance.board[newPosition.x, newPosition.y] = this.gameObject;

        currentPosition = newPosition;
        transform.position = GameManager.Instance.GetWorldPosition(newPosition);

        Debug.Log($"AtomicPawn moved to {newPosition}");
    }

    public void Explode(Vector2Int centerPosition)
    {
        Debug.Log($"Explosion triggered by AtomicPawn at {centerPosition}");

        Vector2Int[] explosionOffsets = {
            new Vector2Int(-1, -1), new Vector2Int(0, -1), new Vector2Int(1, -1),
            new Vector2Int(-1,  0),                       new Vector2Int(1,  0),
            new Vector2Int(-1,  1), new Vector2Int(0,  1), new Vector2Int(1,  1)
        };

        foreach (Vector2Int offset in explosionOffsets)
        {
            Vector2Int targetPosition = centerPosition + offset;

            if (GameManager.Instance.IsInBounds(targetPosition))
            {
                GameObject targetPiece = GameManager.Instance.board[targetPosition.x, targetPosition.y];
                if (targetPiece != null)
                {
                    Destroy(targetPiece);
                    Debug.Log($"Destroyed piece at {targetPosition} due to explosion!");
                    GameManager.Instance.board[targetPosition.x, targetPosition.y] = null;
                }
            }
        }

        Debug.Log($"Explosion completed at {centerPosition}");
    }
}
