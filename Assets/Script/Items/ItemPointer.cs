using UnityEngine;

public class ItemPointer : MonoBehaviour
{
    private Camera _player;
    private RectTransform  _gameObject;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();
        _gameObject = GetComponentInChildren<RectTransform>();
    }

    private void Update()
    {
        ItemsPointer();
    }

    public void ItemsPointer()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        if (distance <= 15)
        {
            _gameObject.gameObject.SetActive(true);
            _gameObject.LookAt(_player.transform.position);
        }
        else
        {
            _gameObject.gameObject.SetActive(false);
        }
    }
}
