using UnityEngine;

public class RightHandAnimation : MonoBehaviour
{
    public void PickUpItems(Animator animator, bool isRevolver, bool isKnife)
    {
        animator.SetBool("isRevolver", isRevolver);
        animator.SetBool("isKnife", isKnife);
    }
}
