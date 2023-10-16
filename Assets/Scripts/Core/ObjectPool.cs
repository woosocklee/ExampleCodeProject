using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//오브젝트 풀입니다. 풀에 속한 오브젝트를 관리합니다.
//오브젝트의 생성, 활성화, 비활성화 등을 담당합니다. 오브젝트 풀 매니저를 통해 오브젝트 풀에 접근할 수 있습니다.
public class ObjectPool : MonoBehaviour
{
    public GameObject BaseObject;
    private List<GameObject> Pool = new();
    private GameObject PoolParent;


    public GameObject Get()
    {
        for (int i = 0; i < Pool.Count; i++)
        {
            if (!Pool[i].activeSelf)
            {
                Pool[i].SetActive(true);
                return Pool[i];
            }
        }

        GameObject NewObject = Instantiate(BaseObject);
        Pool.Add(NewObject);
        NewObject.SetActive(true);
        return NewObject;
    }

    public void KillObject(GameObject targetObject)
    {
        if (Pool.Contains(targetObject))
        {
            targetObject.SetActive(false);

            if (PoolParent == null)
            {
                PoolParent = this.gameObject;
            }

            targetObject.transform.parent = PoolParent.transform;

        }
    }

    public List<GameObject> Spawn(int Count)
    {
        List<GameObject> SpawnedObject = new();

        for (int i = 0; i < Count; i++)
        {
            GameObject newObject = Instantiate(BaseObject);
            Pool.Add(newObject);
            SpawnedObject.Add(newObject);
        }

        return SpawnedObject;
    }

    public void ClearPool()
    {
        foreach (var Object in Pool)
        {
            DestroyImmediate(Object);
        }
        Pool.Clear();
    }

    public void KillObjectPool()
    {
        BaseObject = null;
        ClearPool();
        Pool = null;
        PoolParent = null;
        DestroyImmediate(gameObject);
    }

}