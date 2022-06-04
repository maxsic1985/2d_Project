using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private Stack<GameObject> _stack = new Stack<GameObject>();
    private readonly GameObject _prefab;
    private readonly Transform _rootTransform;
    private readonly int _poolCnt;
    public int PoolCnt => _poolCnt;
    public ObjectPool(GameObject prefab, int poolCnt)
    {
        _poolCnt = poolCnt;
        _prefab = prefab;
        _rootTransform = new GameObject($"[{_prefab.name}]").transform;
        Initialise(poolCnt);
    }
    private void Initialise(int poolCnt)
    {
        for (int i = 0; i < poolCnt; i++)
        {
            var go = GameObject.Instantiate(_prefab);
            go.name = _prefab.name + i;
            Push(go);
        }
    }
    public GameObject Pop()
    {
        GameObject gameObject;
        if (_stack.Count == 0)
        {
            gameObject = GameObject.Instantiate(_prefab);
            gameObject.name = _prefab.name;
            _stack.Push(gameObject);
        }

        gameObject = _stack.Pop();
        gameObject.SetActive(true);
        gameObject.transform.SetParent(null);
        return gameObject;
    }
    public void Push(GameObject gameObject)
    {
        gameObject.transform.SetParent(_rootTransform);
        gameObject.transform.position = Vector3.zero;
        gameObject.SetActive(false);
        _stack.Push(gameObject);
    }
}
