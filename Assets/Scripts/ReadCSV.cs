using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class ReadCSV : MonoBehaviour
{
    [SerializeField]
    public Text Ques;
    [SerializeField]
    public Text AnsCh;
    [SerializeField]
    public Button B1;
    [SerializeField]
    public Button B2;
    [SerializeField]
    public Button B3;
    [SerializeField]
    public Button B4;
    private string temp;
    public string vocType;
    static ReadCSV csv;
     public static ReadCSV GetIns()
     {
         if (csv == null)
             csv = new ReadCSV();
         return csv;
     }
     public string[][] m_ArrayData;
     public void LoadFile(string path, string fileName)
     {
         m_ArrayData = new string[0][];
         string fillPath = path + "/" + fileName;

        string[] lineArray;
         try
         {
             lineArray = File.ReadAllLines(fillPath, Encoding.Default);
             Debug.Log("file finded!");
         }
         catch
         {
             Debug.Log("file do not find!");
             return;
         }
 
         m_ArrayData = new string[lineArray.Length][];
         for (int i = 0; i<lineArray.Length; i++)
         {
             m_ArrayData[i] = lineArray[i].Split(',');
         }
    }
     public string GetVaule(int row, int col)
     {        
         return m_ArrayData[row][col];
     }
    
    void Start()
    {
        vocType = "TOEIC3000.csv";
        LoadFile(Application.streamingAssetsPath, vocType);        
        RandomVocabulary(Ques);
        HandleText(B1, B2, B3, B4);
    }
    private int[] ran_ArrayData ;
    private int[] rrr ;
    private int[] testArray;
    private int[] testArray1;
    
    public void RandomVocabulary(Text text1)
    {
        testArray = GetRandomSequence(m_ArrayData.Length, 4);
        text1.GetComponent<Text>().text = GetVaule(testArray[0], 0);
    }
    
    public int[] GetRandomSequence(int total, int count)
    {
        int[] sequence = new int[total];
        int[] output = new int[count];
        for (int i = 0; i < total; i++)
        {
            sequence[i] = i;
        }
        int end = total - 1;
        for (int i = 0; i < count; i++)
        {
            int num = Random.Range(0, end + 1);
            output[i] = sequence[num];
            sequence[num] = sequence[end];
            end--;
        }
        return output;
    }
    public void HandleText(Button button1, Button button2, Button button3, Button button4)
    {
        testArray1 = GetRandomSequence(4, 4);
        button1.GetComponentInChildren<Text>().text = GetVaule(testArray[testArray1[0]], 1);
        button2.GetComponentInChildren<Text>().text = GetVaule(testArray[testArray1[1]], 1);
        button3.GetComponentInChildren<Text>().text = GetVaule(testArray[testArray1[2]], 1);
        button4.GetComponentInChildren<Text>().text = GetVaule(testArray[testArray1[3]], 1);
    }
    public void Ans(Text ans)
    {
        ans.text = "µª®×: " + GetVaule(testArray[0], 1);
    }
    public void ClearText(Text ans)
    {
        ans.text = "...";
 
    }
    public void NextQ()
    {
        ClearText(AnsCh);
        RandomVocabulary(Ques);
        HandleText(B1, B2, B3, B4);
    }
}
