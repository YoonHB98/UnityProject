using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public ItemData.ItemType type;
    public float rate;

    public void Init(ItemData data)
    {
        // Basic Set
        name = "Gear" + data.itemId;
        transform.parent = GameManager.instance.dummy.transform;
        transform.localPosition = Vector3.zero;

        // Property Set
        type = data.itemType;
        rate = data.damages[0];
        ApplyGear();
    }

    public void LevelUp(float rate)
    {
        this.rate = rate;
        ApplyGear();
    }

    void ApplyGear()
    {
        switch (type)
        {
            case ItemData.ItemType.Glove:
                RateUp();
                break;
            case ItemData.ItemType.Shoe:
                SpeedUp();
                break;
        }
    }

    void RateUp()
    {
        WeaponSurvival[] weapons = transform.parent.GetComponentsInChildren<WeaponSurvival>();

        foreach (WeaponSurvival weapon in weapons) 
        {
            switch (weapon.id)
            {
                case 0:
                    weapon.speed = 150 + (150 * rate);
                    break;
                default:
                    weapon.damage = 0.5f + (1.0f - rate);
                    break;
            }
        }
    }

    void SpeedUp()
    {
        float speed = 40.0f;
        GameManager.instance.player._speed = speed + (speed * rate);
    }
}
