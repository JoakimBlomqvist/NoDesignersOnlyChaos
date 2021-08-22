using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public int number;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    
    public static ObjectPool Instance;
    private int count;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    #endregion

    public List<Pool> pools;
    public Dictionary<int, Queue<GameObject>> poolDictionary;

    //Creates a pool of objects that is disabled on start. The pool is created in the unity editor. 
    //size sets how many objects of an item you want to spawn as disabled.
    private void Start()
    {
        poolDictionary = new Dictionary<int, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (var i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            count++;
            pool.number = count;
            
            poolDictionary.Add(pool.number, objectPool);
        }
    }

    //Function that is called when another script wanna spawn something from the object pool. Sets rotation and
    //position to to the position and rotations requested on the functions parameters.
    public GameObject SpawnFromPool(int number, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(number))
        {
            Debug.LogWarning("Pool with number " + number + " doesn't exist");
            return null;
        }
        
        
        GameObject objectToSpawn = poolDictionary[number].Dequeue();
        
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        poolDictionary[number].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
