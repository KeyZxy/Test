using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    RectTransform rectTransform; void Start()
    {
        rectTransform = GetComponent<RectTransform>();// ��ȡ��Ļ�Ŀ�Ⱥ͸߶�
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;// ����Ѫ����λ�ã�������Ļ���½ǵ�5%���������Ļ�ߴ磩
        float offsetX = screenWidth * 0.05f;  // ���Ե5%
        float offsetY = screenHeight * 0.05f; // �±�Ե5%// ����Ѫ����λ��
        rectTransform.anchorMin = new Vector2(0, 0);  // ê������Ϊ���½�
        rectTransform.anchorMax = new Vector2(0, 0);  // ê������Ϊ���½�
        rectTransform.pivot = new Vector2(0, 0);     // pivot����Ϊ���½�
        rectTransform.anchoredPosition = new Vector2(offsetX, offsetY); // ����ʵ��λ��
    }
}
