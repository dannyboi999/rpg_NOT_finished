using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();

        Combat playerCombat = playerManager.player.GetComponent<Combat>();
        if(playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }
}
