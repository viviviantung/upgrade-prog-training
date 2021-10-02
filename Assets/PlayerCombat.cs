using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: experiment with more types of attacks - change up area of effect, speed, damage, cancellation, range, etc.

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform basicAttackPoint;
    public float basicAttackRange = 1.5f;

    public Transform rangeAttackPoint;
    public float rangeAttackRange = 2.0f;

    public LayerMask enemyLayers;

    public int basicAttackDamage = 20;
    public int rangeAttackDamage = 10;


    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("RangeAttack", Input.GetAxisRaw("RangeAttack") == 1);

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetAxisRaw("BasicAttack") == 1)
            {
                BasicAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }  else if (Input.GetAxisRaw("RangeAttack") == 1) {
                RangeAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void BasicAttack()
    {
        //TODO: add starting the animation here once we have the assets (see 3:30 in Brackeys video)

        // find enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(basicAttackPoint.position, basicAttackRange, enemyLayers);
    
        // damage the enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name + " with basic attack");
            enemy.GetComponent<Enemy>().TakeDamage(basicAttackDamage);
        }
    }

        void RangeAttack()
    {
        //TODO: add starting the animation here once we have the assets (see 3:30 in Brackeys video)

        // find enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(rangeAttackPoint.position, rangeAttackRange, enemyLayers);
    
        // damage the enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name + " with range attack");
            enemy.GetComponent<Enemy>().TakeDamage(rangeAttackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(basicAttackPoint != null){
            Gizmos.DrawWireSphere( basicAttackPoint.position, basicAttackRange);
        } else if(rangeAttackPoint != null) {
            Gizmos.DrawWireSphere( rangeAttackPoint.position, rangeAttackRange);
        }
    }
}
