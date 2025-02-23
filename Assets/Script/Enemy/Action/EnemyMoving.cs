using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    [Header("Enemy target preferences")]
    [SerializeField] private Transform playerPoint;

    private Transform _player;
    private NavMeshAgent _enemyAgent;
    private Animator _enemyAnimator;

    private bool _canAnimation;

    public void Initialized()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _enemyAnimator = GetComponent<Animator>();

        playerPoint.transform.position = transform.position;
    }

    public void EnemyMove(Transform[] pointsVariable, bool canSee)
    {
        if (!_canAnimation)
        {
            playerPoint.position = pointsVariable[Random.Range(0, pointsVariable.Length)].position;
            _canAnimation = true;
        }

        float distance = Vector3.Distance(transform.position, playerPoint.position);

        if (!canSee)
        {
            if (distance > 6.5f)
            {
                _enemyAgent.SetDestination(playerPoint.position);
            }
            else
            {
                _canAnimation = true;
                _enemyAnimator.SetBool("EnemyReview", true);
            }
        }
        else
        {
            playerPoint.position = _player.position;

            if (distance > 6.5f)
            {
                _enemyAgent.SetDestination(playerPoint.position);
            }

        }
    }

    public void SetNexPosition()
    {
        _canAnimation = false;
        _enemyAnimator.SetBool("EnemyReview", false);
    }
}
