using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleFilterSystem : FilterSystem<SampleFilterSystem.SampleEnum>
{
    public enum SampleEnum
    {
        Warrior,
        Mage,
        Archer
    }

    [SerializeField]
    TMPro.TMP_Text SampleText;

    private void Start()
    {
        onValueChangedAction = UpdateData;
        UpdateData(default);
    }

    public void UpdateData(SampleEnum sampleEnum)
    {
        string currentEnumString = "";
        foreach (var sample in SelectedEnums)
        {
            currentEnumString += sample.ToString() + ", ";
        }

        SampleText.text = currentEnumString;
    }
}
