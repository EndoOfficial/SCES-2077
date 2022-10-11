using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject _camera;
    public Text actionButtonPrompt;

    public LayerMask characterLayer;


    private float raycastRange = 5;
    public Vector3 Player;

    private bool raycheck;


    private void Update()
    {
        /*
        raycast checks to see if the character has the "SceneLoader" script component, which has a public string assigned to them individually,
        this string will have the exact name of the scene that is to be loaded.
        If the raycast hits on update it activates the UI element that has the action button prompt and allow for the player to load the scene from the sceneloader script
       */

        if(raycheck = Physics.Raycast(_camera.transform.position, _camera.transform.forward , out RaycastHit hitinfo, raycastRange, characterLayer))
        {
            var sceneLoader = hitinfo.transform.GetComponent<SceneLoader>();
            if(sceneLoader != null)
            {
                actionButtonPrompt.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    sceneLoader.LoadScene();
                    Debug.Log("get loaded son");
                }
            }
            
        }
        else
        {
            actionButtonPrompt.gameObject.SetActive(false);
        }
    }
   
}
