using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public ObjectPool poolManager;
    public GameObject monsterPrefab;
    public GameObject arrowPrefab;

    private List<GameObject> pool = new List<GameObject>();
    private Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();

    private void Start()
    {        
        // �̸� poolSize��ŭ ���ӿ�����Ʈ�� �����Ѵ�.
        poolManager.InitializePool("Arrow", arrowPrefab, 300);
        poolManager.InitializePool("Monster", monsterPrefab, 300);
    }

    public void InitializePool(string key, GameObject prefab, int poolSize)
    {
        if (!pools.ContainsKey(key))
        {
            List<GameObject> pool = new List<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                pool.Add(obj);
            }
            pools.Add(key, pool);
        }
    }

    public GameObject Get(string key)
    {
        // �����ִ� ���ӿ�����Ʈ�� ã�� active�� ���·� �����ϰ� return �Ѵ�.
        if (pools.ContainsKey(key))
        {
            foreach (GameObject obj in pool)
            {
                if (!obj.activeSelf)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
        }
        return null;
    }

    public void Release(string key, GameObject obj)
    {
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
        if (pools.ContainsKey(key) && pools[key].Contains(obj))
        {
            obj.SetActive(false);
        }
    }
}