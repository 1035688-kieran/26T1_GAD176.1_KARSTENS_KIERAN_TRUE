using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    [SerializeField] private float enemySpeed = 4f; // Speed of the enemy
    [SerializeField] private float attackRange = 5f; // How far the enemy can attack
    [SerializeField] private float attackCooldown = 2.5f; // Time being attacks

    [SerializeField] private float lastAttackInstance; // Last time that the enemy attacked
    [SerializeField] public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            ChasePlayer(); // If in
        }
        else
        {
            Attack();
        }

        FacePlayer();
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime); // Calculates the speed of the AI chasing using the pre-determined enemySpeed
    }

    private void Attack()
    {
        if (Time.time >= lastAttackInstance + attackCooldown)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Debug.Log("The EnemyAI of Melee Class is Attacking! THIS IS A TEST MESSAGE");

            lastAttackInstance = Time.time;
        }
    }

    private void FacePlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }


}
