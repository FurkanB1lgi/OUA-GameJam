using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CMCam
{
    CMMainPlayer,
    CMAllPasssive 
}

public class CameraManager : MonoBehaviour
{
    public CMCam cMCamEnum;

    public List<GameObject> CamList = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("CamControl", .1f, .1f);
    }


    public void CamControl()
    {
        switch (cMCamEnum)
        {
            case CMCam.CMAllPasssive:
                CamUpdate(null);
                break;

            default:
                CamUpdate(CamList[(int)cMCamEnum]);
                break;
        }
    }

    public void CamUpdate(GameObject activeCam)
    {
        for (int i = 0; i < CamList.Count; i++)
        {
            if (CamList[i] != activeCam)
                CamList[i].SetActive(false);

            if (CamList[i] == activeCam)
                CamList[i].SetActive(true);

        }
    }

    //########################################    EVENTS    ###################################################################

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnChangeCamDefault, OnChangeCamDefault);
        EventManager.AddHandler(GameEvent.OnChangeCamSpesificTarget, OnChangeCamSpesificTarget);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnChangeCamDefault, OnChangeCamDefault);
        EventManager.RemoveHandler(GameEvent.OnChangeCamSpesificTarget, OnChangeCamSpesificTarget);
    }

    private void OnChangeCamDefault(object _newState)
    {
        CMCam newState = (CMCam)_newState;
        cMCamEnum = newState;
        CamControl();
    }


    private void OnChangeCamSpesificTarget(object _newState, object _targetCam, object _camState)
    {
        GameObject targetCam = (GameObject)_targetCam;
        bool camstate = (bool)_camState;
        CMCam newState = (CMCam)_newState;

        cMCamEnum = newState;

        targetCam.SetActive(camstate);

        CamControl();
    }

}
