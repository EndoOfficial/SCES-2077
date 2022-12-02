using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject _camera;
    public Text actionButtonPrompt;

    public float raycastRange;
    public Vector3 Player;

    private Collectables coll;

    private bool raycheck;

    public string minutes;
    public string seconds;

    private float time;
    private Animator anim;


    public MouseLook mouseLook;

    public bool pressedEOnCollectable = false;
    public bool pressedEOnNPC = false;

    public GameObject Panel;
    private void Start()
    {
        Panel = GameObject.Find("ImageOfText");
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
                actionButtonPrompt.gameObject.SetActive(true); // press E text
                var sceneLoader = hitinfo.transform.GetComponent<SceneLoader>();
                if (Input.GetKeyDown(KeyCode.E) && !pressedEOnNPC)
                {
                    pressedEOnNPC = true;
                    actionButtonPrompt.gameObject.SetActive(false);          
                    if (Panel != null)
                    {
                        Panel.SetActive(true);
                    }
                }

                else if (pressedEOnNPC)
                {
                    actionButtonPrompt.gameObject.SetActive(false);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        DisableTextPannel();
                        StartCoroutine(LoadScene(sceneLoader, hitinfo));
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
                pressedEOnNPC = false;
                if (coll != null)
                    coll.DisableCollect();
                if (Panel != null)
                {
                    Panel.SetActive(false);
                }
            }
        }

        else
        {
            actionButtonPrompt.gameObject.SetActive(false);
            pressedEOnCollectable = false;
            pressedEOnNPC = false;
            if (coll != null)
                coll.DisableCollect();
        }
    }

    private IEnumerator LoadScene(SceneLoader sceneLoader, RaycastHit hitinfo)
    {
        StartCoroutine(LookAtPlayer(hitinfo));
        GetComponent<Gun>().anim.SetTrigger("JackIn");
        yield return new WaitForSeconds(1.5f);
        sceneLoader.LoadScene();
    }

    private IEnumerator LookAtPlayer(RaycastHit hitinfo)
    {
        while (true)
        {
            GameObject.Find("Head").GetComponent<HeadBobController>().enabled = false;
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
            mouseLook.enabled = false;
            _camera.transform.LookAt(hitinfo.transform.position);
            yield return null;
        }
    }
    private void DisableTextPannel()
    {
        actionButtonPrompt.gameObject.SetActive(false);
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }

}