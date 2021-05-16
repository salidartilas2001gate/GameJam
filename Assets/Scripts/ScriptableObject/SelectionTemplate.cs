using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Шаблон комбинации")]
public class SelectionTemplate : ScriptableObject
{
    [SerializeField] private Result _positiveResult;
    [SerializeField] private Result _negativeResult;
    [SerializeField] private List<SelectionTemplate> _list;

    public Result GetResult(bool result)
    {
        if (result)
        {
            return _positiveResult;
        }
        else
        {
            return _negativeResult;
        }
    }
    public SelectionTemplate get()
    {
        return _list[Random.Range(0, _list.Count)];
    }
}
