using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI들을 관리하는 UI매니저입니다. UI의 생성, 삭제, 반환, 활성화, 비활성화 등을 맡습니다.
public class UIManager : ManagerBase
{
    #region Singleton

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (UIManager)FindObjectOfType(typeof(UIManager));
            }

            if (instance == null)
            {
                GameObject newObject = new();
                instance = newObject.AddComponent<UIManager>();
            }

            return instance;
        }
    }
    #endregion

    public Dictionary<E_UI_NAME,UIBase> CurrentUIs;
    public Transform FinalUI;

    public override IEnumerator Initialize()
    {
        FinalUI = transform;

        yield return base.Initialize();
    }


    //특정 UI를 오브젝트 풀 매니저를 통해 얻어오는 함수입니다. UI의 이름을 매개변수로 받습니다.
    public UIBase GetUI(string UIName)
    {
        GameObject UIObject = ObjectPoolManager.Instance.GetUIPool(UIName).Get();
        UIBase newUI = UIObject.GetComponent<UIBase>();

        if(newUI != null)
        {
            newUI.Initialize();
            return newUI;
        }
        else
        {
            Debug.LogError("There's no such UI! Can't GetUI: " + UIName);
            return null;
        }
    }

    //UI를 활성화합니다. 만약 UI가 미리 생성되어 있지 않다면, GetUI를 통해 UI를 생성한 후 활성화합니다.
    public void ActivateUI(string UIName)
    {
        E_UI_NAME UIEnum = (E_UI_NAME)Enum.Parse(typeof(E_UI_NAME), UIName);
        CurrentUIs.TryGetValue(UIEnum, out var targetUI);
        if (targetUI == null)
        {
            targetUI = GetUI(UIName);
            if(targetUI == null)
            {
                Debug.LogError("There's no such UI! Can't ActivateUI: " + UIName);
                return;
            }
        }

        targetUI.transform.parent = FinalUI;
        FinalUI = targetUI.transform;
        targetUI.StartUI();
    }

    //UI를 비활성화 합니다. 비활성화는 오브젝트 풀 매니저를 통해 진행합니다.
    public void DeactivateUI(string UIName)
    {
        E_UI_NAME UIEnum = (E_UI_NAME)Enum.Parse(typeof(E_UI_NAME), UIName);
        CurrentUIs.TryGetValue(UIEnum, out var targetUI);
        if (targetUI == null)
        {
            Debug.LogError("There's no such UI!: " + UIName);
            return;
        }

        FinalUI = targetUI.transform.parent;
        targetUI.EndUI();
        
    }
}
