using UnityEngine;

public class playerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; // Max health of the PLAYER, might use this script for inheritence
    [SerializeField] private int curHealth; // Variable controlling the current health of the player

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
            spontaneousCombustion(); // This is my "Die" command
        }
    }

    private void spontaneousCombustion()
    {
        Debug.Log("you died!!! RIP"); // will add code to end game
        Time.timeScale = 0f; // Sets the time scale to 0, effectively freezing the game, and being a game-over
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
