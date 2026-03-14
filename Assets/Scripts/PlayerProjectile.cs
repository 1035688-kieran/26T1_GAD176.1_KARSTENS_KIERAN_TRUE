using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    //This is roughly based on the EnemyProjectile script
    [SerializeField] private float speed = 25f;
    [SerializeField] private int damage = 20;
    [SerializeField] private float lifetime = 5f;

    void Start() => Destroy(gameObject, lifetime);

    void Update() => transform.Translate(Vector3.forward * speed * Time.deltaTime);

    private void OnTriggerEnter(Collider other)
    {
        
        MeleeEnemy melee = other.GetComponent<MeleeEnemy>(); // This is if we hit a melee enemy
       
        RangedEnemy ranged = other.GetComponent<RangedEnemy>(); // This is the distinction for a ranged enemy

        if (melee != null)
        {
            melee.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (ranged != null)
        {
            ranged.TakeDamage(damage);
            Destroy(gameObject);
        }
        
        else if (!other.CompareTag("Player")) // This is for if we hit anything that isnt an enemy, aka a wall or ground
        {
            Destroy(gameObject);
        }
    }
}
