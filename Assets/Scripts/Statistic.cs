using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Statistic
{
    private const string SAVE_FILE_NAME = "statistic.dat";
    public static List<Line> LoadStatistic()
    {
        var fileName = FileNameCombine(SAVE_FILE_NAME);
        List<Line> statistic;
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(fileName, FileMode.Open);
        statistic = formatter.Deserialize(stream) as List<Line>;
        stream.Close();
        stream.Dispose();
        return statistic;
    }

    public static void SaveStatistic(List<Line> statistic)
    {
        using (FileStream stream = File.Create(FileNameCombine(SAVE_FILE_NAME)))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, statistic);
            stream.Close();
        }
    }

    private static string FileNameCombine(string saveFileName)
    {
        var filename = Path.Combine(Application.persistentDataPath, saveFileName);
        return filename;
    }

    public static bool IsThereAreSaveData()
    {
        if (!File.Exists(FileNameCombine(SAVE_FILE_NAME)))
        {
            return false;
        }
        return true;
    }

    [Serializable]
    public struct Line
    {
        public Line(float score, float time, float obstaclesCount)
        {
            Score = score;
            Time = time;
            ObstaclesCount = obstaclesCount;
        }

        public float Score { get; }
        public float Time { get; }
        public float ObstaclesCount { get; }
    }
}
