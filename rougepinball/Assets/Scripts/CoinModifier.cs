using UnityEngine;

public enum ModifierType
{
    Currency,
    RestoreBall,
    FlipperLength,
    BumperForce,
    LeftFlipperUpSpeed,
    RightFlipperUpSpeed,
    FlipperDownSpeed,
    PlungerMaxPower,
    PlungerPullbackMultiplier
}

[CreateAssetMenu(menuName="Roguelike/Coin Modifier")]
public class CoinModifier : ScriptableObject
{
    public string rewardName;
    public Sprite icon;
    [TextArea] public string description;

    public ModifierType type;
    public float amount = 1f;

    public int rarityWeight = 100;
}