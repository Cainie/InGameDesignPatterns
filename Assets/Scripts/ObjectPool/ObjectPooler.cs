using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPooler : MonoBehaviour
    {
        [Serializable]
        private class Pool
        {
            public string tag;
            public GameObject prefabToInstantiate;
            public int poolSize;
        }

        [SerializeField] private List<Pool> pools;
        
        private Dictionary<string, Queue<GameObject>> poolDictionary;

        public static ObjectPooler Instance;
    
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (var pool in pools)
            {
                var objectPool = new Queue<GameObject>();

                for (var i = 0; i < pool.poolSize; i++)
                {
                    var instantiatedObject = Instantiate(pool.prefabToInstantiate);
                    instantiatedObject.SetActive(false);
                
                    objectPool.Enqueue(instantiatedObject);
                }
            
                poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject GetFromPool(string objectTag, Vector3 desiredPosition, Quaternion desiredRotation)
        {
            if (!poolDictionary.ContainsKey(objectTag))
            {
                Debug.LogWarning($"Pool with tag {objectTag} does not exist");
                return null;
            }
        
            var objectToBeUsed = poolDictionary[objectTag].Dequeue();
            objectToBeUsed.SetActive(true);
            objectToBeUsed.transform.position = desiredPosition;
            objectToBeUsed.transform.rotation = desiredRotation;
        
            poolDictionary[objectTag].Enqueue(objectToBeUsed);

            return objectToBeUsed;

        }
    }
}
