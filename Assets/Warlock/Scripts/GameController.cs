using UnityEngine;
using System.Collections;
using Leap.Unity;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public PinchDetector PinchDetectorL;
    public PinchDetector PinchDetectorR;

    public int playerlife;
    public float waitinterval;

    private float NextCreateTime;

    public Text InstructionText;
    public Text LifeText;
    public bool hastransfer;
    public bool hasfireball;
    public bool isend;

    //public GameObject GuiTexture;
    public GameObject[] EnemyGroup;
    public GameObject[] paltrigger;
    public GameObject[] artrigger;
    public GameObject galtrigger;
    // Use this for initialization
    void Start () {
        StartSetting();
        StartCoroutine(StartGameInstruction());
        isend = false;
        //StartCoroutine(FlashWhenHit());
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey("escape"))
            Application.Quit();
        if (playerlife > 0)
        {
            LifeText.text = "Your life: " + playerlife;
        }
        else
        {
            isend = true;
            StopAllCoroutines();
            LifeText.text = "You die!";
            InstructionText.text = "Press R to restart";

        }
        if(isend && Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

    }

    private void CreateBox()
    {
        /*if (pre_cube != null)
            pre_cube.GetComponent<ItemController>().isPinch = false;

        cube.GetComponent<ItemController>().PinchDetectorL = PinchDetectorL;
        cube.GetComponent<ItemController>().PinchDetectorR = PinchDetectorR;
        Vector3 p = (PinchDetectorL.Position + PinchDetectorR.Position) / 2.0f;
        Quaternion pp = Quaternion.Lerp(PinchDetectorL.Rotation, PinchDetectorR.Rotation, 0.5f);
        pre_cube = (GameObject)Instantiate(cube, p, pp);*/
    }

    private void ControlItem()
    {

    }

    private void StartSetting()
    {
        InstructionText.color = new Color(255, 255, 255);
        InstructionText.fontSize = 3;
        LifeText.color = new Color(255, 255, 255);
        LifeText.fontSize = 2;

        hastransfer = false;
        hasfireball = false;
    }

    IEnumerator StartGameInstruction()
    {
        InstructionText.text = "Welcome to the warlock game!";
        yield return new WaitForSeconds(waitinterval);
        InstructionText.text = "Your left hand can spawn the transfer ball that can transfer your to any place";
        yield return new WaitForSeconds(waitinterval);
        InstructionText.text = "Put up your left Index, try it!";
        yield return new WaitUntil(() => hastransfer);
        InstructionText.text = "Well done!";
        yield return new WaitForSeconds(waitinterval);
        InstructionText.text = "Your right hand can spawn fireball, thunder or grab a sword";
        yield return new WaitForSeconds(waitinterval);
        InstructionText.text = "Now, Try to spawn a fireball!";
        yield return new WaitUntil(() => hasfireball);
        InstructionText.text = "Well done!";
        yield return new WaitForSeconds(waitinterval);
        InstructionText.text = "You can also use your right index to create thunder";
        yield return new WaitForSeconds(waitinterval);
        InstructionText.text = "anytime you want to quit the game, press the escape on your keyboard";
        yield return new WaitForSeconds(waitinterval);
        InstructionText.text = "Instruction end";

        StartCoroutine(GameCharpterOne());

    }

    IEnumerator GameCharpterOne()
    {
        yield return new WaitForSeconds(waitinterval);
        InstructionText.text = "Charpter one begin!";
        yield return new WaitForSeconds(waitinterval);
        Instantiate(EnemyGroup[0], paltrigger[0].transform.position, paltrigger[0].transform.rotation);
        yield return new WaitUntil(IsNoEnemy);
        InstructionText.text = "Well done, charpter one end";
        StartCoroutine(GameCharpterTwo());
        
    }

    IEnumerator GameCharpterTwo()
    {
        yield return new WaitForSeconds(waitinterval);
        InstructionText.text = "Charpter two begin!";
        yield return new WaitForSeconds(waitinterval);

        Instantiate(EnemyGroup[0], paltrigger[1].transform.position, paltrigger[1].transform.rotation);
        Instantiate(EnemyGroup[1], artrigger[0].transform.position, artrigger[0].transform.rotation);

        yield return new WaitUntil(IsNoEnemy);
        InstructionText.text = "Well done, charpter two end";
        StartCoroutine(GameCharpterThree());
    }

    IEnumerator GameCharpterThree()
    {
        yield return new WaitForSeconds(waitinterval);
        InstructionText.text = "Charpter three begin!";
        yield return new WaitForSeconds(waitinterval);

        Instantiate(EnemyGroup[0], paltrigger[2].transform.position, paltrigger[2].transform.rotation);
        Instantiate(EnemyGroup[1], artrigger[1].transform.position, artrigger[1].transform.rotation);
        Instantiate(EnemyGroup[2], galtrigger.transform.position, galtrigger.transform.rotation);

        yield return new WaitUntil(IsNoEnemy);
        InstructionText.text = "Well done, charpter three end";
        StartCoroutine(GameCharpterFour());
    }

    IEnumerator GameCharpterFour()
    {
        yield return new WaitForSeconds(waitinterval);
        InstructionText.text = "Charpter three begin!";
        yield return new WaitForSeconds(waitinterval);

        for (int i = 0; i < 10; i++)
        {
            Instantiate(EnemyGroup[0], paltrigger[i%3].transform.position, paltrigger[i%3].transform.rotation);
            if(i % 2 == 0)
                Instantiate(EnemyGroup[1], artrigger[i%2].transform.position, artrigger[i%2].transform.rotation);
            if(i % 3 == 0)
                Instantiate(EnemyGroup[2], galtrigger.transform.position, galtrigger.transform.rotation);
            yield return new WaitForSeconds(waitinterval);
        }
        yield return new WaitUntil(IsNoEnemy);
        InstructionText.text = "Well done, charpter three end";
    }

    private bool IsNoEnemy()
    {
        if (GameObject.FindGameObjectsWithTag("GalEnemy").Length == 0 
            && GameObject.FindGameObjectsWithTag("PalEnemy").Length == 0
                && GameObject.FindGameObjectsWithTag("ArEnemy").Length == 0)
        {
            return true;
        }
        else
            return false;
    }

    IEnumerator fade(float start, float end, float length, GameObject currentObject)
    {
        Color color = currentObject.GetComponent<GUITexture>().color;
        if (color.a == start)
        {
            for(float i=0;i<1.0f;i+=Time.deltaTime*(1/length))
            {
                color.a = Mathf.Lerp(start, end, i);
                yield return new WaitForSeconds(0.01f);
                color.a = end;
            }
        }
    }

    IEnumerator FlashWhenHit()
    {
        //StartCoroutine(fade(0, 0.8f, 0.5f, GuiTexture));
        yield return new WaitForSeconds(0.01f);
        //StartCoroutine(fade(0.8f, 0, 0.5f, GuiTexture));
    }
}
