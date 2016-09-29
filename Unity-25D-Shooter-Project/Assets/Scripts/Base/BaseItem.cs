using UnityEngine;
using System.Collections;

public enum ITEM_TYPE
{
    WEAPON,
    PROJECTILE,
    CONSUMABLE,
    THROWABLE
}

public abstract class BaseItem : MonoBehaviour
{
    [Header("- ITEM ATTRIBUTES - ")]
    public ITEM_TYPE itemType;
    public string name;
    public int id;
    public int amount;
    public float value;
    public Sprite icon;
}
