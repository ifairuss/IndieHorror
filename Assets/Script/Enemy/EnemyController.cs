using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy state")]
    [SerializeField] private bool _canSeePlayer;

    [Header("Enemy sensor preferences")]
    [SerializeField] private LayerMask _allObstructionsLayer;

    [Header("Enemy points setting")]
    [SerializeField] private Transform[] _movePoints;

    private EnemyMoving _enemyMoveController;
    private AISensor _fieldOfView;

    private void Awake()
    {
        _enemyMoveController = GetComponent<EnemyMoving>();
        _fieldOfView = GetComponentInChildren<AISensor>();
    }

    private void Update()
    {
        EnemyMoveController();
    }

    private void EnemyMoveController()
    {
        _canSeePlayer = AISensor.CanSeePlayer;
        _fieldOfView.FieldOfViewEnemy(_allObstructionsLayer);
        _enemyMoveController.EnemyMove(_movePoints, _canSeePlayer);
    }
}