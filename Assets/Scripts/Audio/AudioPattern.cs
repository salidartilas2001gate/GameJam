using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioPattern")]
public class AudioPattern : ScriptableObject
{
    [SerializeField] private int _lenght;
    [SerializeField] private int[] _intervals;

    [SerializeField] private List<AudioPattern> _tags;

    public AudioPattern getTags()
    {
        return _tags[Random.Range(0, _tags.Count)];
    }

    public int getLenght()
    {
        return _lenght;
    }

    public int[] getIntervals()
    {
        return _intervals;
    }
}
