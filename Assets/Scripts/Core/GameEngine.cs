using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//게임 엔진입니다. 게임이 시작됨과 동시에, 현재 게임이 테스트 상황인지 실제 플레이인지에 따라 게임을 로딩해옵니다.
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
