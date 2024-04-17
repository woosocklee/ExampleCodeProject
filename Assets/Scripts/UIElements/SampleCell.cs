using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleCell : UIDataCell<SampleData>
{

    TMPro.TextMeshPro Sampletext;
    public override void UpdateCell(SampleData data)
    {
        currentData = data;
        Sampletext.text = currentData.sampleInt.ToString() + ", " + currentData.sampleString;
    }
}

public struct SampleData
{
    public int sampleInt;
    public string sampleString;
}
