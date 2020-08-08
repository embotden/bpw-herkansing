using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Brackeys tutorial Melee Combat

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public float attackRate = 2f;

    private float nextAttackTime = 0f;

    public int AttackDamage = 40;

    private float dazedTime;
    public float startDazedTime;

    private void Start()
    {
        //EnemyPatrol playerScript = GetComponent<EnemyPatrol>(); //?
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)//If time between attacks is right, you van attack again
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //Play attack animation
        animator.SetTrigger("Attack");

        //Detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage enemy
        foreach(Collider2D enemy in hitEnemies)
        {
            //Debug.Log("We hit " + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(AttackDamage);

        }

        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //HealthManager.HurtPlayer(damageToGive);

               
        }
    }
}
