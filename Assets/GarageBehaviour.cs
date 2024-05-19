using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Unity MonoBehaviour for handling the behaviour of opening and closing the portal.
/// </summary>
public class GarageBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    
    [SerializeField]
    private OcclusionPortal portal;
    
    private bool isPortalOpen = false;

    private bool doorOpen = true;

    private bool playerInRange = false;
    private bool meshColliderActive = true;
    private Renderer renderer;
    private MeshCollider meshCollider;

    [SerializeField] 
    private GameObject uiComponent;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        meshCollider = GetComponent<MeshCollider>();
    }

    void Update()
    {
        // Check if the player is in range and the "E" key is pressed
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            doorOpen = !doorOpen;
            // Toggle the portal state
            renderer.enabled = doorOpen;

            meshColliderActive = !meshColliderActive;
            meshCollider.enabled = meshColliderActive;
            
            isPortalOpen = !isPortalOpen;
            portal.open = isPortalOpen;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
            uiComponent.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
            uiComponent.SetActive(false);
        }
    }
}
