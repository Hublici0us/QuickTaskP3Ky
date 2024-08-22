using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MrsBeanCollider : MonoBehaviour
{
    public Button endButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        endButton.gameObject.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        endButton.gameObject.SetActive(false);
    }
}
