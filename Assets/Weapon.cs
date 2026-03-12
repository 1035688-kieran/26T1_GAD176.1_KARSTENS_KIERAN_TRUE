using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private bool isEquipped;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isEquipped = false;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
