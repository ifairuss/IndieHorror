using DG.Tweening;
using UnityEngine;

public class ShakeCameraOnShoot : MonoBehaviour
{
    [Header("Shake setting")]
    [SerializeField] private float _durationOfAnimation = 0.15f;
    [SerializeField] private float _randomnessOfAnimation = 90f;
    [SerializeField] private int _vibrationOfAnimation = 10;
    [SerializeField] private Vector3 _strengthOfAnimation;


    public void ShakeCamera(Movement playerCamera)
    {
        playerCamera.PlayerCamera.transform
            .DOShakePosition(_durationOfAnimation,
            _strengthOfAnimation,
            _vibrationOfAnimation,
            _randomnessOfAnimation,
            false, true, ShakeRandomnessMode.Full)
            .SetEase(Ease.InOutBounce)
            .SetLink(playerCamera.PlayerCamera.gameObject);

        playerCamera.PlayerCamera.transform
            .DOShakeRotation(_durationOfAnimation,
            _strengthOfAnimation,
            _vibrationOfAnimation,
            _randomnessOfAnimation,
             true, ShakeRandomnessMode.Full)
            .SetEase(Ease.Linear)
            .SetLink(playerCamera.PlayerCamera.gameObject);
    }
}
