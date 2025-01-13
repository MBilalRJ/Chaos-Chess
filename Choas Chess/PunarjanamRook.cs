using System.Collections.Generic;
using UnityEngine;

public class PunarJanamRook : Rook
{

    // Track whether the rook has been captured
    public bool isCaptured = false;

    // The original position before it was captured (could be useful for respawn logic if needed)
    private Vector2Int originalPosition;

    // The position where the rook was captured
    private Vector2Int capturedPosition;

    // Update is called once per frame
    //void Update()
    //{
    //    // If the rook is captured, try to respawn it
    //    if (isCaptured)
    //    {
    //        RespawnRook();
    //    }
    //}

    // Mark the rook as captured and store its captured position
    public void CaptureRook(Vector2Int position)
    {
        isCaptured = true;
        capturedPosition = position;
        originalPosition = currentPosition; // Keep track of where the rook was originally
        currentPosition = new Vector2Int(-1, -1); // Remove it from the board
    }

    // Logic to respawn the rook at a random empty position on the board
    //public void RespawnRook()
    //{
    //    // Wait until it's the right time to respawn (e.g., after the player moves)
    //    // if (gameManager.AreMovesAvailableForRebirth(isWhite))
    //    {
    //        List<Vector2Int> availablePositions = GetEmptySquares();

    //        if (availablePositions.Count > 0)
    //        {
    //            // Choose a random position from the available ones
    //            int randomIndex = Random.Range(0, availablePositions.Count);
    //            Vector2Int randomPosition = availablePositions[randomIndex];

    //            // Place the rook at the new position
    //            currentPosition = randomPosition;

    //            // Mark the rook as no longer captured
    //            isCaptured = false;
    //        }
    //    }
    //}

    // Get all empty squares on the board (adjust this depending on your game’s board setup)
    private List<Vector2Int> GetEmptySquares()
    {
        List<Vector2Int> emptySquares = new List<Vector2Int>();

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Vector2Int position = new Vector2Int(x, y);
                if (gameManager.IsSquareEmpty(position))
                {
                    emptySquares.Add(position);
                }
            }
        }

        return emptySquares;
    }

    // Overriding the base method to handle any specific behavior of the RebirthRook
    //public override List<Vector2Int> GetAvailableMoves()
    //{
    //    List<Vector2Int> moves = new List<Vector2Int>();

    //    // Standard Rook movement logic (vertical and horizontal)
    //    Vector2Int[] directions = {
    //        new Vector2Int(1, 0),   // Right
    //        new Vector2Int(-1, 0),  // Left
    //        new Vector2Int(0, 1),   // Up
    //        new Vector2Int(0, -1)   // Down
    //    };

    //    // Check each direction for possible moves
    //    foreach (var direction in directions)
    //    {
    //        Vector2Int targetPosition = currentPosition;

    //        // Move until the end of the board or an obstacle is encountered
    //        while (true)
    //        {
    //            targetPosition += direction;
    //            if (!gameManager.IsInBounds(targetPosition))
    //                break;

    //            // If the square is empty or contains an enemy piece, add it
    //            if (gameManager.IsSquareEmpty(targetPosition) || gameManager.IsEnemyPiece(targetPosition, isWhite))
    //            {
    //                moves.Add(targetPosition);
    //            }

    //            // Stop at the first piece (either friendly or enemy)
    //            if (!gameManager.IsSquareEmpty(targetPosition) && !gameManager.IsEnemyPiece(targetPosition, isWhite))
    //                break;
    //        }
    //    }

    //    return moves;
    //}
}
//using System.Collections.Generic;
//using UnityEngine;

//public class PunarJanamRook : ChessPiece
//{
//    // Track whether the rook has been captured
//    private bool isCaptured = false;

//    // The original position before it was captured (could be useful for respawn logic if needed)
//    private Vector2Int originalPosition;

//    // The position where the rook was captured
//    private Vector2Int capturedPosition;

