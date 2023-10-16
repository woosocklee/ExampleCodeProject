using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


//CSV������ string���� �̷���� 2���� �迭�� �ҷ����� �Լ��Դϴ�.
//�ش� ����Ʈ�� ��ȯ�ϴ� �Լ��� �����ϰ� �ȴٸ�, �ܼ��� �α׸� ���°� �ƴ϶� �����͸� ���ǹ��ϰ� ����� �� �ֽ��ϴ�. ���ҽ� �Ŵ������� �ؽ�Ʈ ������ �ҷ��ͼ� ����մϴ�.
public static class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";

    public static void ReadCSV(TextAsset data)
    {
        string[] lines = data.text.Split(LINE_SPLIT_RE);//Regex.Split(data.text, LINE_SPLIT_RE); => ���� ǥ������ �Լ��� ��ü �����մϴ�. �� ������ �����͸� �߶󳻾� ��Ʈ������ �����մϴ�.

        if (lines.Length <= 1)
        {
            return;
        }

        List<List<string>> dataList = new(); //�� ����Ʈ�� �����͸� ä���� ���� ��� �ٷ�� ���� ����Ʈ�� ����ϴ�.

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
