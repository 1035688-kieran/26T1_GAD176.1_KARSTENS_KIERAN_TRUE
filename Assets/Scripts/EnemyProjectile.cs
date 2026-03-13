using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private int damage = 10;
    [SerializeField] private float lifetime = 5f;

    void Start() 
        
        => Destroy(gameObject, lifetime); // I want the item to expire in the lifetime, 5f

    void Update()
    
        => transform.Translate(Vector3.forward * speed * Time.deltaTime); // I want the projectiles to travel forward x speed x time


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerStats>()?.TakeDamage(damage);
            Destroy(gameObject); // Causes damage to strictly the player
        }
        else if (!other.CompareTag("Enemy"))
        {
            Destroy(gameObject); // no damage to player and still dissapears
        }
    }
}
