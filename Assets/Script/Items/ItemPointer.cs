using System.Collections;
using UnityEngine;

public class ItemPointer : MonoBehaviour
{
    private Camera _player;
    private RectTransform  _gameObject;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();
        _gameObject = GetComponentInChildren<RectTransform>();
        _gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        ItemsPointer();
    }

    public void ItemsPointer()
    {
        float distance = Vector3.Distance(transform.position, _player.transform.position);
        _gameObject.LookAt(_player.transform.position);

        if (distance <= 15)
        {
            StartCoroutine(MarkerScalePlus());
            StopCoroutine(MarkerScaleMinus());
        }
        else
        {
            StartCoroutine(MarkerScaleMinus());
            StopCoroutine(MarkerScalePlus());
        }
    }

    private IEnumerator MarkerScalePlus()
    {
        _gameObject.gameObject.SetActive(true);
        Vector3 normalScale = new Vector3(0.001f, 0.001f, 0.001f);
        float scale = 0;

        while (_gameObject.transform.localScale != normalScale)
        {
            _gameObject.transform.localScale = new Vector3(scale, scale, scale);
            scale += 0.0001f;

            yield return null;
        }
    }

    private IEnumerator MarkerScaleMinus()
    {
        Vector3 normalScale = new Vector3(0, 0, 0);
        float scale = 0.001f;

        while (_gameObject.transform.localScale != normalScale)
        {
            _gameObject.transform.localScale = new Vector3(scale, scale, scale);
            scale -= 0.0001f;

            yield return null;
        }

        if (scale == 0)
        {
            _gameObject.gameObject.SetActive(false);
        }
    }
}
