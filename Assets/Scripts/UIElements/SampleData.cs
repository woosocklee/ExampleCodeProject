using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleCell : UIDataCell<SampleData>
{
    TMPro.TextMeshPro Sampletext;
}


public class SampleData : ILoadData
{
    public void LoadData()
    {
        throw new System.NotImplementedException();
    }
}