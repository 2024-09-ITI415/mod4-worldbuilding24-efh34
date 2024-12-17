using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Event for when a collectable is collected
    public static event Action OnCollected;
    public static int total;

    private void Awake()
    {
        // Increment the total count when a collectable is created
        total++;
        Debug.Log($"Collectable created. Total is now: {total}");
    }

    private void Update()
    {
        // Rotate the collectable object for a visual effect
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collects the item
        if (other.CompareTag("Player"))
        {
            OnCollected?.Invoke(); // Notify that the collectable was collected
            Destroy(gameObject);   // Destroy the collectable object
        }
    }
}
