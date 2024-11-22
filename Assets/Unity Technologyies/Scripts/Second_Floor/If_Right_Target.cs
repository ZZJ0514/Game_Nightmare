using UnityEngine;
using UnityEngine.EventSystems;

public class SnapToTarget : MonoBehaviour, IDropHandler
{
    public RectTransform targetPosition; // 对应的目标位置
    public float snapThreshold = 50f;   // 吸附的距离阈值

    public void OnDrop(PointerEventData eventData)
    {
        // 获取拖动的碎片
        RectTransform piece = eventData.pointerDrag.GetComponent<RectTransform>();
        if (piece == null) return;

        // 计算碎片与目标的距离
        float distance = Vector2.Distance(piece.anchoredPosition, targetPosition.anchoredPosition);

        if (distance < snapThreshold)
        {
            // 如果碎片在目标范围内，将其吸附到目标位置
            piece.anchoredPosition = targetPosition.anchoredPosition;
            piece.GetComponent<CanvasGroup>().blocksRaycasts = false; // 禁止再次拖动

            // 通知 PuzzleManager 有一个碎片拼接完成
            PuzzleManager puzzleManager = FindObjectOfType<PuzzleManager>();
            if (puzzleManager != null)
            {
                puzzleManager.PieceCompleted();
            }
            else
            {
                Debug.LogError("PuzzleManager 未找到，请确保它存在于场景中！");
            }
        }
    }
}
