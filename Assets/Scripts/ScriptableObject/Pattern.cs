using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Шаблон комбинации")]
public class Pattern : ScriptableObject
{
    [SerializeField] private Result _positiveResult;
    [SerializeField] private Result _negativeResult;
    [SerializeField] private List<Pattern> _list;

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
    public Pattern GetPattern()
    {
        return _list[Random.Range(0, _list.Count)];
    }
}
