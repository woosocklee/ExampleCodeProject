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

    // UniTask 관련
    CancellationTokenSource cts;

    public void ReloadData(bool isReset = false)
    {
        if(isReset) // 완전히 처음부터 리셋시키는 경우.
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

        if (CellData.Count > Cells.Count) // 데이터를 수용할 셀이 부족한 경우
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
            await UniTask.DelayFrame(1, cancellationToken: cts.Token); // 1프레임에 1개의 오브젝트만 생성하게. 로딩 시간을 줄이는 용도.
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
