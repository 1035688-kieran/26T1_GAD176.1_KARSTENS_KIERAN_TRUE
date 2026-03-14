using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 4f; // Speed of the enemy
    [SerializeField] private float stopDistance = 8f;
    [SerializeField] private float retreatDistance = 4f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint; // So that there is a set place to fire from, and that the projectiles dont spawn in the body and have wacky collision
    [SerializeField] private float projectileCooldown = 3f; // So that the projectiles come out staggered
    [SerializeField] private int damage = 5; //less damage than the melee AI
    [SerializeField] public int maxEnemyHealth = 30;
    [SerializeField] private int curEnemyHealth;
    [SerializeField] private float lastAttackInstance; // to make sure that attacks arent stacking.
    [SerializeField] public Transform player;
    void Start()
    {
        curEnemyHealth = maxEnemyHealth;
        lastAttackInstance = -projectileCooldown;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            MoveToPlayer(player.position);
        }

        else if (distance < retreatDistance)
        {
            Vector3 retreatPos = transform.position - (player.position - transform.position);
            MoveToPlayer(retreatPos);
        }

        if (distance <= stopDistance)
        {
            Attack();
        }

        FacePlayer();
    }

    private void MoveToPlayer(Vector3 targetPos)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, enemySpeed * Time.deltaTime);
    }

    private void Attack()
    {
        if (Time.time >= lastAttackInstance + projectileCooldown && firePoint != null)
        {
            Debug.Log("RANGED ENEMY IS SHOOTING!!!!");

            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            lastAttackInstance = Time.time;
        }
    }

    public void TakeDamage(int damage)
    {
        curEnemyHealth -= damage;
        {
            Debug.Log("Enemy took damage: " + damage);
        }

        if (curEnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FacePlayer() // Function so that the object looks at the player
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0;

        if (direction != Vector3.zero) // Direction is dead centre
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}

