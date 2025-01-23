using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchMusic : MonoBehaviour
{
    SwitchController switchController;
    public int trackIndex;
    // Start is called before the first frame update
    void Start()
    {
        switchController = GetComponent<SwitchController>();
        GameObject mainCamera = GameManager.Instance.mainCamera;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ValueChanged()
    {
        GameManager.Instance.musicManager.SetTrackMute(trackIndex, !switchController.isOn);
    }
}
