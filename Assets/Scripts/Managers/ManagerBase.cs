using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//기본적인 매니저 구성을 위한 클래스입니다. 이 클래스의 자손 클래스로만 매니저들을 생성합니다.
public class ManagerBase : MonoBehaviour
{
    public bool isManagerReady = false;

    public virtual IEnumerator Initialize()
    {
        isManagerReady = true;

        yield return true;
    }

    public virtual void InitManager()
    {
        StartCoroutine(Initialize());
    }

}
