using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EquipmentManager;

public class playerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            armour.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armour.RemoveModifier(oldItem.armorModifier);
            armour.RemoveModifier(oldItem.damageModifier);
        }
    }
}
