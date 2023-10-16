using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�ھ��Դϴ�. ���� ������ ��Ȳ�� ���� ȣ��Ǹ�, ���ӻ��� �ʼ����� �Ŵ������� �����մϴ�. ������ ���� �� ������ ���������� ���۵� ���ɼ��� �����ϴ�.
public class Core : MonoBehaviour
{
    [SerializeField] List<ManagerBase> Managers;
    public Dictionary<string, ManagerBase> ManagerDict;


    public void Initialize()
    {
        StartCoroutine(StartSetting());
    }
    //�ʿ��� �Ŵ������� Dict�� �־��ְ�, �� �Ŵ������� Ȱ��ȭ��ŵ�ϴ�.
    public IEnumerator StartSetting()
    {
        foreach(var manager in Managers)
        {
            StartCoroutine(manager.Initialize());
        }

        foreach (var manager in Managers)
        {
            ManagerDict.Add(manager.name, manager);
        }

        yield return new WaitUntil(CheckManagerReady);
    }

    public bool CheckManagerReady()
    {
        bool startYet = true;
        foreach (var manager in ManagerDict.Values)
        {
            if (!manager.isManagerReady)
            {
                startYet = true;
                break;
            }
            else
            {
                startYet = false;
            }
        }

        return !startYet;
    }

}
