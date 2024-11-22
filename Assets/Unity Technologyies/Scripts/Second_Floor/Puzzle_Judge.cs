using System.Diagnostics;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject completeImage; // ������ʾ�����Ծ��ͼƬ
    public GameObject[] pieces;     // ������Ƭ����
    private int completedPieces = 0; // ��ƴ����ɵ���Ƭ����

    void Start()
    {
        // ȷ�������Ծ�ͼƬ��ʼʱ����
        if (completeImage != null)
        {
            completeImage.SetActive(false);
        }
    }

    public void PieceCompleted()
    {
        completedPieces++;

        // ����Ƿ�������Ƭ�����
        if (completedPieces >= pieces.Length)
        {
            Debug.Log("ƴͼ��ɣ�");

            // ��ʾ�����Ծ�
            if (completeImage != null)
            {
                completeImage.SetActive(true);
            }

            // ������������������Ч������Ч�����ɶ����ȣ�
        }
    }
}
