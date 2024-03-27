using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapLimit : MonoBehaviour
{
    public TilemapRenderer tilemapRenderer;
    public Vector3Int cellPosition;
    public GameObject test;

    private void Awake()
    {
        //StartCoroutine(VerificandoPosicionesDeCeldas());
        TieneLaPosicion(new Vector2(44.7f, -0.24f));
    }

    public IEnumerator VerificandoPosicionesDeCeldas()
    {
        Debug.Log("====================================================================================================================================================================================");
        Debug.Log("====================================================================================================================================================================================");
        Debug.Log("====================================================================================================================================================================================");
        Debug.Log("====================================================================================================================================================================================");
        if (tilemapRenderer != null)
        {
            Tilemap tilemap = tilemapRenderer.GetComponent<Tilemap>();

            // Obt�n la informaci�n de las celdas dibujadas
            TileBase[] tiles = tilemap.GetTilesBlock(tilemap.cellBounds);

            foreach (Vector3Int position in tilemap.cellBounds.allPositionsWithin)
            {
                Vector3 pos = tilemap.CellToLocal(position);
                // Obtiene el �ndice en el array de tiles
                int index = position.x - tilemap.cellBounds.x + (position.y - tilemap.cellBounds.y) * tilemap.cellBounds.size.x;

                // Verifica si la posici�n es v�lida y si hay un tile dibujado en esa posici�n
                if (/*tilemapRenderer.IsTileVisible(tilemap.GetCellCenterWorld(position)) && */index >= 0 && index < tiles.Length && tiles[index] != null)
                {
                    //TileBase tile = tiles[index];

                    // Aqu� puedes hacer algo con la celda, por ejemplo, obtener su posici�n, sprite, etc.
                    test.transform.position = pos;
                    //Debug.Log("Posici�n: " + position + ", Tile: " + tile.name);
                    Debug.Log("posicion local" + pos);
                    yield return new WaitForSeconds(3);
                }
            }
        }
        else
        {
            Debug.LogError("No se ha asignado el TilemapRenderer en el inspector.");
        }
    }

    public void TieneLaPosicion(Vector3 verifyPosition)
    {
        Debug.Log("====================================================================================================================================================================================");
        Debug.Log("====================================================================================================================================================================================");
        Debug.Log("====================================================================================================================================================================================");
        Debug.Log("====================================================================================================================================================================================");
        if (tilemapRenderer != null)
        {
            Tilemap tilemap = tilemapRenderer.GetComponent<Tilemap>();
            TileBase[] tiles = tilemap.GetTilesBlock(tilemap.cellBounds);

            foreach (Vector3Int position in tilemap.cellBounds.allPositionsWithin)
            {
                Vector3 pos = tilemap.CellToLocal(position);
                int index = position.x - tilemap.cellBounds.x + (position.y - tilemap.cellBounds.y) * tilemap.cellBounds.size.x;

                if (index >= 0 && index < tiles.Length && tiles[index] != null)
                {

                    if (verifyPosition == pos)
                    {
                        test.transform.position = pos;
                        Debug.Log("En el tilemap esta la posicion " + verifyPosition);
                    }
                }
            }
        }
        else
        {
            Debug.LogError("No se ha asignado el TilemapRenderer en el inspector.");
        }
    }
}
