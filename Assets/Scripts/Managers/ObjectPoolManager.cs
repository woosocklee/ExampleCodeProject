using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ObjectPool���� �����ϴ� �Ŵ����Դϴ�. �Ϲ����� ������Ʈ�� UI�� ���� �����ϴµ�, UI�� ��� ������ enum�� ���� Ŭ������ �ĺ��ϴ� ������ ����ϰ� �ֽ��ϴ�.
//������Ʈ�� �̸��� ���ؼ� ������Ʈ Ǯ�� ���õ� ����(����, ����, ��ȯ ��)�� �����մϴ�.

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