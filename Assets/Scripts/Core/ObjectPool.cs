using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������Ʈ Ǯ�Դϴ�. Ǯ�� ���� ������Ʈ�� �����մϴ�.
//������Ʈ�� ����, Ȱ��ȭ, ��Ȱ��ȭ ���� ����մϴ�. ������Ʈ Ǯ �Ŵ����� ���� ������Ʈ Ǯ�� ������ �� �ֽ��ϴ�.
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