using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UniRx;
using System.Linq;

public abstract class FilterSystem<T> : MonoBehaviour where T: Enum
{
    [SerializeField]
    List<EnumPair<T, Toggle>> ToggleList;

    protected Action<T> onValueChangedAction;
    
    UnityEvent disableEvent = new();

    private void OnEnable()
    {
        foreach (var property in ToggleList)
        {
            IDisposable propertyDisposer = property.Second.onValueChanged.AsObservable().Subscribe(x => onValueChangedAction.Invoke(property.First));
            disableEvent.AddListener(propertyDisposer.Dispose);
        }
    }

    private void OnDisable()
    {
        disableEvent.Invoke();
        disableEvent.RemoveAllListeners();
    }

    public List<T> SelectedEnums
    {
        get
        {
            var currentSelected = ToggleList.Where(x => x.Second.isOn == true);
            List<T> result = new();

            foreach(var pair in currentSelected)
            {
                result.Add(pair.First);
            }

            return result;
        }
    }
}