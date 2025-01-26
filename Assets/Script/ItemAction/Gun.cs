using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public int AmmountBullet;
    public float NewTimeBetweenShoot;

    [HideInInspector]public float TimeBetweenShoot;

    public Transform SpawnPointBullets;
    public GameObject PrefabBullet;
    public ParticleSystem MuzzleFlash;

    [HideInInspector] public Movement MovementController;
    [HideInInspector] public ShakeCameraOnShoot ShakeCameraController;
    [HideInInspector] public AnimationController AnimationGun;

    private void Awake()
    {
        MuzzleFlash.gameObject.SetActive(false);

        ShakeCameraController = GetComponent<ShakeCameraOnShoot>();
        MovementController = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        AnimationGun = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimationController>();
    }

    public virtual void Shoot() {}
}
