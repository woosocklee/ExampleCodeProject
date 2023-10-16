using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//코어입니다. 게임 엔진의 상황에 따라 호출되며, 게임상의 필수적인 매니저들을 세팅합니다. 세팅이 끝난 후 게임이 본격적으로 시작될 가능성이 높습니다.
public class Core : MonoBehaviour
{
    [SerializeField] List<ManagerBase> Managers;
    public Dictionary<string, ManagerBase> ManagerDict;


    public void Initialize()
    {
        StartCoroutine(StartSetting());
    }
    //필요한 매니저들을 Dict에 넣어주고, 각 매니저들을 활성화시킵니다.
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
