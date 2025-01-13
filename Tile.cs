using UnityEngine;

public class Tile : MonoBehaviour
{
    public int boardX;
    public int boardY;

    public void Initialize(int x, int y)
    {
        boardX = x;
        boardY = y;
    }
}
