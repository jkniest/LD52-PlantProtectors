namespace Level
{
    public struct ScoreUpdateData
    {
        public readonly float Score;
        public float LevelProgress;
        public float RequiredTillNextLevel;

        public ScoreUpdateData(float score, float levelProgress, float requiredTillNextLevel)
        {
            Score = score;
            LevelProgress = levelProgress;
            RequiredTillNextLevel = requiredTillNextLevel;
        }
    }
}