using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


//CSV파일을 string으로 이루어진 2차원 배열로 불러오는 함수입니다.
//해당 리스트를 반환하는 함수로 변경하게 된다면, 단순히 로그만 띄우는게 아니라 데이터를 유의미하게 사용할 수 있습니다. 리소스 매니저에서 텍스트 에셋을 불러와서 사용합니다.
public static class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";

    public static void ReadCSV(TextAsset data)
    {
        string[] lines = data.text.Split(LINE_SPLIT_RE);//Regex.Split(data.text, LINE_SPLIT_RE); => 정규 표현식의 함수로 대체 가능합니다. 행 단위로 데이터를 잘라내어 스트링으로 저장합니다.

        if (lines.Length <= 1)
        {
            return;
        }

        List<List<string>> dataList = new(); //이 리스트에 데이터를 채워서 제가 즐겨 다루던 이중 리스트로 만듭니다.

        for (int i = 2; i < lines.Length; i++)
        {
            List<string> singleDataLine = new();
            singleDataLine.AddRange(lines[i].Split(SPLIT_RE));
            dataList.Add(singleDataLine);
        }

        string text = "";
        foreach (var stringlist in dataList)
        {
            foreach (string singleString in stringlist)
            {
                text += singleString + ",";
            }
            text = text.TrimEnd(',');
            text += "\n";
        }

        text.TrimEnd('\n');

        Debug.Log(text);
    }
}
