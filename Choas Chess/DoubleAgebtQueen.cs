using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DoubleAgebtQueen : Queen
{
public override void MoveTo(Vector2Int newPosition)
    {
        base.MoveTo(newPosition);

        // Check if the queen crossed the 4th row
        if ((isWhite && newPosition.y > 3) || (!isWhite && newPosition.y < 4))
        {
            // Destroy the current queen
            Destroy(gameObject);

            // Decide the prefab and new color for the spawned queen
            GameObject queenPrefab = isWhite ? gameManager.blackDAQueen : gameManager.whiteDAQueen;
            bool newSide = !isWhite;

            // Spawn the opposing queen at the same position
            gameManager.SpawnPiece(queenPrefab, newPosition, newSide);
            Debug.Log($"Queen switched sides and became {(newSide ? "Black" : "White")} at {newPosition}.");
        }
    }
}