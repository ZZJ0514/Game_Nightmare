using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // �϶�ʱ����͸����
        canvasGroup.blocksRaycasts = false; // �������߼��
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta; // ����λ��
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f; // �ָ�͸����
        canvasGroup.blocksRaycasts = true; // �ָ����߼��
    }
}