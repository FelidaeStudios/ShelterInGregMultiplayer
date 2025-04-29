using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class Ground : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    public Transform location;
    public GameObject player;

    private GameObject turret;

    //private Renderer rend;
    private Color startColor;

    //public ActionBasedController controller;
    public InputActionReference placementAction;
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor;

    BuildManager buildManager;

    private List<GameObject> turrets = new List<GameObject>();

    void Start()
    {
        //rend = GetComponent<Renderer>();
        //startColor = rend.material.color;
        rayInteractor = FindObjectOfType<UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor>();

        buildManager = BuildManager.instance;

        /*if (rayInteractor != null)
        {
            rayInteractor.hoverEntered.AddListener(OnHoverEnter);
            rayInteractor.hoverExited.AddListener(OnHoverExit);
        }*/

        if (placementAction != null)
        {
            Debug.Log("button pressed 1");
            placementAction.action.Enable();
            placementAction.action.performed += OnButtonDown;
            Debug.Log("button pressed 2");
        }

        
    }

    void OnButtonDown(InputAction.CallbackContext context)
    {
        

        /*if (buildManager.GetTurretToBuild() == null)
        {
            Debug.Log("No build manager found");
            return;
        }*/

        if (rayInteractor != null && rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            Debug.Log("Raycast hit something: " + hit.collider.gameObject.name);

            if (hit.collider.CompareTag("Ground"))
            {
                GameObject turretToBuild = buildManager.GetTurretToBuild();
                GameObject newTurret = Instantiate(turretToBuild, hit.point + positionOffset, Quaternion.identity);
                turrets.Add(newTurret);
                Debug.Log("Turret placed at: " + (hit.point + positionOffset));
            }

            else if (hit.collider.CompareTag("Teleport"))
            {
                player.transform.position = location.transform.position;
                player.transform.rotation = location.transform.rotation;
                player.transform.localScale = location.transform.localScale;
            }
        }

        else
        {
            Debug.Log("Raycast did not hit");
        }

        //GameObject turretToBuild = buildManager.GetTurretToBuild();
        //turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    /*private void OnHoverEnter(HoverEnterEventArgs args) //Changes color if highlighted and eligible -> Move to pointer icon script?
    {
        if (buildManager.GetTurretToBuild() != null)
        {
            rend.material.color = hoverColor;
        }

    }

    private void OnHoverExit(HoverExitEventArgs args)
    {
        rend.material.color = startColor;
    }*/
}
