using Enums;

namespace Commands
{
    public class SaveGameCommand
    {
        public void OnSaveGameData(SaveStates state, int data)
        {
            if (state == SaveStates.Score)
            {
                int totalScore = ES3.Load<int>("Score") + data;
                ES3.Save("Score", totalScore);
            }
            if (state == SaveStates.Level)
            {
                ES3.Save("Level", data);
            }
        }
    }
}
