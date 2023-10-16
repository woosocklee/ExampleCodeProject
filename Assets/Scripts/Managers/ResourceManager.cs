using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//리소스 매니저입니다. Init함수에서 리소스 폴더에 있는 파일들의 이름을 기반으로 데이터를 딕셔너리에 저장합니다.
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
        AudioClip[] bgms = Resources.LoadAll<AudioClip>("" /* BGM 클립이 저장된 폴더명 */);

        foreach(var bgm in bgms)
        {
            BGMs.Add(bgm.name, bgm);
        }

        AudioClip[] sfxs = Resources.LoadAll<AudioClip>("" /* SFX 클립이 저장된 폴더명 */);

        foreach (var sfx in sfxs)
        {
            SFXs.Add(sfx.name, sfx);
        }

        GameObject[] inGameObjects = Resources.LoadAll<GameObject>("" /* 인게임에 사용될 오브젝트들이 저장된 폴더명 */);

        foreach (var inGameObject in inGameObjects)
        {
            InGameObjects.Add(inGameObject.name, inGameObject);
        }

        GameObject[] UIObjects = Resources.LoadAll<GameObject>("" /* UI들이 저장된 폴더명 */);

        foreach(var UIObject in UIObjects)
        {
            UIs.Add(UIObject.name, UIObject);
        }

        TextAsset[] LoadingData = Resources.LoadAll<TextAsset>("" /* CSV파일화된 데이터들이 저장된 폴더명 */);

        foreach(var data in LoadingData)
        {
            Data.Add(data.name, data);
        }

        yield return base.Initialize();

    }

}
