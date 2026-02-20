using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyID;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inv = other.GetComponent<Inventory>();

            if (inv != null)
            {
                inv.AddKey(keyID);
                Destroy(gameObject);
            }
        }
    }
}
