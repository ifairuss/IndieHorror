using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy sensor preferences")]
    [SerializeField] private float _distanceView = 10;
    [SerializeField] private float _angleView = 45;
    [SerializeField] private float _heightView = 10;
    [SerializeField] private Color _meshViewColor;

    [Header("Enemy points setting")]
    [SerializeField] private Transform[] _movePoints;

    private EnemyMoving _enemyMoveController;

    private void Awake()
    {
        _enemyMoveController = GetComponent<EnemyMoving>();
    }

    private void Update()
    {
        EnemyMoveController();
    }

    private void EnemyMoveController()
    {
        _enemyMoveController.EnemyMove(_movePoints);
    }
}
