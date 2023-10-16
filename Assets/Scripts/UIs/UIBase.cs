using UnityEngine;

//UI�� ���� ���� Ŭ�����Դϴ�. ��� UI�� �� Ŭ������ �ڼ� Ŭ������ ���۵˴ϴ�. ���� Ŭ������ UIPanelLoading Ŭ������ �ۼ��߽��ϴ�. �������ֽñ� �ٶ��ϴ�.
public class UIBase : MonoBehaviour
{
    public virtual void Initialize()
    {
        //UI�� ���ʷ� ������ �� �ʿ��� �۾����� ó���մϴ�. Awake ��� ������Դϴ�.
    }

    public virtual void StartUI()
    {
        //UI�� Ȱ��ȭ �� �� �ʿ��� �۾����� ó���մϴ�. OnEnable�� ���� �ʴ� ������ �Ŵ������� ���� UI�� Ȱ��/��Ȱ���� �����ϱ� ���ؼ��Դϴ�.
        //�ַ� ��ư �̺�Ʈ�� �����ʸ� ���̰�, Ȱ��ȭ�Ǳ� ���� �ʿ��� �����͸� �ҷ��ɴϴ�.
        //���������� ���� ������Ʈ�� Ȱ��ȭ�Ͽ�, UI�� ������ ���ϴ�.
        gameObject.SetActive(true);
    }

    public virtual void EndUI()
    {
        //UI�� ��Ȱ��ȭ �� �� �ʿ��� �۾����� ó���մϴ�. OnDisable�� ���� �ʰ�, EndUI�� ȣ���Ͽ� ������Ʈ Ǯ���� ��Ȱ��ȭ�մϴ�.
        //�ַ� ��ư �̺�Ʈ�� ���� �����ʵ��� ��Ȱ��ȭ�մϴ�.
        ObjectPoolManager.Instance.GetUIPool(GetType().ToString()).KillObject(gameObject);
    }

    public virtual void DestroyUI()
    {
        //UI�� ������ ������ �� �ʿ��� ��ó�� ������ �� �Լ����� �����մϴ�.
    }
}

