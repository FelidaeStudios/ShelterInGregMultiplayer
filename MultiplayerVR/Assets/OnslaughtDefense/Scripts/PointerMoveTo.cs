using System.Collections;
using UnityEngine;


public class PointerMoveTo : MonoBehaviour
{
    public GameObject ground;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor;

    void Update()
    {
        if (rayInteractor == null)
        {
            return;
        }

        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if (hit.collider.gameObject == ground)
            {
                transform.position = hit.point;
            }
        }
    }
}
