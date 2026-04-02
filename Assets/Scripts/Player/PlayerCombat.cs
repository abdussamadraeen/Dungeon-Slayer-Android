using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public GameObject sound;

    public float attactRate = 0.6f;
    public float attackRange = 1f;
    private float nextAttactTime = 0.5f;

    // Update is called once per frame
    void Update() {

        // Prevents spamming
        if (Time.time >= nextAttactTime) {
            if (Input.GetKeyDown(KeyCode.F)) {
                Attack();
                nextAttactTime = Time.time + attactRate / attackRange;
            }
        }
        
    }

    void Attack() {
        // Play an animation
        animator.SetTrigger("attack");

        // Sound
        Instantiate(sound);

        // Detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Subtract the damage
        foreach (Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().TakeDamage(Stats.instance.getAttackDamage());

            if(GetComponent<Stats>().getPower() != 4)
                GetComponent<Stats>().takePower(1);

            break;
        }
    }

    private void OnDrawGizmosSelected() {

        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void AttackButton() {
        // Prevents spamming
        if (Time.time >= nextAttactTime) {
            Attack();
            nextAttactTime = Time.time + attactRate / attackRange;
        }
    }
}