//    // Mark the rook as captured and store its captured position
//    public void CaptureRook(Vector2Int position)
//    {
//        Debug.Log("CaptureRook called.");
//        Debug.Log($"Capture position: {position}");

//        isCaptured = true;
//        capturedPosition = position;
//        originalPosition = currentPosition; // Keep track of where the rook was originally
//        Debug.Log($"Original position set to: {originalPosition}");
//    }

//    // Logic to respawn the rook at a random empty position on the board
//    private void RespawnRook()
//    {
//        Debug.Log("RespawnRook called.");

//        if (gameManager == null)
//        {
//            Debug.LogError("GameManager is null. Cannot respawn rook.");
//            return;
//        }

//        List<Vector2Int> availablePositions = GetEmptySquares();

//        if (availablePositions.Count > 0)
//        {
//            // Choose a random position from the available ones
//            int randomIndex = Random.Range(0, availablePositions.Count);
//            Vector2Int randomPosition = availablePositions[randomIndex];

//            // Place the rook at the new position
//            currentPosition = randomPosition;
//            Debug.Log($"Rook respawned at position: {randomPosition}");

//            // Mark the rook as no longer captured
//            isCaptured = false;
//        }
//        else
//        {
//            Debug.LogWarning("No available positions to respawn the rook.");
//        }
//    }

//    // Get all empty squares on the board (adjust this depending on your game’s board setup)
//    private List<Vector2Int> GetEmptySquares()
//    {
//        Debug.Log("GetEmptySquares called.");

//        List<Vector2Int> emptySquares = new List<Vector2Int>();

//        if (gameManager == null)
//        {
//            Debug.LogError("GameManager is null. Cannot get empty squares.");
//            return emptySquares;
//        }

//        for (int x = 0; x < 8; x++)
//        {
//            for (int y = 0; y < 8; y++)
//            {
//                Vector2Int position = new Vector2Int(x, y);
//                if (gameManager.IsSquareEmpty(position))
//                {
//                    emptySquares.Add(position);
//                }
//            }
//        }

//        Debug.Log($"Found {emptySquares.Count} empty squares.");
//        return emptySquares;
//    }

//    // Overriding the base method to handle any specific behavior of the RebirthRook
//    public override List<Vector2Int> GetAvailableMoves()
//    {
//        Debug.Log("GetAvailableMoves called.");

//        List<Vector2Int> moves = new List<Vector2Int>();

//        if (gameManager == null)
//        {
//            Debug.LogError("GameManager is null. Cannot calculate available moves.");
//            return moves;
//        }

//        // Standard Rook movement logic (vertical and horizontal)
//        Vector2Int[] directions = {
//            new Vector2Int(1, 0),   // Right
//            new Vector2Int(-1, 0),  // Left
//            new Vector2Int(0, 1),   // Up
//            new Vector2Int(0, -1)   // Down
//        };

//        // Check each direction for possible moves
//        foreach (var direction in directions)
//        {
//            Vector2Int targetPosition = currentPosition;

//            while (true)
//            {
//                targetPosition += direction;

//                if (!gameManager.IsInBounds(targetPosition))
//                {
//                    Debug.Log($"Position {targetPosition} is out of bounds.");
//                    break;
//                }

//                if (gameManager.IsSquareEmpty(targetPosition))
//                {
//                    Debug.Log($"Position {targetPosition} is empty.");
//                    moves.Add(targetPosition);
//                }
//                else if (gameManager.IsEnemyPiece(targetPosition, isWhite))
//                {
//                    Debug.Log($"Position {targetPosition} has an enemy piece.");
//                    moves.Add(targetPosition);
//                    break;
//                }
//                else
//                {
//                    Debug.Log($"Position {targetPosition} is blocked by a friendly piece.");
//                    break;
//                }
//            }
//        }

//        Debug.Log($"Available moves count: {moves.Count}");
//        return moves;
//    }
//}
