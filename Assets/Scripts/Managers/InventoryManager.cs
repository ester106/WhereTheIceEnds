using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
