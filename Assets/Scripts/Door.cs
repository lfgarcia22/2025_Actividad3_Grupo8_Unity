using UnityEngine;

public class Door : MonoBehaviour
{
    public string requiredKeyID;
    bool playerNear;
    Inventory inv;

    public void PlayerNear(bool state, Collider2D player)
    {
        playerNear = state;
        if (player != null)
            inv = player.GetComponentInParent<Inventory>();
    }

    void Update()
    {
        if (playerNear)
        {
            if (inv != null && inv.HasKey(requiredKeyID))
                OpenDoor();
        }
    }

    void OpenDoor()
    {
        Destroy(gameObject);
    }
}
