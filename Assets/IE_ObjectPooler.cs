using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class IE_ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public GameObject[] multiplePoolObjects;
    public int pooledAmount = 20;
    public bool willGrow = true;
    public bool b_MultiplePool;
    public bool b_BasedOnChance;
    [RangeAttribute(0.0f, 1.0f)] public float[] f_Chances;
    public HideFlags _HideFlags;

    public List<GameObject> pooledObjects;
    public List<List<GameObject>> multiplePooledObjectList = new List<List<GameObject>>();

    void Awake()
    {
        if (b_MultiplePool && b_BasedOnChance)
        {
            if (f_Chances.Length != multiplePoolObjects.Length)
                Debug.LogError("Array sizes don't fit! Bitch!");

            for (int i = 0; i < multiplePoolObjects.Length; i++)
            {
                if (i != 0)
                {
                    if (f_Chances[i] > f_Chances[i - 1])
                        Debug.LogError("Objects are not ordered correctly for chances biatch!");
                }
            }
        }

        pooledObjects = new List<GameObject>();
        if (!b_MultiplePool)
        {
            for (int i = 0; i < pooledAmount; i++)
            {
                GameObject obj = (GameObject)Instantiate(pooledObject);
                obj.hideFlags = _HideFlags;
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
        else
        {
            for (int i = 0; i < multiplePoolObjects.Length; i++)
            {
                List<GameObject> multiplePool = new List<GameObject>();
                for (int k = 0; k < pooledAmount; k++)
                {
                    GameObject obj = (GameObject)Instantiate(multiplePoolObjects[i]);
                    obj.hideFlags = _HideFlags;
                    obj.SetActive(false);
                    multiplePool.Add(obj);
                }

                multiplePooledObjectList.Add(multiplePool);
            }
        }


    }


    public GameObject GetPooledObject()
    {
        if (!b_MultiplePool)
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (pooledObjects[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(pooledObject);
                    obj.SetActive(false);
                    obj.hideFlags = _HideFlags;
                    pooledObjects[i] = obj;
                    return pooledObjects[i];
                }
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            if (willGrow)
            {
                GameObject obj = (GameObject)Instantiate(pooledObject);
                obj.hideFlags = _HideFlags;
                pooledObjects.Add(obj);
                return obj;
            }
        }
        else
        {
            if (!b_BasedOnChance)
            {
                int random = Random.Range(0, multiplePooledObjectList.Count);

                for (int i = 0; i < multiplePooledObjectList[random].Count; i++)
                {
                    if (multiplePooledObjectList[random][i] == null)
                    {
                        GameObject obj = (GameObject)Instantiate(multiplePoolObjects[random]);
                        obj.SetActive(false);
                        obj.hideFlags = _HideFlags;
                        multiplePooledObjectList[random][i] = obj;
                        return multiplePooledObjectList[random][i];
                    }
                    if (!multiplePooledObjectList[random][i].activeInHierarchy)
                    {
                        return multiplePooledObjectList[random][i];
                    }
                }

                if (willGrow)
                {
                    GameObject obj = (GameObject)Instantiate(multiplePoolObjects[random]);
                    obj.hideFlags = _HideFlags;
                    multiplePooledObjectList[random].Add(obj);
                    return obj;
                }

            }
            else
            {
                float random = Random.Range(0.0f, 1.0f);
                int index = -1;

                for (int i = 0; i < f_Chances.Length; i++)
                {
                    if (random < f_Chances[i])
                    {
                        index = i;
                        break;
                    }
                    else
                        random -= f_Chances[i];
                }

                if (index == -1)
                    index = Random.Range(0, multiplePooledObjectList.Count);
                for (int i = 0; i < multiplePooledObjectList[index].Count; i++)
                {
                    if (multiplePooledObjectList[index][i] == null)
                    {
                        GameObject obj = (GameObject)Instantiate(multiplePoolObjects[index]);
                        obj.SetActive(false);
                        obj.hideFlags = _HideFlags;
                        multiplePooledObjectList[index][i] = obj;
                        return multiplePooledObjectList[index][i];
                    }
                    if (!multiplePooledObjectList[index][i].activeInHierarchy)
                    {
                        return multiplePooledObjectList[index][i];
                    }
                }
                if (willGrow)
                {
                    GameObject obj = (GameObject)Instantiate(multiplePoolObjects[index]);
                    obj.hideFlags = _HideFlags;
                    multiplePooledObjectList[index].Add(obj);
                    return obj;
                }

            }

        }
        return null;
    }

}