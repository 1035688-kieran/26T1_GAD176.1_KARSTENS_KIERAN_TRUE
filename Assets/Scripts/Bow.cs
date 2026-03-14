using UnityEngine;

public class Bow : Weapon
{
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform firePoint; // This is similiar to the rangedenemy firepoint, this is where the arrow shoots from

    private bool isEquipped = false;

    private void Update()
    {
        
        if (isEquipped && Input.GetButtonDown("Fire1")) // Left click to fire, just like the sword
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("Bow has been fired!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isEquipped) return;

        if (other.CompareTag("Player")) // Due to having weapons that the enemy ai can use, this makes sure its only the player accessing it.
        {
            EquipBow(other.GetComponent<playerStats>());
        }
    }

    void EquipBow(playerStats player)
    {
        isEquipped = true;
        if (player != null)
        {
            player.hasSword = false; //functions the same way as HasSword, but helps me not have to create a seperate boolean
            player.equippedWeapon = this;
        }

        transform.SetParent(weaponHolder);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        GetComponent<Rigidbody>().isKinematic = true;
    }
}
