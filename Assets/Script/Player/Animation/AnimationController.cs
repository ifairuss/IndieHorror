using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _leftHand;
    private Animator _rightHand;

    private LeftHandAnimation _leftHandAnimation;

    private void Start()
    {
        _leftHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<Animator>();
        _rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Animator>();

        _leftHandAnimation = GetComponentInChildren<LeftHandAnimation>();
    }

    public void ActiveAnimation(bool isFlashlite)
    {
        _leftHandAnimation.TakeInFlashlite(_leftHand, isFlashlite);
    }
}
