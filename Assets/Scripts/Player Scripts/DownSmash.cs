using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DownSmash : MonoBehaviour
{
    [Header("Tiles")]
    public List<Tile> smashableTiles;
    public Tilemap tilemap;

    [Header("Smash Variables")]
    public float smashUpForce = 3;
    public float smashDuration = 0.3f;
    public float smashGravity = 7;
    public Vector3 underOffset;

    [Space]
    public Transform player;
    public Animator playerAnimator;

    private PlayerActions actions;

    private void Awake()
    {
        actions = new PlayerActions();

        actions.PlayerControls.DownSmash.performed += ctx =>
        {
            StartCoroutine(Smash());
        };
    }

    private IEnumerator Smash()
    {
        Vector3Int underPosition = tilemap.WorldToCell(player.position + underOffset);
        Debug.Log($"Smashing {underPosition}");
        TileBase under = tilemap.GetTile(underPosition);
        if (under == null) yield break;
        Debug.Log(under);
        foreach (Tile tile in smashableTiles)
        {
            if (under.name == tile.name)
            {
                // animator.SetTrigger("DownSmash");

                // remove this when the animation is set or don't if you need it
                Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                float g = rb.gravityScale;
                rb.gravityScale = smashGravity;
                rb.AddForce(new Vector2(0, smashUpForce), ForceMode2D.Impulse);

                yield return new WaitForSeconds(smashDuration);

                rb.gravityScale = g;

                tilemap.SetTile(underPosition, null);
                yield break;
            }
        }
    }

    private void OnEnable()
    {
        actions.PlayerControls.DownSmash.Enable();
    }

    private void OnDisable()
    {
        actions.PlayerControls.DownSmash.Disable();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(player.transform.position + underOffset, new Vector3(0.5f, 0.5f));
    }
}
