using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController current;
    Vector3 startingPosition;
    [SerializeField]
    GameObject playerPrefab;

    public int defaultCrystals;
   
    private int crystals;
    public Text crystalsText;

    void Awake()
    {
        current = this;
    }
    
    void Update()
    {
        crystalsText.text = string.Format("{0}/{1}", crystals, defaultCrystals);
    }
    
    public void setStartPosition(Vector3 pos)
    {
        this.startingPosition = pos;
    }

    public void Respawn(Player player)
    {
        player.transform.position = startingPosition;
    }

    public void addCrystal()
    {
        crystals++;
    }
    

}
