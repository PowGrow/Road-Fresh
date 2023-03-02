using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Statistic
{
    private static List<Line> _cachedStats;

    public static List<Line> CachedStats
    {
        get { return _cachedStats; }
    }

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
        _cachedStats = statistic;
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
        _cachedStats = statistic;
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

    public static string ConvertTime(float time)
    {
        int _seconds = (int)time % 60;
        int _minutes = (int)time / 60;
        int _hours = _minutes / 60;

        if (_hours == 0)
        {
            if (_minutes == 0)
            {
                return $"00:00:{_seconds}";
            }
            else
            {
                return $"00:{_minutes}:{_seconds}";
            }
        }
        else
        {
            return $"{_hours}:{_minutes}:{_seconds}";
        }
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
