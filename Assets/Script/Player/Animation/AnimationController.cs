using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _playerAnimator;

    private LeftHandAnimation _leftHandAnimation;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();

        _leftHandAnimation = GetComponentInChildren<LeftHandAnimation>();
    }

    public void ActiveAnimation(bool isFlashlite)
    {
        _leftHandAnimation.TakeInFlashlite(_playerAnimator, isFlashlite);
    }
}
