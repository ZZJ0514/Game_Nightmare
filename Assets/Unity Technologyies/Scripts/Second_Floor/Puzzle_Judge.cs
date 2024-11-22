using System.Diagnostics;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject completeImage; // 用于显示完整试卷的图片
    public GameObject[] pieces;     // 所有碎片对象
    private int completedPieces = 0; // 已拼合完成的碎片数量

    void Start()
    {
        // 确保完整试卷图片初始时隐藏
        if (completeImage != null)
        {
            completeImage.SetActive(false);
        }
    }

    public void PieceCompleted()
    {
        completedPieces++;

        // 检查是否所有碎片都完成
        if (completedPieces >= pieces.Length)
        {
            Debug.Log("拼图完成！");

            // 显示完整试卷
            if (completeImage != null)
            {
                completeImage.SetActive(true);
            }

            // 可在这里添加其他完成效果（音效、过渡动画等）
        }
    }
}
