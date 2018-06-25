using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController current;
    Vector3 startingPosition;
    [SerializeField]
    GameObject playerPrefab;
    [SerializeField]
    GameObject boxPrefab;

    List<Box> boxes = new List<Box>();
    [SerializeField]
    private Slider slider;
    
    
    private const float defaultIntervalTimeDecrease=60f;
    private float decreaseEnergyTime;

    private int defaultCrystals = 0;
   
    private int crystals;
    
    public Text crystalsText;
    public Text warningText;

    private LevelStats stats;

    void Awake()
    {
        slider.value = 1f;
        LoadStatistics();
        current = this;
        decreaseEnergyTime = defaultIntervalTimeDecrease;
    }
    
    public void LoadStatistics()
    {
        this.stats = LevelStats.Deserialize(SceneManager.GetActiveScene().name);
        if (this.stats == null) this.stats = new LevelStats();
    }

    public void Save()
    {
        if (stats.levelPassed)
        {
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name, JsonUtility.ToJson(this.stats));

            PlayerPrefs.Save();
        }
    }
    
    private void Start()
    {
        SetBoxes();     
    }
    
    void Update()
    {
        decreaseEnergyTime -= Time.deltaTime;
        if (decreaseEnergyTime < 0)
        {
            Player.lastPlayer.decreaseEnergy(2);
            decreaseEnergyTime = defaultIntervalTimeDecrease;
        }
        crystalsText.text = string.Format("{0}/{1}", crystals, defaultCrystals);
        if (Player.lastPlayer.getEnergy() <= 0)
        {
            LosePopUp.current.Open();
        }
        else if(Player.lastPlayer.getEnergy()<20) 
        {   
            warningText.enabled = true;
        }
        else
        {
            warningText.enabled = false;
        }
    }

    public void setLevelPassed(){
        stats.levelPassed = true;
    }
    
    public void setStartPosition(Vector3 pos)
    {
        this.startingPosition = pos;
    }

    public void Respawn(Player player)
    {
        player.transform.position = startingPosition;
    }

    public void AddBox(Box box) 
    {
        boxes.Add(box);
    }

    public int GetState()
    {
        return (int)slider.value;
    }


    private void SetBoxes()
    {
        foreach (Box box in boxes)
        {
            box.gameObject.SetActive(false);
            if (box.HasState(GetState()))
            {
                box.gameObject.SetActive(true);
                box.SetPosition(GetState());
            }
        }
    }

    public void SliderChanged()
    {
        Player.lastPlayer.decreaseEnergy(2);
        SetBoxes();       
    }

    public bool allCrystalsCollected()
    {
        return crystals==defaultCrystals;
    }

    public void addCrystal()
    {
        crystals++;
    }

    public void incrementDefaultCrystals() 
    {
        defaultCrystals++;
    }

}
