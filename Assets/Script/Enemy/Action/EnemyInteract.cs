using UnityEngine;

public class EnemyInteract : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            var door = other.gameObject.GetComponent<InteractionDoor>();

            door.IsOpenDoor = true;
        }

        if (other.gameObject.tag == "LockedDoor")
        {
            var door = other.gameObject.GetComponent<InteractionLockerDoor>();

            door.IsOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            var door = other.gameObject.GetComponent<InteractionDoor>();

            door.IsOpenDoor = false;
        }

        if (other.gameObject.tag == "LockedDoor")
        {
            var door = other.gameObject.GetComponent<InteractionLockerDoor>();

            door.IsOpen = false;
        }
    }
}
