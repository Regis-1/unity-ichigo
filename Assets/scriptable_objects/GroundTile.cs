using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "GroundTile", menuName = "Scriptable Objects/GroundTile")]
public class GroundTile : Tile
{
    [SerializeField]
    private float surfaceType;

    public float Surface => this.surfaceType;
}
