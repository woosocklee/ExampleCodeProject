using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Threading;
public abstract class ReusableDataController<T> : MonoBehaviour
{
    [SerializeField]
    private UIDataCell<T> BaseCell;

    public List<T> CellData = new();
    public List<UIDataCell<T>> Cells = new();

    public RectTransform ContentRectTransform;

    // UniTask ����
    CancellationTokenSource cts;

    public void ReloadData(bool isReset = false)
    {
        if(isReset) // ������ ó������ ���½�Ű�� ���.
        {
            foreach(var cell in Cells)
            {
                DestroyImmediate(cell.gameObject); 
            }

            Cells.Clear();
        }

        ReuseCells();

    }

    private void ReuseCells()
    {
        for (int i = 0; i < CellData.Count; i++)
        {
            if(CellData.Count <= i)
            {
                break;
            }

            Cells[i].UpdateCell(CellData[i]);
        }

        if (CellData.Count > Cells.Count) // �����͸� ������ ���� ������ ���
        {
            CreateNewCells().Forget();
        }
        else if (CellData.Count < Cells.Count)
        {
            for(int i = CellData.Count; i < Cells.Count; i++)
            {
                Cells[i].gameObject.SetActive(false);
            }
        }

    }

    private async UniTaskVoid CreateNewCells()
    {
        if(cts == null)
        {
            cts = new();
        }

        for(int i = Cells.Count; i < CellData.Count; i++)
        {
            UIDataCell<T> newCell = Instantiate(BaseCell, ContentRectTransform) as UIDataCell<T>;
            newCell.UpdateCell(CellData[i]);
            Cells.Add(newCell);
            await UniTask.DelayFrame(1, cancellationToken: cts.Token); // 1�����ӿ� 1���� ������Ʈ�� �����ϰ�. �ε� �ð��� ���̴� �뵵.
        }

        if(cts != null)
        {
            cts.Dispose();
            cts = null;
        }
    }

}

public abstract class UIDataCell<T> : MonoBehaviour
{
    public T currentData;

    public abstract void UpdateCell(T data);

}
