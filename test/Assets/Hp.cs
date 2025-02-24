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
    // 过渡速度, 建议为5
    public float speed;
    private Image image;
    public Text text;  // 引用UI Text组件

    void Start()
    {
        image = this.GetComponent<Image>();
        
        // 在开始时更新血量文本
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

        // 更新血条的填充
        image.fillAmount = hpBefore / hpMax;

        // 根据血量改变血条颜色
        if (image.fillAmount >= 0.5f)
        {
            image.color = new Color((2 - 2 * image.fillAmount), 1, 0);
        }
        else
        {
            image.color = new Color(1, (2 * image.fillAmount), 0);
        }

        // 模拟血量变化
        if (Input.GetKey(KeyCode.V))
        {
            hp -= 100 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.C))
        {
            hp += 100 * Time.deltaTime;
        }

        // 确保血量始终在0到hpMax之间
        if (hp > hpMax)
        {
            hp = hpMax;
        }
        if (hp < 0)
        {
            hp = 0;
        }

        // 重新计算平滑过渡
        hpBefore = hp;

        // 更新血量文本
        UpdateHealthText();
    }

    // 控制血量的公共函数
    public void SetHealth(float current, float max)
    {
        hp = current;
        hpMax = max;

        // 确保当前血量不超过最大血量
        if (hp > hpMax)
        {
            hp = hpMax;
        }
        if (hp < 0)
        {
            hp = 0;
        }

        // 重新计算平滑过渡
        hpBefore = hp;

        // 更新血量文本
        UpdateHealthText();
    }

    // 更新UI文本显示血量
    private void UpdateHealthText()
    {
        if (text != null)
        {
            text.text = "HP: " + Mathf.RoundToInt(hp).ToString() + " / " + Mathf.RoundToInt(hpMax).ToString();
        }
    }
}
