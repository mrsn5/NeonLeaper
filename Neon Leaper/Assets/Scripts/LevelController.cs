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

    public int defaultCrystals;
   
    private int crystals;
    public Text crystalsText;
    public Text warningText;

    void Awake()
    {
        slider.value = 1f;
        current = this;
        decreaseEnergyTime = defaultIntervalTimeDecrease;
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


    public void addCrystal()
    {
        crystals++;
    }

}
