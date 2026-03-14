using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] private Transform weaponHolder;

    private bool isEquipped = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if (isEquipped) return; // Makes sure that the pick-ups dont stack

        if (other.CompareTag("Player"))
        {
            Debug.Log("Sword picked up");

            playerStats player = other.GetComponent<playerStats>();

            if (player != null)
            {
                player.hasSword = true;
                player.equippedWeapon = this;
            }

            EquipSword();
        }
    }

    void EquipSword()
    {
        isEquipped = true;

        transform.SetParent(weaponHolder); // Sets the sword to the player, as to not clip through floor

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        Rigidbody rb = GetComponent<Rigidbody>(); // disables physics so while in hand it doesnt fall
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        Collider col = GetComponent<Collider>(); // Makes sure it can attack enemies.
        if (col != null)
        {
            col.isTrigger = true;
        }
    }
}
