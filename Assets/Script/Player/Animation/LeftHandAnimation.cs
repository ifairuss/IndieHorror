using UnityEngine;

public class LeftHandAnimation : MonoBehaviour
{
    public void TakeInFlashlite(Animator animator, bool isFlashlite)
    {
        animator.SetBool("isFlashlite", isFlashlite);
    }
}
