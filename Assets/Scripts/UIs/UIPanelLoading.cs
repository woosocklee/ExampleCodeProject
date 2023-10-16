using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//UIBase Ŭ������ ��� ����Ͽ� ����ϴ��� ������ �����ڵ�� ������ ��������ϴ�.
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
        //�̺�Ʈ �����ʸ� �߰��մϴ�. ���� ��ư�� �־��ٸ�, ��ư�� �̺�Ʈ�� �־ �˴ϴ�.
        OnLoadingEndEvent.AddListener(OnLoadingEnded);

        //���ǹ��� �ε� �̹���, �ؽ�Ʈ ���� �����մϴ�. ���ҽ� �Ŵ������� ȣ���ؿ´ٴ���, CSV ���Ͽ��� �ؽ�Ʈ�� �о���� ������ �ۼ��ϰ� �˴ϴ�.
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

    //�� ���� �ڵ�� Ư���� �̺�Ʈ���� � ���� �Ͼ�� �ۼ��մϴ�. ���� ������ ������ �ϴ��� Core �ܿ��� �ۼ��˴ϴ�.
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

    //������ ������ �ַ� �ۼ��Ǵ� �ھ� ���Դϴ�. ���� ��, �ε� �̹����� ���ҽ����� �����ϰ� �������ų�, CSV�����Ϳ� �ִ� ������ ���� ������ �� ���� �޾ƿ��� ���� �ְڽ��ϴ�.
    #region Core



    #endregion



}
