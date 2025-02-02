using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    private Transform _player;
    private NavMeshAgent _enemyAgent;

    private int point;

    private void Start()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
    }

    public void EnemyMove(Transform[] pointsVariable)
    {
        if (_enemyAgent.transform.position.x != pointsVariable[point].position.x && _enemyAgent.transform.position.x != pointsVariable[point].position.x)
        {
            _enemyAgent.SetDestination(pointsVariable[point].position);
        }
        else
        {
            point = Random.Range(0, pointsVariable.Length);
        }
    }
}
