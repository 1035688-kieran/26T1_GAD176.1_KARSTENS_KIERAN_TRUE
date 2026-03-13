using UnityEngine;

public class Sword : Weapon

{
    [SerializeField] private Transform weaponHolder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("SWORD IS PICKED UP");

            playerStats player = other.GetComponent<playerStats>();

            if (player != null)
            {
                player.hasSword = true;
                Debug.Log("Player can now attack");
            }
            transform.SetParent(weaponHolder);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().isTrigger = false;
        }
    }


}
