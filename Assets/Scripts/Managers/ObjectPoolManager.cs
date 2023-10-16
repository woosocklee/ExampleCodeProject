using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ObjectPool들을 관리하는 매니저입니다. 일반적인 오브젝트와 UI를 따로 관리하는데, UI의 경우 고유의 enum을 통해 클래스를 식별하는 식으로 사용하고 있습니다.
//오브젝트의 이름을 통해서 오브젝트 풀과 관련된 관리(생성, 삭제, 반환 등)을 수행합니다.

public class ObjectPoolManager : ManagerBase
{

    private static ObjectPoolManager instance;
    public static ObjectPoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (ObjectPoolManager)FindObjectOfType(typeof(ObjectPoolManager));
            }

            if (instance == null)
            {
                GameObject newObject = new();
                instance = newObject.AddComponent<ObjectPoolManager>();
            }

            return instance;
        }
    }


    Dictionary<string, ObjectPool> Pools = new();
    Dictionary<E_UI_NAME, ObjectPool> UIPools = new();

    public void CreatePool(GameObject targetGameObject)
    {
        GameObject NewPool = new();
        ObjectPool objectPool = NewPool.AddComponent<ObjectPool>();

        Pools.Add(targetGameObject.name, objectPool);
    }

    public ObjectPool GetPool(string poolName)
    {
        return Pools[poolName];
    }

    public void KillPool(string poolName)
    {
        Pools[poolName].KillObjectPool();
        Pools.Remove(poolName);
    }

    public void KillPool(GameObject targetGameObject)
    {
        Pools[targetGameObject.name].KillObjectPool();
        Pools.Remove(targetGameObject.name);
    }

    public ObjectPool GetUIPool(string UIName)
    {
        E_UI_NAME UIEnum = (E_UI_NAME)Enum.Parse(typeof(E_UI_NAME), UIName);

        return UIPools[UIEnum];
    }
}