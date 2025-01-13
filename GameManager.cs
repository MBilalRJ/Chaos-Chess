using System.Collections.Generic;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.VisualScripting; // Include for UI elements
using JetBrains.Annotations; // Include for UI elements
//using UnityEditor.Experimental.GraphView;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }
    public AudioClip soundClip; // Assign in Inspector
    private AudioSource audioSource;
    public Vector2Int toReach;
    //public MainMenu mainMenu;

    public GameObject[,] board = new GameObject[8, 8];
    public GameObject[] brownTile = new GameObject[32];
    public GameObject[] greenTile = new GameObject[32];//green tile for normal chess
    public GameObject[] whiteTile = new GameObject[32];
    public GameObject[] grayTile = new GameObject[32];// for normal chess
    public GameObject[] whitePawn = new GameObject[8];
    public GameObject[] blackPawn = new GameObject[8];
    public GameObject[] whiteKnight = new GameObject[2];
    public GameObject[] blackKnight = new GameObject[2];
    public GameObject[] blackBishop = new GameObject[2];
    public GameObject[] whiteBishop = new GameObject[2];
    public GameObject blackQueen;
    public GameObject whiteQueen;
    public GameObject blackKing;
    public GameObject whiteKing;
    public GameObject[] blackRook = new GameObject[2];
    public GameObject[] whiteRook = new GameObject[2];
    //Choas Pieces
    public GameObject whiteHabibiPawn;
    public GameObject blackHabibiPawn;
    public GameObject whiteDAQueen;
    public GameObject blackDAQueen;
    public GameObject whiteTrojanHorse;
    public GameObject blackTrojanHorse;
    public GameObject whiteTrojanHorsePawn;
    public GameObject blackTrojanHorsePawn;
    public GameObject whiteChoasBishop;
    public GameObject blackChoasBishop;
    public GameObject whitePunarJanamRook;
    public GameObject blackPunarJanamRook;

    public Transform boardParent;
    public Transform TileParent;
    public TileHighlighter tileHighlighter;

    private bool isWhiteTurn = true;
    public ChessPiece selectedPiece;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        if (MainMenu.isChoas)
        {
            Debug.Log("CHOAS PLAYED");
            InitializeChoasBoard(); 
            InitializeChoas();
        }
        else
        {
            Debug.Log("Normal PLAYED");
            InitializeChessBoard();
            InitializeChess();  
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float cameraZOffset = Mathf.Abs(Camera.main.transform.position.z);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZOffset));

            //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int clickedTile = GetBoardPositionFromMouse();
                //GetBoardPositionFromm(mousePosition);

            Debug.Log($"Tile clicked: {clickedTile}");
            if (GameManager.Instance.IsInBounds(clickedTile))
            {
                toReach = clickedTile;
                if(clickedTile != null)
                GameManager.Instance.MoveSelectedPiece(clickedTile);
            }
        }
    }
    public void InitializeChoasBoard()
    {

        Debug.Log("InitializeBoard Called");
        for (int i = 0; i < 8; i++)
        {
            int n = 0;
            if (i % 2 != 0)//not even 
            {
                for (int j = 1; j < 8; j += 2)
                {
                    GameObject tileObject = Instantiate(brownTile[n], GetWorldPosition(new Vector2Int(i, j)), Quaternion.identity, TileParent);
                    Tile tile = tileObject.GetComponent<Tile>(); // Get the Tile component
                    tile.boardX = i; // Assign x coordinate
                    tile.boardY = j; // Assign y coordinate
                    n++;
                }
            } else
                for (int j = 0; j < 8; j += 2)
                {
                    GameObject tileObject = Instantiate(brownTile[n], GetWorldPosition(new Vector2Int(i, j)), Quaternion.identity, TileParent);
                    Tile tile = tileObject.GetComponent<Tile>(); // Get the Tile component
                    tile.boardX = i; // Assign x coordinate
                    tile.boardY = j; // Assign y coordinate
                    n++;
                }
        }
        for (int i = 0; i < 8; i++)
        {
            int n = 0;
            if (i % 2 != 0)
            {
                for (int j = 0; j < 8; j += 2)
                {
                    GameObject tileObject = Instantiate(whiteTile[n], GetWorldPosition(new Vector2Int(i, j)), Quaternion.identity, TileParent);
                    Tile tile = tileObject.GetComponent<Tile>(); // Get the Tile component
                    tile.boardX = i; // Assign x coordinate
                    tile.boardY = j; // Assign y coordinate
                    n++;
                }
            }
            else
                for (int j = 1; j < 8; j += 2)
                {
                    GameObject tileObject = Instantiate(whiteTile[n], GetWorldPosition(new Vector2Int(i, j)), Quaternion.identity, TileParent);
                    Tile tile = tileObject.GetComponent<Tile>(); // Get the Tile component
                    tile.boardX = i; // Assign x coordinate
                    tile.boardY = j; // Assign y coordinate
                    n++;
                }
        }
    }
    public void InitializeChessBoard()
    {

        Debug.Log("InitializeBoard Called");
        for (int i = 0; i < 8; i++)
        {
            int n = 0;
            if (i % 2 != 0)//not even 
            {
                for (int j = 1; j < 8; j += 2)
                {
                    GameObject tileObject = Instantiate(greenTile[n], GetWorldPosition(new Vector2Int(i, j)), Quaternion.identity, TileParent);
                    Tile tile = tileObject.GetComponent<Tile>(); // Get the Tile component
                    tile.boardX = i; // Assign x coordinate
                    tile.boardY = j; // Assign y coordinate
                    n++;
                }
            }
            else
                for (int j = 0; j < 8; j += 2)
                {
                    GameObject tileObject = Instantiate(greenTile[n], GetWorldPosition(new Vector2Int(i, j)), Quaternion.identity, TileParent);
                    Tile tile = tileObject.GetComponent<Tile>(); // Get the Tile component
                    tile.boardX = i; // Assign x coordinate
                    tile.boardY = j; // Assign y coordinate
                    n++;
                }
        }
        for (int i = 0; i < 8; i++)
        {
            int n = 0;
            if (i % 2 != 0)
            {
                for (int j = 0; j < 8; j += 2)
                {
                    GameObject tileObject = Instantiate(grayTile[n], GetWorldPosition(new Vector2Int(i, j)), Quaternion.identity, TileParent);
                    Tile tile = tileObject.GetComponent<Tile>(); // Get the Tile component
                    tile.boardX = i; // Assign x coordinate
                    tile.boardY = j; // Assign y coordinate
                    n++;
                }
            }
            else
                for (int j = 1; j < 8; j += 2)
                {
                    GameObject tileObject = Instantiate(grayTile[n], GetWorldPosition(new Vector2Int(i, j)), Quaternion.identity, TileParent);
                    Tile tile = tileObject.GetComponent<Tile>(); // Get the Tile component
                    tile.boardX = i; // Assign x coordinate
                    tile.boardY = j; // Assign y coordinate
                    n++;
                }
        }
    }
    public void InitializeChess()
    {

        SpawnPiece(whiteRook[0], new Vector2Int(0, 0), true); // White Rook 1
        SpawnPiece(whiteRook[1], new Vector2Int(7, 0), true); // White Rook 2
        SpawnPiece(whiteKnight[0], new Vector2Int(1, 0), true); // White Knight 1
        SpawnPiece(whiteKnight[1], new Vector2Int(6, 0), true); // White Knight 2
        SpawnPiece(whiteBishop[0], new Vector2Int(2, 0), true); // White Bishop 1
        SpawnPiece(whiteBishop[1], new Vector2Int(5, 0), true); // White Bishop 2
        SpawnPiece(whiteQueen, new Vector2Int(3, 0), true); // White Queen
        SpawnPiece(whiteKing, new Vector2Int(4, 0), true); // White King

        // Spawn Black Pieces
        SpawnPiece(blackRook[0], new Vector2Int(0, 7), false); // Black Rook 1
        SpawnPiece(blackRook[1], new Vector2Int(7, 7), false); // Black Rook 2
        SpawnPiece(blackKnight[0], new Vector2Int(1, 7), false); // Black Knight 1
        SpawnPiece(blackKnight[1], new Vector2Int(6, 7), false); // Black Knight 2
        SpawnPiece(blackBishop[0], new Vector2Int(2, 7), false); // Black Bishop 1
        SpawnPiece(blackBishop[1], new Vector2Int(5, 7), false); // Black Bishop 2
        SpawnPiece(blackQueen, new Vector2Int(3, 7), false); // Black Queen
        SpawnPiece(blackKing, new Vector2Int(4, 7), false); // Black King

        for (int i = 0; i < 8; i++)
        {
            // Spawn White Pawn
            SpawnPiece(whitePawn[i], new Vector2Int(i, 1), true);

            // Spawn Black Pawn
            SpawnPiece(blackPawn[i], new Vector2Int(i, 6), false);
        }
    }
    public void InitializeChoas()
    {
        SpawnPiece(whitePunarJanamRook, new Vector2Int(0, 0), true); // White Rook 1
        SpawnPiece(whitePunarJanamRook, new Vector2Int(7, 0), true); // White Rook 2
        SpawnPiece(whiteTrojanHorse, new Vector2Int(1, 0), true); // White Knight 1
        SpawnPiece(whiteTrojanHorse, new Vector2Int(6, 0), true); // White Knight 2
        SpawnPiece(whiteChoasBishop, new Vector2Int(2, 0), true); // White Bishop 1
        SpawnPiece(whiteChoasBishop, new Vector2Int(5, 0), true); // White Bishop 2
        SpawnPiece(whiteDAQueen, new Vector2Int(3, 0), true); // White Queen
        SpawnPiece(whiteKing, new Vector2Int(4, 0), true); // White King

        // Spawn Black Pieces
        SpawnPiece(blackPunarJanamRook, new Vector2Int(0, 7), false); // Black Rook 1
        SpawnPiece(blackPunarJanamRook, new Vector2Int(7, 7), false); // Black Rook 2
        SpawnPiece(blackTrojanHorse, new Vector2Int(1, 7), false); // Black Knight 1
        SpawnPiece(blackTrojanHorse, new Vector2Int(6, 7), false); // Black Knight 2
        SpawnPiece(blackChoasBishop, new Vector2Int(2, 7), false); // Black Bishop 1
        SpawnPiece(blackChoasBishop, new Vector2Int(5, 7), false); // Black Bishop 2
        SpawnPiece(blackDAQueen, new Vector2Int(3, 7), false); // Black Queen
        SpawnPiece(blackKing, new Vector2Int(4, 7), false); // Black King

        for (int i = 0; i < 8; i++)
        {
            // Spawn White Pawn
            SpawnPiece(whiteHabibiPawn, new Vector2Int(i, 1), true);

            // Spawn Black Pawn
            SpawnPiece(blackHabibiPawn, new Vector2Int(i, 6), false);
        }
    }

    // Spawns a piece at a given position
    public void SpawnPiece(GameObject piecePrefab, Vector2Int position, bool isWhite)
    {
        if (piecePrefab == null)
        {
            Debug.LogError($"Piece prefab at position {position} is NULL! Cannot spawn.");
            return;
        }

        GameObject piece = Instantiate(piecePrefab, GetWorldPosition(position), Quaternion.identity, boardParent);
        if (piece == null)
        {
            Debug.LogError("Instantiation Failed!");
            return;
        }

        ChessPiece chessPiece = piece.GetComponent<ChessPiece>();
        if (chessPiece == null)
        {
            Debug.LogError($"Missing ChessPiece component on prefab at position {position}.");
            Destroy(piece); // Clean up if the piece is not valid
            return;
        }

        chessPiece.Initialize(isWhite, position, this);
        board[position.x, position.y] = piece;

        Debug.Log($"Successfully spawned {(isWhite ? "White" : "Black")} Pawn at {position}");
    }

    // Converts board coordinates to world position
    public Vector3 GetWorldPosition(Vector2Int boardPosition)
    {
        float tileSize = 10.8f / 8f; // Adjust based on your board tile size
        float boardOffsetX = -4.725f; // Center the board (assuming 8x8)
        float boardOffsetY = -4.725f;

        return new Vector3(boardPosition.x * tileSize + boardOffsetX, boardPosition.y * tileSize + boardOffsetY, 0);
    }
    // Converts world position to board coordinates
    Vector2Int GetBoardPositionFromWorld(Vector3 worldPosition)
    {
        float tileSize = 10.8f / 8f; // Match your board's scaling
        int x = Mathf.FloorToInt((worldPosition.x + 4.725f) / tileSize);
        int y = Mathf.FloorToInt((worldPosition.y + 4.725f) / tileSize);
        return new Vector2Int(x, y);
    }
    Vector2Int GetBoardPositionFromMouse()
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Perform a 2D raycast at the mouse's world position
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;

            // Check if a piece was clicked
            if (hitObject.CompareTag("Piece")) // Tag all pieces with "Piece"
            {
                ChessPiece clickedPiece = hitObject.GetComponent<ChessPiece>();
                if (clickedPiece != null)
                {
                    Debug.Log($"Piece clicked: {clickedPiece.name} at {clickedPiece.currentPosition}");
                    SelectPiece(clickedPiece);
                    return clickedPiece.currentPosition;
                }
            }

            // Check if a tile was clicked
            if (hitObject.CompareTag("Tile")) // Tag all tiles with "Tile"
            {
                Tile tile = hitObject.GetComponent<Tile>();
                if (tile != null)
                {
                    Debug.Log($"Tile clicked: {tile.name} at {new Vector2Int(tile.boardX, tile.boardY)}");
                    return new Vector2Int(tile.boardX, tile.boardY);
                }
            }

            Debug.LogWarning("Clicked object is neither a Tile nor a Piece.");
        }
        else
        {
            Debug.LogWarning("Nothing clicked.");
        }

        // Return an invalid position if no valid object was clicked
        return new Vector2Int(-1, -1);
    }


    public bool IsInBounds(Vector2Int position)
    {
        return position.x >= 0 && position.x < 8 && position.y >= 0 && position.y < 8;
    }

    public void SelectPiece(ChessPiece piece)
    {
        if (piece == null) { Debug.LogError("piece null"); return; }
        if (selectedPiece != null)
        {
            if (selectedPiece is ChoasBishop chaosBishop)
            {
                chaosBishop.ClearSpecialHighlights(); // Add a method to explicitly clear special highlights
            }

            tileHighlighter.ClearHighlights();
            Debug.Log("Deselected previous piece");
        }
        Debug.Log($"Selecting piece at {piece.currentPosition}");
        if (piece.isWhite != isWhiteTurn)
        {
            Debug.Log("Cannot select opponent's piece!");
            return;
        }

        // Clear any existing highlights before selecting a new piece
        tileHighlighter.ClearHighlights();

        if (selectedPiece != null)
        {
            Debug.Log("Deselected previous piece");
            selectedPiece = null;
        }

        selectedPiece = piece;
        tileHighlighter.ShowHighlights(piece.GetAvailableMoves(), boardParent);
        Debug.Log("Highlights shown");
    }

    public void MoveSelectedPiece(Vector2Int toPosition)
    {


        // Check if the move is valid
        if (selectedPiece == null) { Debug.Log("selectedPiece is null"); }
        //List<Vector2Int> validMoves = selectedPiece.GetAvailableMoves();
        // Check if the move is valid
        //List<Vector2Int> validMoves = selectedPiece.GetAvailableMoves();
        //// Combine available moves and special moves
        List<Vector2Int> validMoves = new List<Vector2Int>();
        validMoves.AddRange(selectedPiece.GetAvailableMoves());
        validMoves.AddRange(selectedPiece.GetSpecialMoves()); // Include special moves

        if (!validMoves.Contains(toPosition))
        {
            Debug.Log($"Invalid move to {toPosition}");
            return;
        }

        if (selectedPiece is Pawn &&( toPosition.y == 0 || toPosition.y == 7))
        {
            PromotePawn(selectedPiece,toPosition);
        }
        if (selectedPiece == null)
        {
            Debug.Log("No piece selected to move!");
            return;
        }

        // Handle piece capture
        GameObject targetPiece = board[toPosition.x, toPosition.y];

        if (targetPiece != null)
        {
            GameObject atomicpawn = board[selectedPiece.currentPosition.x, selectedPiece.currentPosition.y];
            AtomicPawn atomicpawn1 = atomicpawn.GetComponent<AtomicPawn>();
            if (selectedPiece == atomicpawn1)
            {
                audioSource = GetComponent<AudioSource>();
                audioSource.clip = soundClip;
                if (targetPiece != null)
                {
                    ChessPiece targetChessPiece0 = targetPiece.GetComponent<ChessPiece>();
                    if (targetChessPiece0 != null)
                    {
                        if (targetChessPiece0 != null && targetChessPiece0.isWhite != atomicpawn1.isWhite)
                        {
                            Debug.Log($"Capturing piece at {toPosition}");
                            atomicpawn1.Explode(toPosition);
                            audioSource.Play();
                        }

                    }

                }
            }
            ChessPiece targetChessPiece = targetPiece.GetComponent<ChessPiece>();
            if (targetChessPiece is King)
            {

                Destroy(targetChessPiece.gameObject);
                EndGame();
            }

            if (targetChessPiece is PunarJanamRook)
            {

                GameObject PJR= board[toPosition.x,toPosition.y];
                PunarJanamRook punarJanamRook = PJR.GetComponent<PunarJanamRook>();
                PunarJanamRook capturedRook = targetChessPiece as PunarJanamRook;

                // Respawn the rook
                RespawnRook(capturedRook.gameObject, capturedRook.isWhite);
                //if (punarJanamRook.isCaptured) {
                //    Debug.Log("PUNarjanam is captured now respawning");
                //    punarJanamRook.RespawnRook(); }
                Debug.Log($"{targetChessPiece} tcp on {targetChessPiece.currentPosition}");
                Debug.Log($"{targetChessPiece} is punarjanam ");
                if(punarJanamRook == null) { Debug.Log("PJRRook is null"); }
                punarJanamRook.CaptureRook(targetChessPiece.currentPosition);

                Destroy(targetChessPiece.gameObject);

                
            }else
            if (targetChessPiece != null)
            {
                if (targetChessPiece.isWhite != selectedPiece.isWhite)
                {
                    Destroy(targetPiece); // Capture opponent's piece
                    Debug.Log($"Captured {(targetChessPiece.isWhite ? "White" : "Black")} piece at {toPosition}");
                }
                else
                {
                    Debug.Log("Cannot capture your own piece!");
                    return;
                }
            }
            tileHighlighter.ClearHighlights(); // Clear highlights
        }

        // Move the piece
        Vector2Int fromPosition = selectedPiece.currentPosition;
        board[fromPosition.x, fromPosition.y] = null;
        board[toPosition.x, toPosition.y] = selectedPiece.gameObject;

        selectedPiece.MoveTo(toPosition); // Update the piece's internal state
        tileHighlighter.ClearHighlights();
        Debug.Log($"Moved piece to {toPosition}");

        // End the turn
        EndTurn();
    }

    private void EndTurn()
    {
        isWhiteTurn = !isWhiteTurn;
        Debug.Log($"Turn ended. It is now {(isWhiteTurn ? "White" : "Black")}'s turn");

        // Clear any leftover highlights
        tileHighlighter.ClearHighlights();

        // Clear special highlights if the last piece was a Chaos Bishop
        if (selectedPiece is ChoasBishop chaosBishop)
        {
            chaosBishop.ClearSpecialHighlights();
        }

        selectedPiece = null;
        Debug.Log("Highlights cleared at the end of turn.");
    }

    public bool IsEnemyPiece(Vector2Int position, bool isWhite)
    {
        if (!IsInBounds(position)) return false;

        GameObject piece = board[position.x, position.y];
        if (piece == null) return false;

        ChessPiece chessPiece = piece.GetComponent<ChessPiece>();
        return chessPiece != null && chessPiece.isWhite != isWhite;
    }

    public bool IsSquareEmpty(Vector2Int position)
    {
        return IsInBounds(position) && board[position.x, position.y] == null;
    }

    // Pawn Promotion Logic here


    public ChessPiece [,] chessPieces=new ChessPiece[8,8];
    public GameObject whiteQueenPrefab;
    public GameObject whiteRookPrefab;
    public GameObject whiteBishopPrefab;
    public GameObject whiteKnightPrefab;
    public GameObject blackQueenPrefab;
    public GameObject blackRookPrefab;
    public GameObject blackBishopPrefab;
    public GameObject blackKnightPrefab;

    public GameObject promotionPanel; // A UI panel with buttons for promotion choices

    private ChessPiece pawnToPromote; // Stores the pawn waiting for promotion
    private Vector2Int pawnPosition; // Position of the pawn waiting for promotion

    public void PromotePawn(ChessPiece pawn,Vector2Int toPosition)
    {
        // Save the pawn and its position
        pawnToPromote = pawn;
        pawnPosition = toPosition;
        Debug.Log($"currrent position of pawn{ pawn.currentPosition}");
        Debug.Log($"Currrent position of pawn{pawn.CurrentPosition}");
        Debug.Log($"Currrent position of pawn{pawnPosition}");
        // Display the promotion panel
        promotionPanel.SetActive(true);
    }

    // Called by UI buttons for each promotion choice
    public void OnPromotionChoice(string promotionChoice)
    {
        // Remove the current pawn
        Destroy(pawnToPromote.gameObject);

        // Instantiate the new piece based on the promotion choice
        GameObject newPiece = null;
        if (pawnToPromote.isWhite)
        {
            switch (promotionChoice.ToLower())
            {
                case "queen":
                    newPiece = Instantiate(whiteQueenPrefab, GetWorldPosition(pawnPosition), Quaternion.identity, boardParent);
                    break;
                case "rook":
                    newPiece = Instantiate(whiteRookPrefab, GetWorldPosition(pawnPosition), Quaternion.identity, boardParent);
                    break;
                case "bishop":
                    newPiece = Instantiate(whiteBishopPrefab, GetWorldPosition(pawnPosition), Quaternion.identity, boardParent);
                    break;
                case "knight":
                    newPiece = Instantiate(whiteKnightPrefab, GetWorldPosition(pawnPosition), Quaternion.identity, boardParent);
                    break;
                default:
                    Debug.LogError("Invalid promotion choice");
                    return;
            }
        }
        else
        {
            switch (promotionChoice.ToLower())
            {
                case "queen":
                    newPiece = Instantiate(blackQueenPrefab, GetWorldPosition(pawnPosition), Quaternion.identity, boardParent);
                    break;
                case "rook":
                    newPiece = Instantiate(blackRookPrefab, GetWorldPosition(pawnPosition), Quaternion.identity, boardParent);
                    break;
                case "bishop":
                    newPiece = Instantiate(blackBishopPrefab, GetWorldPosition(pawnPosition), Quaternion.identity, boardParent);
                    break;
                case "knight":
                    newPiece = Instantiate(blackKnightPrefab, GetWorldPosition(pawnPosition), Quaternion.identity, boardParent);
                    break;
                default:
                    Debug.LogError("Invalid promotion choice");
                    return;
            }
        }

        // Update the new piece's properties
        ChessPiece promotedPiece = newPiece.GetComponent<ChessPiece>();
        if (promotedPiece == null)
        {
            Debug.LogError("Promoted piece is missing ChessPiece component!");
            return;
        }
        promotedPiece.Initialize(pawnToPromote.isWhite, pawnPosition, this); // Set color and position

        // Update the board state
        board[pawnPosition.x, pawnPosition.y] = newPiece;
        chessPieces[pawnPosition.x, pawnPosition.y] = promotedPiece;

        // Hide the promotion panel
        promotionPanel.SetActive(false);

        Debug.Log($"Pawn promoted to {promotionChoice} at {pawnPosition}");
    }
    //bhoot rook implementation


    public void RespawnRook(GameObject rookPrefab, bool isWhite)
    {
        Vector2Int randomPosition = GetRandomUnoccupiedPosition();

        if (randomPosition == new Vector2Int(-1, -1))
        {
            Debug.LogError("No available position to respawn the rook!");
            return;
        }

        // Instantiate the rook at the new position
        GameObject rook = Instantiate(rookPrefab, GetWorldPosition(randomPosition), Quaternion.identity, boardParent);

        // Update the rook's properties
        ChessPiece rookPiece = rook.GetComponent<ChessPiece>();
        if (rookPiece == null)
        {
            Debug.LogError("Respawned rook is missing ChessPiece component!");
            Destroy(rook);
            return;
        }
        rookPiece.Initialize(isWhite, randomPosition, this);

        // Update the board state
        board[randomPosition.x, randomPosition.y] = rook;
        chessPieces[randomPosition.x, randomPosition.y] = rookPiece;

        Debug.Log($"{(isWhite ? "White" : "Black")} rook respawned at {randomPosition}");
    }
    // Get a random unoccupied position on the board
    private Vector2Int GetRandomUnoccupiedPosition()
    {
        List<Vector2Int> unoccupiedPositions = new List<Vector2Int>();

        // Find all unoccupied tiles
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (board[x, y] == null) // Tile is unoccupied
                {
                    unoccupiedPositions.Add(new Vector2Int(x, y));
                }
            }
        }

        if (unoccupiedPositions.Count == 0)
        {
            return new Vector2Int(-1, -1); // Indicate no available position
        }

        // Select a random position
        int randomIndex = Random.Range(0, unoccupiedPositions.Count);
        return unoccupiedPositions[randomIndex];
    }


    private void EndGame()
    {
        // Implement game-ending logic here
        // For example, display a victory screen or reset the board
        Debug.Log("Game Over");
    }
}
