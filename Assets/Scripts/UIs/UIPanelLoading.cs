using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//UIBase 클래스를 어떻게 상속하여 사용하는지 간단한 수도코드로 예제를 만들었습니다.
public class UIPanelLoading : UIBase
{
    Image LoadingImage;
    Text LoadingText;

    UnityEvent OnLoadingEndEvent;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void StartUI()
    {
        base.StartUI();
        //이벤트 리스너를 추가합니다. 만약 버튼이 있었다면, 버튼의 이벤트를 넣어도 됩니다.
        OnLoadingEndEvent.AddListener(OnLoadingEnded);

        //유의미한 로딩 이미지, 텍스트 등을 설정합니다. 리소스 매니저에서 호출해온다던가, CSV 파일에서 텍스트를 읽어오는 식으로 작성하게 됩니다.
        SetUpImage();
        SetUpText();
    }

    public override void EndUI()
    {
        OnLoadingEndEvent.RemoveAllListeners();
        base.EndUI();
    }

    public override void DestroyUI()
    {
        base.DestroyUI();
    }

    //이 단의 코드는 특정한 이벤트에서 어떤 일이 일어날지 작성합니다. 상세한 로직은 가급적 하단의 Core 단에서 작성됩니다.
    #region EventFuncs

    public void OnLoadingEnded()
    {
        EndUI();
    }

    public void SetUpImage()
    {
        LoadingImage.sprite = null;
    }

    public void SetUpText()
    {
        LoadingText.text = "Hello";
    }

    #endregion

    //복잡한 로직이 주로 작성되는 코어 단입니다. 예를 들어서, 로딩 이미지를 리소스에서 랜덤하게 가져오거나, CSV데이터에 있는 툴팁을 현재 설정된 언어에 따라 받아오는 등이 있겠습니다.
    #region Core



    #endregion



}
