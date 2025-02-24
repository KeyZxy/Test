using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp;
    private float hpMax = 100;
    private float hpBefore;
    // �����ٶ�, ����Ϊ5
    public float speed;
    private Image image;
    public Text text;  // ����UI Text���

    void Start()
    {
        image = this.GetComponent<Image>();
        
        // �ڿ�ʼʱ����Ѫ���ı�
        UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp != hpBefore)
        {
            hpBefore -= (hpBefore - hp) * Time.deltaTime * speed;
        }
        else
        {
            hpBefore = hp;
        }

        // ����Ѫ�������
        image.fillAmount = hpBefore / hpMax;

        // ����Ѫ���ı�Ѫ����ɫ
        if (image.fillAmount >= 0.5f)
        {
            image.color = new Color((2 - 2 * image.fillAmount), 1, 0);
        }
        else
        {
            image.color = new Color(1, (2 * image.fillAmount), 0);
        }

        // ģ��Ѫ���仯
        if (Input.GetKey(KeyCode.V))
        {
            hp -= 100 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.C))
        {
            hp += 100 * Time.deltaTime;
        }

        // ȷ��Ѫ��ʼ����0��hpMax֮��
        if (hp > hpMax)
        {
            hp = hpMax;
        }
        if (hp < 0)
        {
            hp = 0;
        }

        // ���¼���ƽ������
        hpBefore = hp;

        // ����Ѫ���ı�
        UpdateHealthText();
    }

    // ����Ѫ���Ĺ�������
    public void SetHealth(float current, float max)
    {
        hp = current;
        hpMax = max;

        // ȷ����ǰѪ�����������Ѫ��
        if (hp > hpMax)
        {
            hp = hpMax;
        }
        if (hp < 0)
        {
            hp = 0;
        }

        // ���¼���ƽ������
        hpBefore = hp;

        // ����Ѫ���ı�
        UpdateHealthText();
    }

    // ����UI�ı���ʾѪ��
    private void UpdateHealthText()
    {
        if (text != null)
        {
            text.text = "HP: " + Mathf.RoundToInt(hp).ToString() + " / " + Mathf.RoundToInt(hpMax).ToString();
        }
    }
}
