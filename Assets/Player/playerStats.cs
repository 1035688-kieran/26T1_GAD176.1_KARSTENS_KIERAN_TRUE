using Unity.VisualScripting;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Max health of the PLAYER, might use this script for inheritence
    [SerializeField] private int curHealth; // Variable controlling the current health of the player
    [SerializeField] private float attackRange; // Range of attack for player
    [SerializeField] private int damage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P KEY HAS BEEN PRESSED");
            PlayerAttack();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curHealth = maxHealth; // Upon starting, the current health is equal to the max health
        
    }

    public void TakeDamage(int damage) // Currently public but we will see what happens, if it ends up just being for the player it will stay public
    {
        curHealth -= damage;
        Debug.Log(" <color = red>Player has taken damage, oh noes! very sad :((( current healthers is at uhhh" + curHealth + "</color>"); // Thank you for the colour robert!!!!!!!!!!!! 

        if (curHealth <= 0)
        {
            SpontaneousCombustion(); // This is my "Die" command
        }
    }

    private void SpontaneousCombustion()
    {
        Debug.Log("you died!!! RIP"); // will add code to end game
        Time.timeScale = 0f; // Sets the time scale to 0, effectively freezing the game, and being a game-over
    }

    private void PlayerAttack() 
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange)) // Where the raycast starts, and where the raycast ends as well as the range
        {
            MeleeEnemy enemyHealth = hit.collider.GetComponent<MeleeEnemy>();

            if (enemyHealth != null)
            {
                Debug.Log("Enemy is being shot at!");
                enemyHealth.TakeDamage(damage); // Enemy takes damage from the takedamage function above
            }
        }
    } 

}

////// HELPFUL SOURCES THAT I AM USING
/// 
// https://docs.unity3d.com/ScriptReference/Physics.Raycast.html RAYCAST GENERAL INFORMATION AND USAGE
// https://docs.unity3d.com/ScriptReference/Time-timeScale.html TIME SCALE, WHICH CAN HELP SPEED UP OR SLOW DOWN AN APPLICATION, ROBERT PUT IT BEST "IT IS BASICALLY TIME TRAVEL"
// https://www.youtube.com/watch?v=sPiVz1k-fEs YOUTUBE VIDEO FOR GENERAL COMBAT AND HEALTH STATS (BRACKEYS)
//////