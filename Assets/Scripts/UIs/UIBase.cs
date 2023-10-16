using UnityEngine;

//UI에 사용될 기초 클래스입니다. 모든 UI는 이 클래스의 자손 클래스로 제작됩니다. 예제 클래스로 UIPanelLoading 클래스를 작성했습니다. 참고해주시길 바랍니다.
public class UIBase : MonoBehaviour
{
    public virtual void Initialize()
    {
        //UI가 최초로 생성될 때 필요한 작업들을 처리합니다. Awake 대신 사용중입니다.
    }

    public virtual void StartUI()
    {
        //UI가 활성화 될 때 필요한 작업들을 처리합니다. OnEnable를 쓰지 않는 이유는 매니저에서 따로 UI의 활성/비활성을 관리하기 위해서입니다.
        //주로 버튼 이벤트에 리스너를 붙이고, 활성화되기 전에 필요한 데이터를 불러옵니다.
        //마지막으로 게임 오브젝트를 활성화하여, UI를 바탕에 띄웁니다.
        gameObject.SetActive(true);
    }

    public virtual void EndUI()
    {
        //UI가 비활성화 될 때 필요한 작업들을 처리합니다. OnDisable을 쓰지 않고, EndUI를 호출하여 오브젝트 풀에서 비활성화합니다.
        //주로 버튼 이벤트에 붙은 리스너들을 비활성화합니다.
        ObjectPoolManager.Instance.GetUIPool(GetType().ToString()).KillObject(gameObject);
    }

    public virtual void DestroyUI()
    {
        //UI를 완전히 삭제할 때 필요한 전처리 과정을 이 함수에서 진행합니다.
    }
}

