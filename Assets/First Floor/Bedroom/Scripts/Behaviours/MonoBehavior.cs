using UnityEngine;
using UnityEngine.UI;

public class ModelInfoWindow : MonoBehaviour
{
    public GameObject infoWindow; // 信息窗口的UI面板
    public Text modelNameText; // 显示模型名称的文本

    private void Update()
    {
        // 检测鼠标点击事件
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 判断是否点击到了模型
                if (hit.collider.gameObject == gameObject)
                {
                    // 点击到了模型，显示信息窗口并设置模型名称
                    infoWindow.SetActive(true);
                    modelNameText.text = gameObject.name;
                }
                else
                {
                    // 点击到了其他地方，隐藏信息窗口
                    infoWindow.SetActive(false);
                }
            }
        }
    }
}