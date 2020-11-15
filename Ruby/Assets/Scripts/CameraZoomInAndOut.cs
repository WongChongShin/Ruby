using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraZoomInAndOut : MonoBehaviour
{

    public CinemachineFreeLook zoom;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if (zoom.m_Lens.FieldOfView <= 50)
            {
                zoom.m_Lens.FieldOfView++;
            }
            else
                zoom.m_Lens.FieldOfView = 50;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (zoom.m_Lens.FieldOfView >= 20)
                zoom.m_Lens.FieldOfView--;
            else
                zoom.m_Lens.FieldOfView = 20;
        }
    }
}
