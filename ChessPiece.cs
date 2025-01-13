using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    public bool isWhite;
    public Vector2Int currentPosition;
    //changed from protected to public for some test run
    protected GameManager gameManager;

   
    public virtual void Initialize(bool isWhite, Vector2Int startPosition, GameManager gm)
    {
        this.isWhite = isWhite;
        currentPosition = startPosition;
        gameManager = gm;
        transform.position = gameManager.GetWorldPosition(startPosition);

        if (gameManager == null)
        {
            Debug.LogError("GameManager reference is null in ChessPiece!");
        }
    }

    public virtual List<Vector2Int> GetAvailableMoves()
    {
        return new List<Vector2Int>();
    }
    public virtual List<Vector2Int> GetSpecialMoves()
    {
        return new List<Vector2Int>();
    }

    public virtual void MoveTo(Vector2Int newPosition)
    {
        Debug.Log($"Moving piece from {currentPosition} to {newPosition}");
        currentPosition = newPosition;
        transform.position = gameManager.GetWorldPosition(newPosition);
    }

    private void OnMouseDown()
    {
        Debug.Log($"Clicked on {name} at {currentPosition}");
        GameManager.Instance.SelectPiece(this);
    }
    //
    public Vector2Int CurrentPosition { get; private set; }

    public void SetPosition(Vector2Int newPosition)
    {
        CurrentPosition = newPosition;

        float tileSize = 10.8f / 8f; // Adjust based on your board tile size
        float boardOffsetX = -4.725f; // Center the board (assuming 8x8)
        float boardOffsetY = -4.725f;

        transform.position= new Vector3(CurrentPosition.x * tileSize + boardOffsetX, CurrentPosition.y * tileSize + boardOffsetY, -1);
       // transform.position = new Vector3(position.x,position.y,0); // Adjust the Y-axis as needed.
    }

}
