using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            door.PlayerNear(true, other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            door.PlayerNear(false, null);
    }
}
