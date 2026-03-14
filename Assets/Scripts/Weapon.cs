using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected int weaponDamage = 20;

    protected bool canDamage = false;

    public void EnableDamage()
    {
        canDamage = true;
    }

    public void DisableDamage()
    {
        canDamage = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!canDamage) return;

        MeleeEnemy melee = other.GetComponent<MeleeEnemy>();
        RangedEnemy ranged = other.GetComponent<RangedEnemy>();

        if (melee != null)
        {
            melee.TakeDamage(weaponDamage);
            Debug.Log("Hit melee enemy for " + weaponDamage);
        }

        if (ranged != null)
        {
            ranged.TakeDamage(weaponDamage);
            Debug.Log("Hit ranged enemy for " + weaponDamage);
        }
    }
}

