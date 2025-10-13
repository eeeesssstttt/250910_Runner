using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game Design/CameraData")]
public class CameraData : ScriptableObject
{
    [field: SerializeField] public float Decal { get; private set; } = -3f;
}
