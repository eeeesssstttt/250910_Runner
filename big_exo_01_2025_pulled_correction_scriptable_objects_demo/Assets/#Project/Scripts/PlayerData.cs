using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game Design/PlayerData")]
public class PlayerData : ScriptableObject
{
    [field: SerializeField] public float Speed { get; private set; } = 10f;
    [field: SerializeField] public float JumpForce { get; private set; } = 300f;
}
