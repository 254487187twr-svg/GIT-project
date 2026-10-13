using UnityEngine;

/// <summary>Moves a CharacterController with the project's Horizontal and Vertical input axes.</summary>
[RequireComponent(typeof(CharacterController))]
public sealed class PlayerController : MonoBehaviour
{
    [SerializeField, Min(0f)] private float moveSpeed = 5f;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var direction = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0f,
            Input.GetAxisRaw("Vertical"));

        if (direction.sqrMagnitude > 1f)
        {
            direction.Normalize();
        }

        characterController.Move(direction * moveSpeed * Time.deltaTime);
    }
}