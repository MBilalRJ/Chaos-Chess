using UnityEngine;

public class TrojanHorse : Knight
{
    public override void MoveTo(Vector2Int newPosition)
    {
        base.MoveTo(newPosition);

        // Check if the knight reached the last rank
        if ((isWhite && newPosition.y == 7) || (!isWhite && newPosition.y == 0))
        {
            // Destroy the knight
            Destroy(gameObject);

            // Spawn enemy pawns in the specified formation
            SpawnTrojanHorsePawns(newPosition);
        }
    }
    private void SpawnTrojanHorsePawns(Vector2Int position)
    {
        // Determine the prefab to use based on the knight's side
        GameObject pawnPrefab = isWhite ? gameManager.whiteTrojanHorsePawn : gameManager.blackTrojanHorsePawn;

        // Calculate positions for the pawns
        Vector2Int leftPosition = new Vector2Int(position.x - 1, position.y);
        Vector2Int rightPosition = new Vector2Int(position.x + 1, position.y);
        Vector2Int centerPosition = new Vector2Int(position.x, position.y);

        // Check each position and spawn pawns only if they are in bounds
        if (gameManager.IsSquareEmpty(leftPosition))
        {
            gameManager.SpawnPiece(pawnPrefab, leftPosition, isWhite);
        }
        if (gameManager.IsSquareEmpty(rightPosition))
        {
            gameManager.SpawnPiece(pawnPrefab, rightPosition, isWhite);
        }
        if (gameManager.IsInBounds(centerPosition))
        {
            gameManager.SpawnPiece(pawnPrefab, centerPosition, isWhite);
        }
    }
    //private void SpawnTrojanHorsePawns(Vector2Int position)
    //{
    //    // Determine the prefab to use based on the knight's side
    //    GameObject pawnPrefab = isWhite ? gameManager.whiteTrojanHorsePawn : gameManager.blackTrojanHorsePawn;

    //    // Calculate positions for the pawns
    //    Vector2Int leftPosition = new Vector2Int(position.x - 1, position.y);
    //    Vector2Int rightPosition = new Vector2Int(position.x + 1, position.y);
    //    Vector2Int center = new Vector2Int(position.x, position.y);

    //    // Spawn pawns based on the knight's side
    //    gameManager.SpawnPiece(pawnPrefab, leftPosition, isWhite);
    //    gameManager.SpawnPiece(pawnPrefab, rightPosition, isWhite);
    //    gameManager.SpawnPiece(pawnPrefab, center, isWhite);
    //}
}
