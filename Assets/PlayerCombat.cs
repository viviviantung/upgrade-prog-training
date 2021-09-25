using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: experiment with more types of attacks - change up area of effect, speed, damage, cancellation, range, etc.

public class PlayerCombat : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 1.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetAxisRaw("Attack") == 1)
            {
                Debug.Log("Attack key hit");
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }  
        }
    }

    void Attack()
    {
        //TODO: add starting the animation here once we have the assets (see 3:30 in Brackeys video)

        // find enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
    
        // damage the enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint != null){
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
