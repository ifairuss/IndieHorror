using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Preferences")]
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private LayerMask _bulletCollisionMask;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    public void MoveBullet(Camera cameraPosition)
    {
        var bulletRb = GetComponent<Rigidbody>();
        bulletRb.AddForce(cameraPosition.transform.forward * _bulletSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_bulletCollisionMask == (_bulletCollisionMask | (1 << collision.gameObject.layer)))
        {
            Destroy(gameObject);
        }
    }
}
