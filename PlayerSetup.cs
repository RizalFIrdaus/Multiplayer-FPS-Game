using UnityEngine.Networking;
using UnityEngine;

[System.Obsolete]
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentToDisable;

    Camera cam;

    void Start()
    {

        if (!isLocalPlayer)
        {
            DisableComponent();
        }
        else
        {
            cam = Camera.main;
            if(cam != null)
            {
                cam.gameObject.SetActive(false);
            }
        }


    }

    void DisableComponent()
    {
        for(int i = 0; i < componentToDisable.Length; i++)
        {
            componentToDisable[i].enabled = false;
        }
    }
}
