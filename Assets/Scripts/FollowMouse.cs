using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] public LineRenderer laserLine;
    [SerializeField] public GameObject origin;

    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manger").GetComponent<GameManager>();

        HideCursor();
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.MousePosition();
        Laser();
        RotateToMouseDirection();
    }

    void HideCursor()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

   
    void Laser()
    {
        laserLine.SetPosition(0, origin.transform.position);

        laserLine.SetPosition(1, gameManager.mousePosition);
    }

    void RotateToMouseDirection()
    {
        Vector3 direction = gameManager.mousePosition - gameObject.transform.position;
        float angleRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg-90;

        gameObject.transform.rotation = Quaternion.Euler(0,0,angleRotation);
    }
}
