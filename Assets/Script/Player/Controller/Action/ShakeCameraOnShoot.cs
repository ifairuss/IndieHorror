using DG.Tweening;
using UnityEngine;

public class ShakeCameraOnShoot : MonoBehaviour
{
    [Header("Shake setting")]
    [SerializeField] private float _durationOfAnimation = 0.15f;
    [SerializeField] private float _randomnessOfAnimation = 90f;
    [SerializeField] private int _vibrationOfAnimation = 10;
    [SerializeField] private Vector3 _strengthOfAnimation;
    [SerializeField] private Transform _objectShake;


    public void ShakeCamera()
    {
        _objectShake.transform
            .DOShakePosition(_durationOfAnimation,
            _strengthOfAnimation,
            _vibrationOfAnimation,
            _randomnessOfAnimation,
            false, true, ShakeRandomnessMode.Full)
            .SetEase(Ease.OutExpo)
            .SetLink(_objectShake.gameObject);

        _objectShake.transform
            .DOShakeRotation(_durationOfAnimation,
            _strengthOfAnimation,
            _vibrationOfAnimation,
            _randomnessOfAnimation,
             true, ShakeRandomnessMode.Full)
            .SetEase(Ease.Linear)
            .SetLink(_objectShake.gameObject);
    }
}
