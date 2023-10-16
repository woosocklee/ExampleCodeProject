using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���ҽ� �Ŵ����Դϴ�. Init�Լ����� ���ҽ� ������ �ִ� ���ϵ��� �̸��� ������� �����͸� ��ųʸ��� �����մϴ�.
public class ResourceManager : ManagerBase
{
    #region Singleton

    private static ResourceManager instance;
    public static ResourceManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (ResourceManager)FindObjectOfType(typeof(ResourceManager));
            }

            if (instance == null)
            {
                GameObject newObject = new();
                instance = newObject.AddComponent<ResourceManager>();
            }

            return instance;
        }
    }
    #endregion

    public Dictionary<string, AudioClip> BGMs = new();
    public Dictionary<string, AudioClip> SFXs = new();
    public Dictionary<string, GameObject> InGameObjects = new();
    public Dictionary<string, GameObject> UIs = new();
    public Dictionary<string, TextAsset> Data = new();


    public override IEnumerator Initialize()
    {
        AudioClip[] bgms = Resources.LoadAll<AudioClip>("" /* BGM Ŭ���� ����� ������ */);

        foreach(var bgm in bgms)
        {
            BGMs.Add(bgm.name, bgm);
        }

        AudioClip[] sfxs = Resources.LoadAll<AudioClip>("" /* SFX Ŭ���� ����� ������ */);

        foreach (var sfx in sfxs)
        {
            SFXs.Add(sfx.name, sfx);
        }

        GameObject[] inGameObjects = Resources.LoadAll<GameObject>("" /* �ΰ��ӿ� ���� ������Ʈ���� ����� ������ */);

        foreach (var inGameObject in inGameObjects)
        {
            InGameObjects.Add(inGameObject.name, inGameObject);
        }

        GameObject[] UIObjects = Resources.LoadAll<GameObject>("" /* UI���� ����� ������ */);

        foreach(var UIObject in UIObjects)
        {
            UIs.Add(UIObject.name, UIObject);
        }

        TextAsset[] LoadingData = Resources.LoadAll<TextAsset>("" /* CSV����ȭ�� �����͵��� ����� ������ */);

        foreach(var data in LoadingData)
        {
            Data.Add(data.name, data);
        }

        yield return base.Initialize();

    }

}
