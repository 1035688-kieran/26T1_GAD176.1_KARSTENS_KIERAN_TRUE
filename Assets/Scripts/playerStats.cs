using Unity.VisualScripting;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int curHealth;

    public bool hasSword = false;
    public Weapon equippedWeapon;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        if (hasSword && Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("Player attacking");

        if (equippedWeapon != null)
        {
            equippedWeapon.EnableDamage();
            Invoke(nameof(StopAttack), 0.3f);
        }
    }

    void StopAttack()
    {
        if (equippedWeapon != null)
        {
            equippedWeapon.DisableDamage();
        }
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;

        Debug.Log("Player took damage: " + damage);

        if (curHealth <= 0)
        {
            Debug.Log("Player died");
        }
    }
}

////// HELPFUL SOURCES THAT I AM USING
/// 
// https://docs.unity3d.com/ScriptReference/Physics.Raycast.html RAYCAST GENERAL INFORMATION AND USAGE
// https://docs.unity3d.com/ScriptReference/Time-timeScale.html TIME SCALE, WHICH CAN HELP SPEED UP OR SLOW DOWN AN APPLICATION, ROBERT PUT IT BEST "IT IS BASICALLY TIME TRAVEL"
// https://www.youtube.com/watch?v=sPiVz1k-fEs YOUTUBE VIDEO FOR GENERAL COMBAT AND HEALTH STATS (BRACKEYS)
//////