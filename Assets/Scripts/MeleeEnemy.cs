using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    [SerializeField] private float enemySpeed = 4f; // Speed of the enemy
    [SerializeField] private float attackRange = 5f; // How far the enemy can attack
    [SerializeField] private float attackCooldown = 2.5f; // Time being attacks
    [SerializeField] private int damage = 10; // Damage the enemy does to the player
    [SerializeField] private float lastAttackInstance; // Last time that the enemy attacked
    [SerializeField] public Transform player;
    [SerializeField] public int maxEnemyHealth = 50;
    [SerializeField] public int curEnemyHealth;

    void Start()
    {
        curEnemyHealth = maxEnemyHealth; // Enemy healths starts at the maximum just like the player
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            ChasePlayer(); // If not in attack range, will start chase function
        }
        else
        {
            Attack(); // This function is connected to my damage functions
        }

        FacePlayer(); // Will use Vectors to track the location of the player and ""Face"" them
    }

    private void ChasePlayer() // Tracking function
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime); // Calculates the speed of the AI chasing using the pre-determined enemySpeed
    }

    private void Attack() // Attack function including damage 
    {
        if (Time.time >= lastAttackInstance + attackCooldown)
        {
            Debug.Log("The spooky EnemyAI of Melee Class is probably attacking! oo very scawy THIS IS A TEST MESSAGE");
            playerStats playerHealth = player.GetComponent<playerStats>(); // Connects back to my player stats/health script

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Debug.Log("The EnemyAI of Melee Class is Attacking! THIS IS A TEST MESSAGE");

            lastAttackInstance = Time.time;
        }
    }

    public void TakeDamage(int damage)
    {
        curEnemyHealth -= damage;

        Debug.Log("Wow you managed to land a hit!! It has uhhhh, how much health left?" + curEnemyHealth);

        if (curEnemyHealth <= 0)
        {
            SpontaneousCombustion2(); // This is my EnemyDie command
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

    private void SpontaneousCombustion2()
    {
        Destroy(gameObject); // Removes the enemy from the scene
    }

}

////// HELPFUL SOURCES THAT I AM USING
/// VECTOR AND QUATERNION STUFF
// https://docs.unity3d.com/ScriptReference/Vector3.Distance.html DISTANCE VECTOR AND EXPLANATION
// https://docs.unity3d.com/ScriptReference/Vector3.MoveTowards.html MOVE TOWARDS VECTOR FOR MY ENEMY CHASING MY PLAYER
// https://docs.unity3d.com/ScriptReference/Quaternion.LookRotation.html HOW TO MAKE MY ENEMY LOOK IN THE DIRECTION OF MY PLAYER FOR THE FACEPLAYER FUNCTION
///


