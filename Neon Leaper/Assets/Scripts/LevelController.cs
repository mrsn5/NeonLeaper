using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    public static LevelController current;
    Vector3 startingPosition;
    [SerializeField]
    GameObject playerPrefab;

    void Awake()
    {
        current = this;
    }

    public void setStartPosition(Vector3 pos)
    {
        this.startingPosition = pos;
    }

    public void Respawn(Player player)
    {
        GameObject p = Instantiate(playerPrefab);
        p.transform.position = startingPosition;
    }


}
