using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject _camera;
    public Text actionButtonPrompt;

    private float raycastRange = 5;
    public Vector3 Player;

    private Collectables coll;

    private bool raycheck;

    public string minutes;
    public string seconds;

    private float time;
    private Animator anim;

    public bool pressedEOnCollectable = false;
    private void Start()
    {
    }
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

            /*if (Input.anyKey && pressedEOnCollectable == true)
            {
                actionButtonPrompt.gameObject.SetActive(false);
                coll.DisableCollect();
            }*/

            if (hitinfo.transform.CompareTag("NPC"))
            {
                var sceneLoader = hitinfo.transform.GetComponent<SceneLoader>();
                if (sceneLoader != null)
                {
                    actionButtonPrompt.gameObject.SetActive(true); // press E text
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //GameObject.Find("Player").SendMessage("Finnnish");
                        sceneLoader.LoadScene();
                        //minutes = GetComponent<Timer>().minutes;
                        //seconds = GetComponent<Timer>().seconds;
                        //GameEvents.OnSaveTimer?.Invoke(GameObject.Find("TimerText"));
                    }
                }
            }

            else if (hitinfo.transform.CompareTag("Collectable")) //if your looking at a collectable
            {
                actionButtonPrompt.gameObject.SetActive(true); // press E text
                coll = hitinfo.transform.GetComponent<Collectables>();
                if (Input.GetKeyDown(KeyCode.E) && !pressedEOnCollectable)
                {
                    pressedEOnCollectable = true;
                    actionButtonPrompt.gameObject.SetActive(false);
                    coll.PresentCollect();
                }
                else if (pressedEOnCollectable)
                {
                    actionButtonPrompt.gameObject.SetActive(false);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        coll.DisableCollect();
                        pressedEOnCollectable = false;
                    }
                }
            }
            else
            {
                actionButtonPrompt.gameObject.SetActive(false);
                pressedEOnCollectable = false;
                if (coll != null)
                    coll.DisableCollect();
            }
        }
        else
        {
            actionButtonPrompt.gameObject.SetActive(false);
            pressedEOnCollectable = false;
            if (coll != null)
                coll.DisableCollect();
        }
    }

    private IEnumerator LoadScene(SceneLoader sceneLoader)
    {
        GetComponent<Gun>().anim.SetTrigger("JackIn");
        yield return new WaitForSeconds(1.5f);
        sceneLoader.LoadScene();
    }
}