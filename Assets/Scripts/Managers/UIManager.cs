using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI���� �����ϴ� UI�Ŵ����Դϴ�. UI�� ����, ����, ��ȯ, Ȱ��ȭ, ��Ȱ��ȭ ���� �ý��ϴ�.
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


    //Ư�� UI�� ������Ʈ Ǯ �Ŵ����� ���� ������ �Լ��Դϴ�. UI�� �̸��� �Ű������� �޽��ϴ�.
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

    //UI�� Ȱ��ȭ�մϴ�. ���� UI�� �̸� �����Ǿ� ���� �ʴٸ�, GetUI�� ���� UI�� ������ �� Ȱ��ȭ�մϴ�.
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

    //UI�� ��Ȱ��ȭ �մϴ�. ��Ȱ��ȭ�� ������Ʈ Ǯ �Ŵ����� ���� �����մϴ�.
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
