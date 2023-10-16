using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�̱����� MonoBehaviour ������Ʈ�� ����� ���� ���˴ϴ�.
public class UnitySingleton<T> : MonoBehaviour where T: MonoBehaviour
{
    private T instance;
    public T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
            }

            if(instance == null)
            {
                instance = gameObject.AddComponent<T>();
            }

            
            return instance;
        }
    }
}
