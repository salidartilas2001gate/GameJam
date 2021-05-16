using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionAudioPattern : MonoBehaviour
{

    public AudioPattern[] _audioPatterns;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public AudioPattern GetPatternById(int id)
    {
        return _audioPatterns[id];
    }

}
