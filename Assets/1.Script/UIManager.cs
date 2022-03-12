using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    [SerializeField] private RectAnim[] rectAnims;
    [SerializeField] private Text goldText, keyText;
    [SerializeField] private RectTransform goldRect, keyRect;
    [SerializeField] private Image[] stagesImage;
    [SerializeField] private Text[] stagesText;
    [SerializeField] private Sprite unlocked, current, locked;
    public void Set()
    {
        int stageStandard = ((GameManager.Instance.UserInfo.stage / 4) * 4) + 1;
        for (int i = 0; i < stagesImage.Length; i++)
        {
            if ((GameManager.Instance.UserInfo.stage % 4) - 1 < i)
            {
                stagesImage[i].sprite = unlocked;
            }
            else
            {
                stagesImage[i].sprite = locked;
            }
            stagesImage[i].rectTransform.localScale = new Vector3(1, 1, 1);
        }
        for (int i = 0; i < stagesText.Length; i++)
        {
            stagesText[i].text = (stageStandard + i).ToString();
        }
        stagesImage[(GameManager.Instance.UserInfo.stage % 4) - 1].sprite = current;
        stagesImage[(GameManager.Instance.UserInfo.stage % 4) - 1].rectTransform.localScale = new Vector3(1.5f, 1.5f, 1);
    }
    public void GameStart()
    {
        foreach (RectAnim item in rectAnims)
        {
            item.SetAnim(true);
        }
    }
}