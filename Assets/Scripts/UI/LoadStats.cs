using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RoadFresh.Stats
{
    public class LoadStats : MonoBehaviour
    {
        [SerializeField]
        private int lineIndex;
        [SerializeField]
        private TextMeshProUGUI score;
        [SerializeField]
        private TextMeshProUGUI obstacles;
        [SerializeField]
        private TextMeshProUGUI time;

        private void OnEnable()
        {
            if (Statistic.CachedStats != null && Statistic.CachedStats.Count >= lineIndex)
            {
                SetStats(Statistic.CachedStats);
            }
            else if (Statistic.IsThereAreSaveData())
            {
                SetStats(Statistic.LoadStatistic());
            }
        }

        private void SetStats(List<Statistic.Line> statistic)
        {
            score.text = statistic[lineIndex - 1].Score.ToString();
            obstacles.text = statistic[lineIndex - 1].ObstaclesCount.ToString();
            time.text = Statistic.ConvertTime(statistic[lineIndex - 1].Time);
        }
    }
}
