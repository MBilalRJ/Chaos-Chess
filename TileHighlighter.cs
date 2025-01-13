using System.Collections.Generic;
using UnityEngine;

public class TileHighlighter : MonoBehaviour
{
    public GameObject highlightPrefab;
    private List<GameObject> activeHighlights = new List<GameObject>();

    public void ShowHighlights(List<Vector2Int> positions, Transform boardParent)
    {
        ClearHighlights();
        foreach (Vector2Int position in positions)
        {
            Debug.Log($"Highlighting position: {position}");
            Vector3 worldPosition = GameManager.Instance.GetWorldPosition(position);
            GameObject highlight = Instantiate(highlightPrefab, worldPosition, Quaternion.identity, boardParent);
            activeHighlights.Add(highlight);
        }
    }

    public void ClearHighlights()
    {
        foreach (GameObject highlight in activeHighlights)
        {
            Destroy(highlight);
        }
        activeHighlights.Clear();
        Debug.Log("Cleared all highlights");
    }
}
