using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private PlayerControl playerControl;
    private float forwardSpeed;
    private float lateralSpeed;
    private float jumpSpeed;


    public void Initialize(GameObject player, PlayerControl playerControl, float forwardSpeed, float lateralSpeed, float jumpSpeed)
    {
        this.player = player;
        this.playerControl = playerControl;
        this.forwardSpeed = forwardSpeed;
        this.lateralSpeed = lateralSpeed;
        this.jumpSpeed = jumpSpeed;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        player.transform.position += lateralSpeed * Time.deltaTime * playerControl.XAxis() * transform.right;
        player.transform.position += forwardSpeed * Time.deltaTime * transform.forward;
        if (playerControl.Jump() == true)
        {
            transform.position += Vector3.up * jumpSpeed * Time.deltaTime;
        }
    }

}
