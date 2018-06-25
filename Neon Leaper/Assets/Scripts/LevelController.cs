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

   

    private int defaultCrystals = 0;
   
    private int crystals;
    public Text crystalsText;

    void Awake()
    {
        slider.value = 1f;
        current = this;
    }

    private void Start()
    {
        SetBoxes();     
    }
    
    void Update()
    {
        crystalsText.text = string.Format("{0}/{1}", crystals, defaultCrystals);
        if(Player.lastPlayer.getEnergy()<10) 
        {   
            slider.enabled=false;
        }
        else
        {
            slider.enabled=true;
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
        Player.lastPlayer.decreaseEnergy(10);
        SetBoxes();       
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
