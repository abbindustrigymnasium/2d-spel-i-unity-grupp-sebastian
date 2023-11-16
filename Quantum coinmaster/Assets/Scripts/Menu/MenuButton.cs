using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{

    public Button myButton;

    public Button ContinueButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            myButton.onClick.Invoke();
        }

        if (Input.GetKey(KeyCode.Return))
        {
            ContinueButton.onClick.Invoke();
        }
    }


}
