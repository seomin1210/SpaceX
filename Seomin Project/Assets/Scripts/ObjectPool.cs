using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject poolingObjectPrefab;

    public static ObjectPool Instance;
    Queue<EnemyMove> poolingObjectQueue = new Queue<EnemyMove>();

    private void Awake()
    {
        Instance = this;

        Initialize(15);
    }
    private EnemyMove CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<EnemyMove>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }
    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
            poolingObjectQueue.Enqueue(CreateNewObject());
    }
    
    public static EnemyMove GetObject()
    {
        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }
    public static void ReturnObject(EnemyMove obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
}
