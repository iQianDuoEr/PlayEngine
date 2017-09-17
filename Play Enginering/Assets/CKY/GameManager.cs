using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UIFrameWork;



public class GameManager : UnitySingleton<GameManager>
{
    public Camera mainCamera;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public bool CanOperate()
    {
        //if (!LevelManager.Instance.isReady())
        //    return false;
        if (UIManager.Instance.isBlackTrans)
            return false;
        return true;
    }

    public float GetVolume()
    {
        return _audioSource.volume;
    }

    public void SetVolume(float f)
    {
        _audioSource.volume = f;
    }

    void Update()
    {

    }
}
