using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class PlayerBehaviour : MonoBehaviour {

    // Player Atributes
    public float playerSpeed;
    public float playerJumpSpeed;

    // References
    private PlayerController playerController;

    void Start ()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update ()
    {
        // Chama o Metodo de Movimentacao
        playerController.MovementInput(playerSpeed);
        // Chama o Metodo de Pular
        playerController.JumpInput(playerJumpSpeed);
        // Chama o Metodo de Atacar
        playerController.MouseInput();
        // Chama o Metodo de Recarregar
        playerController.ReloadInput();
    }

}
