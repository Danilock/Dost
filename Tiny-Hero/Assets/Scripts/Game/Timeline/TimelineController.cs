using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    // Start is called before the first frame update
    void Start()
    {
        if(LevelManager.Instance.IsFirstTimeInLevel){
            _director.Play();
        }
    }
}
