using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSurvival : MonoBehaviour
{
    public ItemData data;
    public int level;
    public WeaponSurvival weapon;

    Image icon;
    TMP_Text textLevel;

    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.itemIcon;

        TMP_Text[] texts = GetComponentsInChildren<TMP_Text>();
        textLevel = texts[0];
    }

    private void LateUpdate()
    {
        textLevel.text = "Lv." + (level + 1);
    }

    public void OnClick()
    {
        switch (data.itemType)
        {
            case ItemData.ItemType.Melee:
            case ItemData.ItemType.Range:
                if (level == 0)
                {
                    GameObject newWeapon = new GameObject();
                    weapon = newWeapon.AddComponent<WeaponSurvival>();
                    weapon.Init(data);
                }else{
                    float nextDamage = data.baseDamage;
                    int nextCount = data.baseCount;

                    nextDamage += data.baseDamage * data.damages[level];
                    nextCount += data.counts[level];

                    weapon.LevelUp(nextDamage, nextCount);
                }
                break;
            case ItemData.ItemType.Glove:
                break;

            case ItemData.ItemType.Shoe:
                break;

            case ItemData.ItemType.Heal:
                break;
        }

        level++;
        if (level >= data.damages.Length)
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
