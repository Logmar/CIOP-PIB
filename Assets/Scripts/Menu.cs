using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    Animator animator;

    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GameObject.Find("Content").GetComponent<Animator>();

        gameManager = GameObject.Find("Game Manger").GetComponent<GameManager>();
    }

    public void Ubrania()
    {
        Invoke("UbraniaDelay", 0.5f);
    }
    
    public void UbraniaDelay()
    {
        animator.Play("Ubrania Animation");
    }

    public void UbraniaOnExit()
    {
        if (!gameManager.moveObject)
        {
            animator.Play("Ubrania Animation back");
            gameManager.panelSzafy1.SetActive(false);
        }
    }
    
    public void SrodkiOchrony()
    {
        Invoke("SrodkiOchronyDelay", 0.5f);
    }
    
    public void SrodkiOchronyDelay()
    {
        animator.Play("Srodki ochrony Animation");
    }

    public void SrodkiOchronyOnExit()
    {
        if (!gameManager.moveObject)
        {
            animator.Play("Srodki ochrony Animation back");
            gameManager.panelSzafy2.SetActive(false);
        }
    }
    
    public void SprzetDoDzialania()
    {
        Invoke("SprzetDoDzialaniaDelay", 0.5f);
    }
    
    public void SprzetDoDzialaniaDelay()
    {
        animator.Play("Sprzet do dzialania Animation");
    }

    public void SprzetDoDzialaniaOnExit()
    {
        if (!gameManager.moveObject)
        {
            animator.Play("Sprzet do dzialania Animation back");
            gameManager.panelSzafy3.SetActive(false);
        }
    }
}
