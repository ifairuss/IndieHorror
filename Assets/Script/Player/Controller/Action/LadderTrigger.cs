using UnityEngine;

public class LadderTrigger : MonoBehaviour
{
    public bool IsClimb { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsClimb = true;

            print("Player in Ladder trigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsClimb = false;

            print("Player in not Ladder trigger");
        }
    }
}
