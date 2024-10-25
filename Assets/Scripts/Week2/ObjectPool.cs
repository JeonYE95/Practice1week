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
        // 미리 poolSize만큼 게임오브젝트를 생성한다.
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
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.
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
        // 게임오브젝트를 deactive한다.
        if (pools.ContainsKey(key) && pools[key].Contains(obj))
        {
            obj.SetActive(false);
        }
    }
}