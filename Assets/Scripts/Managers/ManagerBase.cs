using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�⺻���� �Ŵ��� ������ ���� Ŭ�����Դϴ�. �� Ŭ������ �ڼ� Ŭ�����θ� �Ŵ������� �����մϴ�.
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
