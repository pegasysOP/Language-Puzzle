using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private const string interactable_tag = "Interactable";

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Interaction")]
    [SerializeField] private float interactRange = 1.0f;
    [SerializeField] private float interactCooldown = 0.5f;
    [SerializeField] private bool showInteractGizmo = false;

    private float xInput;
    private float zInput;
    private bool interactInput;
    private bool lexiconInput;

    private bool interacting = false;
    private Coroutine interactCooldownCoroutine;


    private void Update()
    {
        // movement
        xInput = Input.GetAxis("xAxis");
        zInput = Input.GetAxis("zAxis");
        Move();


        // interact
        interactInput = Input.GetAxis("Interact") > 0.1f;
        if (interactInput)
            Interact();


        // lexicon
        lexiconInput = Input.GetAxis("Lexicon") > 0.1f;
        if (lexiconInput)
            Lexicon();
    }

    private void Move()
    {
        rb.velocity = new Vector3(xInput, 0f, zInput).normalized * moveSpeed;
    }

    private void Interact()
    {
        if (!interacting)
        {
            interacting = true;

            RaycastHit[] hits = Physics.SphereCastAll(transform.position, interactRange, Vector3.up, LayerMask.GetMask(new string[] { interactable_tag }));
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.tag != interactable_tag)
                    continue;

                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable == null)
                    continue;

                if (!interactable.CanInteract())
                    continue;

                if (interactable.Interact())
                {
                    // successful interaction
                    BeginInteractCooldown();
                    return;
                }
                else
                {
                    // interact failed
                    BeginInteractCooldown();
                    return;
                }
            }

            // nothing to interact with
            BeginInteractCooldown();
        }
    }

    private void Lexicon()
    {
        throw new System.NotImplementedException("Lexicon is not yet implemented");
    }

    private void BeginInteractCooldown()
    {
        if (interactCooldownCoroutine != null)
            StopCoroutine(interactCooldownCoroutine);
        interactCooldownCoroutine = StartCoroutine(InteractCooldownCoroutine());
    }

    private IEnumerator InteractCooldownCoroutine()
    {
        yield return new WaitForSeconds(interactCooldown);
        interacting = false;
    }

    private void OnDrawGizmos()
    {
        if (showInteractGizmo)
        {
            Gizmos.color = new Color(0f, 0.75f, 0f, 0.75f);
            Gizmos.DrawSphere(transform.position, interactRange);
        }
    }
}
