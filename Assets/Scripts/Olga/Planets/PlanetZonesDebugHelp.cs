using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlanetZonesDebugHelp : MonoBehaviour
{
    MeshRenderer meshRenderer;
    SphereCollider collider;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        collider = GetComponent<SphereCollider>();
    }

    private void Start()
    {
        meshRenderer.enabled = false;
    }
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
      //  Gizmos.DrawSphere(transform.position, collider.radius);
        Gizmos.DrawSphere(transform.position, 9f);
    }
}
