using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RewardChoiceUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text descText;
    public Image iconImage;

    private RewardManager RM;
    private CoinModifier reward;
    

    void Awake()
    {
        RM = FindObjectOfType<RewardManager>();
    }

    public void Setup(CoinModifier r)
    {
        reward = r;

        nameText.text = r.rewardName;
        descText.text = r.description;

        if (iconImage != null)
            iconImage.sprite = r.icon;
    }

    public void SelectReward()
    {
        RM.ApplyReward(reward);
        RM.ClearChoices();
    }
}