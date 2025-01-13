using UnityEngine;
using UnityEngine.UI;

public class PromotionPanelController : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager script

    // Button click handlers
    public void OnQueenSelected()
    {
        gameManager.OnPromotionChoice("queen");
    }

    public void OnRookSelected()
    {
        gameManager.OnPromotionChoice("rook");
    }

    public void OnBishopSelected()
    {
        gameManager.OnPromotionChoice("bishop");
    }

    public void OnKnightSelected()
    {
        gameManager.OnPromotionChoice("knight");
    }
}
