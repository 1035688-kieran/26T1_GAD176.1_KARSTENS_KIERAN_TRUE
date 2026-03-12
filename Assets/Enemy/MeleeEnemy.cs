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
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime); // Calculates the speed of the AI chasing using the pre-determined enemySpeed
    }

    private void Attack()
    {
        if (Time.time >= lastAttackInstance + attackCooldown)
        {
            Debug.Log("The spooky EnemyAI of Melee Class is probably attacking! oo very scawy THIS IS A TEST MESSAGE");

            lastAttackInstance = Time.time;
        }
    }


}
