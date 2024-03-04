using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] string itemName;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerOne") || collision.gameObject.CompareTag("PlayerTwo"))
        {
           Managers.Inventory.AddItem(itemName);
            Destroy(gameObject);
        }
    }
}


