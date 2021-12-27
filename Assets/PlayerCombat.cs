using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   public Animator animator;
    // Update is called once per frame
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    
    public LayerMask enemyLayers;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play an Attack Animation 

        animator.SetTrigger("Attack");
        //Detect Enemies 

        Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
        }
        //Apply Damage
    }


     void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
