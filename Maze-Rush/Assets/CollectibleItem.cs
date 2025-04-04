using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private string itemName; //"collectble1", "collectble2" of "collectble3"
    [SerializeField] private Sprite itemSprite;
    private SimpleInventory inventory;

    void Start()
    {
        // Vind de inventory in de scene
        inventory = FindObjectOfType<SimpleInventory>();

        // Stel sprite in als deze niet is ingesteld
        if (itemSprite == null)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                itemSprite = renderer.sprite;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) // Voor 2D games
    {
        if (other.CompareTag("Player"))
        {
            if (inventory != null)
            {
                inventory.AddItem(itemName);
                Destroy(gameObject); // Verwijder het item uit de wereld
            }
        }
    }

    // Voor 3D games kun je deze gebruiken in plaats van OnTriggerEnter2D
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventory != null)
            {
                inventory.AddItem(itemName);
                Destroy(gameObject);
            }
        }
    }
}