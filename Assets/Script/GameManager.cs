using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField inputField;
    public Material[] materials;
    List<int> arrayIndex = new List<int>();

    public GameObject canvas_input;
    public GameObject canvas_success;
    public GameObject canvas_fail;
    public int randomSkyboxNumber;

    //This is only for using with the simulator you don't need this line with the MetaQuest
    // public string answerTyped;

    void Start()
    {
        randomSkyboxNumber = UnityEngine.Random.Range(0, materials.Length - 1);
        RenderSettings.skybox = materials [randomSkyboxNumber];
        arrayIndex.Clear();
        for (int i = 0; i <= materials.Length; i++) {
            arrayIndex.Add(i);
            // Additional logic if needed
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendAnswer()
    {
        //This is only for using with the simulator you don't need this line with the MetaQuest
        // inputField.text = answerTyped;


        CheckAnswer(inputField.text);
    }

    public void TryAgain()
    {
       canvas_fail.SetActive(false);
       canvas_input.SetActive(true);

    }

    public void Continue()
    {

        canvas_success.SetActive(false);
        canvas_input.SetActive(true);
    
    // Check if there are any remaining indices to choose from
    if (arrayIndex.Count > 0)
    {
        arrayIndex.Remove(randomSkyboxNumber); // Remove the current skybox number
        
        // Select a random index from arrayIndex
        int randomIndex = UnityEngine.Random.Range(0, arrayIndex.Count);
        randomSkyboxNumber = arrayIndex[randomIndex]; // Assign to the class-level field
        
        // Update the skybox
        RenderSettings.skybox = materials[randomSkyboxNumber];
        
        // Remove selected index from arrayIndex
        arrayIndex.RemoveAt(randomIndex);
            
            if (arrayIndex.Count == 0)
            {
                return;
            } else {
                RenderSettings.skybox = materials[randomSkyboxNumber];
            }
        }

    }

    private void CheckAnswer(string answer)
    {
        canvas_input.SetActive(false);

        if(RenderSettings.skybox.name == answer)
        {
            canvas_success.SetActive(true);

        } else {
            canvas_fail.SetActive(true);
        }
    }
}
