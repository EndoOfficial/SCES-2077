using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject _camera;
    public Text actionButtonPrompt;

    private float raycastRange = 10;
    public Vector3 Player;

    private Collectables call;

    private bool raycheck;  
    
    public string minutes;
    public string seconds;


    public bool PlayerMissing = true;
    // Start is called before the first frame update
    private void Update()
    {
        /*
            raycast checks to see if the character has the "SceneLoader" script component, which has a public string assigned to them individually,
            this string will have the exact name of the scene that is to be loaded.
            If the raycast hits on update it activates the UI element that has the action button prompt and allow for the player to load the scene from the sceneloader script
        */
        if (raycheck = Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hitinfo, raycastRange))
        {

            /*if (Input.anyKey && PlayerMissing == true)
            {
                actionButtonPrompt.gameObject.SetActive(false);
                call.DisableCollect();
            }*/

            if (hitinfo.transform.CompareTag("NPC"))
            {
                var sceneLoader = hitinfo.transform.GetComponent<SceneLoader>();
                if (sceneLoader != null)
                {
                    actionButtonPrompt.gameObject.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //GameObject.Find("Player").SendMessage("Finnish");
                        //minutes = GetComponent<Timer>().minutes;
                        //seconds = GetComponent<Timer>().seconds;
                        sceneLoader.LoadScene();                        
                        //GameEvents.OnSaveTimer?.Invoke(GameObject.Find("TimerText"));                        

                    }
                }
            }

            else if (hitinfo.transform.CompareTag("Collectable"))
                //if your looking at a collectable
            {
                // you are no longer missing the raycast
                if (PlayerMissing == true)
                {
                    //allowing you to stop setting PRESS E to disable
                    PlayerMissing = false;
                    actionButtonPrompt.gameObject.SetActive(true);
                    call = hitinfo.transform.GetComponent<Collectables>();
                }
               
                    
            
                if (Input.GetKeyDown(KeyCode.E))
                    {
                    //however once you press E it will disable
                    // And present the collectable 
                    call.PresentCollect();
                    actionButtonPrompt.gameObject.SetActive(false);

                }
                
            }
            

            else if (call != null)
            {              
                
                
                    actionButtonPrompt.gameObject.SetActive(false);
                    call.DisableCollect();
                    PlayerMissing = true;
                



            }

           

        }

    }
}