using UnityEngine;

public class Revolver : Gun
{
    private bool _canShoot;

    private void Update()
    {
        if (TimeBetweenShoot <= 0) { _canShoot = true; }
        else { _canShoot = false; TimeBetweenShoot -= Time.deltaTime; }
    }

    public override void Shoot()
    {
        if (_canShoot == true)
        {
            MuzzleFlash.gameObject.SetActive(true);
            Bullet bullet = Instantiate(PrefabBullet, SpawnPointBullets.position, MovementController.PlayerCamera.transform.rotation).GetComponent<Bullet>();
            bullet.MoveBullet(MovementController.PlayerCamera);
            MuzzleFlash.Play();
            AnimationGun.RevolverShootAnimation();
            ShakeCameraController.ShakeCamera(MovementController);
            TimeBetweenShoot = NewTimeBetweenShoot;
        }
    }
}
