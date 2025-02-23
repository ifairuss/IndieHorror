using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
