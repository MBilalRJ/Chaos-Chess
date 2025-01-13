using System.Collections.Generic;
using UnityEngine;

public class ChoasBishop : Bishop
{
    private TileHighlighter tileHighlighter; // Reference to TileHighlighter
    private bool showingSpecialMoves = false;

    private void Start()
    {
        // Find the TileHighlighter in the scene
        tileHighlighter = FindFirstObjectByType<TileHighlighter>();

        if (tileHighlighter == null)
        {
            Debug.LogError("TileHighlighter not found in the scene.");
        }
    }

    private void Update()
    {
        // Right-click toggles the display of special moves
        if (Input.GetMouseButtonDown(1))
        {
            if (IsSelected()) // Check if the piece is selected
            {
                showingSpecialMoves = !showingSpecialMoves;

                if (showingSpecialMoves)
                {
                    // Display special moves
                    List<Vector2Int> specialMoves = GetSpecialMoves();
                    tileHighlighter.ShowHighlights(specialMoves, GameManager.Instance.boardParent); // Use TileHighlighter to show highlights
                    Debug.Log("Showing special moves.");
                }
                else
                {
                    // Clear special move highlights
                    tileHighlighter.ClearHighlights();
                    Debug.Log("Special moves cleared.");
                }
            }
        }
    }

    // Override to add special moves (1 square in cardinal directions)
    public override List<Vector2Int> GetSpecialMoves()
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        Vector2Int[] directions = {
            new Vector2Int(0, 1),  // Up
            new Vector2Int(0, -1), // Down
            new Vector2Int(1, 0),  // Right
            new Vector2Int(-1, 0), // Left
        };

        foreach (var direction in directions)
        {
            Vector2Int target = currentPosition + direction;

            if (GameManager.Instance.IsInBounds(target) && GameManager.Instance.IsSquareEmpty(target))
            {
                moves.Add(target);
            }
        }

        return moves;
    }

    private bool IsSelected()
    {
        // Check if this piece is the currently selected piece in the GameManager
        return GameManager.Instance.selectedPiece == this;
    }
    public void ClearSpecialHighlights()
    {
        if (showingSpecialMoves)
        {
            tileHighlighter.ClearHighlights();
            showingSpecialMoves = false; // Reset the state
            Debug.Log("Special highlights cleared.");
        }
    }
}
