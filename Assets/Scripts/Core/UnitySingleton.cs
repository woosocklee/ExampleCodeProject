using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//싱글턴한 MonoBehaviour 오브젝트를 만들기 위해 사용됩니다.
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
