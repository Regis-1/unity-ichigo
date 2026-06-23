using UnityEngine;
using UnityEngine.Tilemaps;

public class FeetLogic : MonoBehaviour
{
    [SerializeField]
    private Tilemap groundTilemap;

    public int CurrentSurface { get; private set; }

    void Update()
    {
        Vector3Int cellPos = this.groundTilemap.WorldToCell(this.transform.position);

        GroundTile tile = this.groundTilemap.GetTile<GroundTile>(cellPos);

        if (tile != null)
        {
#if DEBUG_LOGS
            Debug.Log(tile.Surface);
#endif

            CurrentSurface = (int)tile.Surface;
        }
    }
}
