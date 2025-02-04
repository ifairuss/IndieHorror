using UnityEngine;

public class AISensor : MonoBehaviour
{
    [Header("View preferences")]
    [SerializeField] private GameObject _startLinecastEnemy_1;
    [SerializeField] private GameObject _startLinecastEnemy_2;
    [SerializeField] private GameObject _targetPointPlayer;

    public static bool CanSeePlayer { get; private set; }

    private bool _canPlayerInCollider;

    public void FieldOfViewEnemy(LayerMask layerObstructions)
    {
        if (_canPlayerInCollider)
        {
            if (!Physics.Linecast(_startLinecastEnemy_1.transform.position, _targetPointPlayer.transform.position, layerObstructions) ||
                !Physics.Linecast(_startLinecastEnemy_2.transform.position, _targetPointPlayer.transform.position, layerObstructions))
            {
                CanSeePlayer = true;
                Debug.DrawLine(_startLinecastEnemy_1.transform.position, _targetPointPlayer.transform.position, color: Color.yellow);
                Debug.DrawLine(_startLinecastEnemy_2.transform.position, _targetPointPlayer.transform.position, color: Color.yellow);
            }
            else
            {
                Debug.DrawLine(_startLinecastEnemy_1.transform.position, _targetPointPlayer.transform.position, color: Color.red);
                Debug.DrawLine(_startLinecastEnemy_2.transform.position, _targetPointPlayer.transform.position, color: Color.red);
                CanSeePlayer = false;
            }
        }
        else
        {
            CanSeePlayer = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _canPlayerInCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _canPlayerInCollider = false;
        }
    }
}
