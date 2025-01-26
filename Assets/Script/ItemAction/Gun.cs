using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public int AmmountBullet;
    public float NewTimeBetweenShoot;

    [HideInInspector]public float TimeBetweenShoot;

    public Transform SpawnPointBullets;
    public GameObject PrefabBullet;
    public ParticleSystem MuzzleFlash;

    public Movement MovementController;

    private void Awake()
    {
        MuzzleFlash.gameObject.SetActive(false);
        MovementController = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    public virtual void Shoot() {}
}
