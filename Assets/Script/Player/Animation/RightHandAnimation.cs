using UnityEngine;

public class RightHandAnimation : MonoBehaviour
{
    public void PickUpItems(Animator animator, bool isRevolver, bool isKnife, bool isCrowbar)
    {
        animator.SetBool("isRevolver", isRevolver);
        animator.SetBool("isKnife", isKnife);
        animator.SetBool("isCrowbar", isCrowbar);
    }

    public void GunTrigger(Animator animator)
    {
        animator.SetTrigger("RevolverShoot");
    }
}
