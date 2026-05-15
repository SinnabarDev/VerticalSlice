using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [Header("References")]
    public GameObject plunger;
    public List<CoinModifier> allRewards;
    public GameObject rewardButtonPrefab;
    public Transform choiceContainer;

    [Header("Runtime Stats (cached)")]
    int currency;
    int ballsLost;

    float flipperLength;
    float bumperForce;
    float plungerPower;
    float plungermulti;
    public int generateCost = 100;

    void Start()
    {
        SyncFromVisualScripting();
    }

    void SyncFromVisualScripting()
    {
        // Scene variables (global stats)
        currency = (int)Variables.Scene(gameObject).Get("currency");

        ballsLost = (int)Variables.Scene(gameObject).Get("ballsLost");

        flipperLength = (float)Variables.Scene(gameObject).Get("length");

        float bumperForce = (float)Variables.Scene(gameObject).Get("bumperforcex");

        // Object variable (plunger-specific)
        if (plunger != null)
        {
            plungerPower = (float)Variables.Object(plunger).Get("MaxOutput");
            plungermulti = (float)Variables.Object(plunger).Get("PullBackDistance");
        }
    }

    public void Generate3Choices()
    {
        // 🔴 COST CHECK (important for your economy system)
        int currency = (int)Variables.Scene(gameObject).Get("currency");

        if (currency < generateCost)
        {
            Debug.Log("Not enough currency to generate choices!");
            return;
        }

        currency -= generateCost;

        Variables.Scene(gameObject).Set("currency", currency);

        // --- VALIDATION ---
        if (allRewards == null || allRewards.Count == 0)
        {
            Debug.LogError("No rewards in allRewards list!");
            return;
        }

        if (rewardButtonPrefab == null)
        {
            Debug.LogError("RewardButtonPrefab is not assigned!");
            return;
        }

        if (choiceContainer == null)
        {
            Debug.LogError("ChoiceContainer is not assigned!");
            return;
        }

        ClearChoices();

        // --- SPAWN ---
        for (int i = 0; i < 3; i++)
        {
            CoinModifier reward = allRewards[Random.Range(0, allRewards.Count)];

            GameObject obj = Instantiate(rewardButtonPrefab, choiceContainer);

            RewardChoiceUI ui = obj.GetComponent<RewardChoiceUI>();

            if (ui == null)
            {
                Debug.LogError("RewardChoiceUI missing on prefab!");
                continue;
            }

            ui.Setup(reward);
        }
    }

    public void ClearChoices()
    {
        foreach (Transform child in choiceContainer)
        {
            Destroy(child.gameObject);
        }
    }

    public void ApplyReward(CoinModifier reward)
    {
        if (reward == null)
        {
            Debug.LogError("ApplyReward called with NULL reward!");
            return;
        }

        switch (reward.type)
        {
            case ModifierType.Currency:
                currency += (int)reward.amount;
                Variables.Scene(gameObject).Set("currency", currency);
                break;

            case ModifierType.RestoreBall:
                ballsLost = Mathf.Max(0, ballsLost - 1);
                Variables.Scene(gameObject).Set("ballsLost", ballsLost);
                break;

            case ModifierType.FlipperLength:
                flipperLength += reward.amount;
                Variables.Scene(gameObject).Set("length", flipperLength);
                break;

            case ModifierType.BumperForce:
                bumperForce += reward.amount;
                Variables.Scene(gameObject).Set("bumperforcex", bumperForce);
                break;

            case ModifierType.PlungerMaxPower:
                plungerPower += reward.amount;

                if (plunger != null)
                {
                    Variables.Object(plunger).Set("MaxOutput", plungerPower);
                }
                break;
            case ModifierType.PlungerPullbackMultiplier:
                plungermulti += reward.amount;

                if (plunger != null)
                {
                    Variables.Object(plunger).Set("PullBackDistance", plungermulti);
                }
                break;

            case ModifierType.LeftFlipperUpSpeed: { } // Implement extra ball logic here (e.g., increase max balls or give an immediate extra ball)
                break;
            case ModifierType.RightFlipperUpSpeed: { } // Implement extra ball logic here (e.g., increase max balls or give an immediate extra ball)
                break;
            case ModifierType.FlipperDownSpeed: { } // Implement extra ball logic here (e.g., increase max balls or give an immediate extra ball)
                break;
        }

        Debug.Log("Reward Applied: " + reward.rewardName);
    }
}
