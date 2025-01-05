using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _leftHand;
    private Animator _rightHand;

    private LeftHandAnimation _leftHandAnimation;
    private RightHandAnimation _rightHandAnimation;

    private void Start()
    {
        _leftHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<Animator>();
        _rightHand = GameObject.FindGameObjectWithTag("RightHand").GetComponent<Animator>();

        _leftHandAnimation = GetComponentInChildren<LeftHandAnimation>();
        _rightHandAnimation = GetComponentInChildren<RightHandAnimation>();
    }

    public void ActiveAnimation(bool isFlashlite, bool isRevolver, bool isKnife)
    {
        _leftHandAnimation.TakeInFlashlite(_leftHand, isFlashlite);
        _rightHandAnimation.PickUpItems(_rightHand, isRevolver, isKnife);
    }
}
