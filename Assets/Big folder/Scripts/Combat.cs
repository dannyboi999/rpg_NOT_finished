using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class Combat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackcooldown = 0f;

    CharacterStats myStats;

    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        attackcooldown -= Time.deltaTime; 
    }

    public void Attack(CharacterStats targetStats)
    {
        if(attackcooldown <= 0f)
        {
            targetStats.TakeDamage(myStats.damage.GetValue());
            attackcooldown = 1f / attackSpeed;
        }
    }
}
