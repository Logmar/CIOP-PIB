using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private Vector3 originalPosition;
    private Vector3 originalScale;
    private string objectName;
    private bool isTransform;
    private GameManager gameManager;

    [SerializeField] public GameObject panelSzafy;
    [SerializeField] public GameObject avatar;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manger").GetComponent<GameManager>();

        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.MousePosition();

        if ((gameManager.moveObject == true) && (gameObject.name==objectName))
        {
            transform.position = gameManager.mousePosition;
        }
    }

    private void OnMouseDown()
    {
        objectName = gameObject.name;
        gameManager.moveObject = true;
        originalPosition = transform.position;

        transform.GetComponent<Collider>().enabled = false;
    }

    private void OnMouseUp()
    {
        gameManager.moveObject = false;
        
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = gameManager.mousePosition - rayOrigin;

        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin,rayDirection,out hitInfo))
        {
            if (hitInfo.transform.tag == "destinationTag")
            {
                transform.position = hitInfo.transform.position;
                transform.GetComponent<Collider>().enabled = true;

                isTransform = true;
                
                transform.parent = avatar.transform;
                transform.localScale = new Vector3(transform.localScale.y, transform.localScale.y, transform.localScale.z);

            }
            else
            {
                BackToOriginalPosition();
            }
        }
        else
        {
            BackToOriginalPosition();
        }

        objectName = null;
    }

    private void BackToOriginalPosition()
    {
        transform.GetComponent<Collider>().enabled = true;
        transform.position = originalPosition;

        panelSzafy.SetActive(true);
    }

    private void OnMouseOver()
    {
        if(!isTransform) transform.localScale = originalScale + new Vector3(0.1f, 0.1f, 0.1f);
    }

    private void OnMouseExit()
    {
        if (!isTransform) transform.localScale = originalScale;
    }


}
