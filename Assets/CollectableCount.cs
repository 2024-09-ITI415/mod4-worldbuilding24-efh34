using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleCount : MonoBehaviour
{
    Text text;
    int count;

    // Reference to the GameManager script to call OnAllCoinsCollected
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Start()
    {
        StartCoroutine(InitializeCounter());
    }

    private IEnumerator InitializeCounter()
    {
        yield return null; // Wait one frame to allow all Collectable objects to initialize
        UpdateCount();
    }

    private void OnEnable()
    {
        Collectable.OnCollected += OnCollectableCollected;
    }

    private void OnDisable()
    {
        Collectable.OnCollected -= OnCollectableCollected;
    }

    private void OnCollectableCollected()
    {
        count++;
        UpdateCount();

        // Check if all collectables are collected and call the method in GameManager to show win text
        if (count >= Collectable.total)
        {
            gameManager.OnAllCoinsCollected();
        }
    }

    private void UpdateCount()
    {
        text.text = $"{count} / {Collectable.total}";
        Debug.Log($"Count updated: {count} / {Collectable.total}");
    }
}
