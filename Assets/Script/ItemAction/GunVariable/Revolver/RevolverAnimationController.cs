using UnityEngine;

public class RevolverAnimationController : MonoBehaviour
{
    private AnimationController controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimationController>();
    }

    public void AnimationTakeRevolverStart()
    {
        controller.AnimationRevolverEnded = false;
    }

    public void AnimationTakeRevolverEnded()
    {
        controller.AnimationRevolverEnded = true;
    }
}
