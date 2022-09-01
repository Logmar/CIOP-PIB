using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public bool moveObject;
    [SerializeField] public GameObject panelSzafy1;
    [SerializeField] public GameObject panelSzafy2;
    [SerializeField] public GameObject panelSzafy3;

    public Vector3 mousePosition;

    public void MousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
    }

    public void PanelMenuSzafy1()
    {
        if (moveObject)
        {
            panelSzafy1.SetActive(false);
        }
    }
    
    public void PanelMenuSzafy2()
    {
        if (moveObject)
        {
            panelSzafy2.SetActive(false);
        }
    }
    
    public void PanelMenuSzafy3()
    {
        if (moveObject)
        {
            panelSzafy3.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
