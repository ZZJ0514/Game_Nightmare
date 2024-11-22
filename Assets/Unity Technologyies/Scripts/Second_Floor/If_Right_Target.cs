using UnityEngine;
using UnityEngine.EventSystems;

public class SnapToTarget : MonoBehaviour, IDropHandler
{
    public RectTransform targetPosition; // ��Ӧ��Ŀ��λ��
    public float snapThreshold = 50f;   // �����ľ�����ֵ

    public void OnDrop(PointerEventData eventData)
    {
        // ��ȡ�϶�����Ƭ
        RectTransform piece = eventData.pointerDrag.GetComponent<RectTransform>();
        if (piece == null) return;

        // ������Ƭ��Ŀ��ľ���
        float distance = Vector2.Distance(piece.anchoredPosition, targetPosition.anchoredPosition);

        if (distance < snapThreshold)
        {
            // �����Ƭ��Ŀ�귶Χ�ڣ�����������Ŀ��λ��
            piece.anchoredPosition = targetPosition.anchoredPosition;
            piece.GetComponent<CanvasGroup>().blocksRaycasts = false; // ��ֹ�ٴ��϶�

            // ֪ͨ PuzzleManager ��һ����Ƭƴ�����
            PuzzleManager puzzleManager = FindObjectOfType<PuzzleManager>();
            if (puzzleManager != null)
            {
                puzzleManager.PieceCompleted();
            }
            else
            {
                Debug.LogError("PuzzleManager δ�ҵ�����ȷ���������ڳ����У�");
            }
        }
    }
}
