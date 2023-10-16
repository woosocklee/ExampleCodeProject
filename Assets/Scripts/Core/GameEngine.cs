using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �����Դϴ�. ������ ���۵ʰ� ���ÿ�, ���� ������ �׽�Ʈ ��Ȳ���� ���� �÷��������� ���� ������ �ε��ؿɴϴ�.
public class GameEngine : MonoBehaviour
{
    public Core gameCore;
    [SerializeField] bool isEngineTest;
    public void SettingStart()
    {
        if(isEngineTest)
        {
            GameEngine[] gameEngines = FindObjectsOfType<GameEngine>();

            foreach(var gameEngine in gameEngines)
            {
                if(gameEngine != this && !isEngineTest)
                {
                    DestroyImmediate(gameObject);
                    return;
                }
            }
        }

        DontDestroyOnLoad(gameObject);
        gameCore.Initialize();
    }

    private void Start()
    {
        SettingStart();
    }
}
