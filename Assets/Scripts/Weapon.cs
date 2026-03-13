using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int weaponDamage;

    private void OnTriggerEnter(Collider other)
    {
        MeleeEnemy enemy = other.GetComponent<MeleeEnemy>();

        if (enemy != null )
        {
            enemy.TakeDamage(weaponDamage);
        }
    }

    

}
