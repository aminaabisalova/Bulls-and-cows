using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Bulls_and_Cows
{
    public class GameHistory
    {
        List<GameRecord> games = new List<GameRecord>();
        string playerName;
        string filePath;

        public GameHistory(string playerName)
        {
            this.playerName = playerName;
            filePath = "result_" + playerName + ".txt";
            Load();
        }

        public int TotalGames
        {
            get { return games.Count; }
        }

        public int Wins
        {
            get
            {
                int count = 0;
                foreach (GameRecord g in games)
                {
                    if (g.IsWin)
                        count++;
                }
                return count;
            }
        }

        public void Add(GameRecord record)
        {
            games.Add(record);
            Save();
        }

        private void Load()
        {
            if (File.Exists(filePath) == false)
                return;

                StreamReader reader = new StreamReader(filePath);

            List<string> lines = new List<string>();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            reader.Close();

            foreach (string currentLine in lines)
            {
                if (currentLine == "")
                {
                    continue;
                }

                if (currentLine.Contains("Хъазæджы"))
                {
                    continue;
                }
                if (currentLine.Contains("Бон"))
                {
                    continue;
                }
                if (currentLine.Contains("Æдæппæт"))
                {
                    continue;
                }
                if (currentLine.Contains("Уæлахизтæ"))
                {
                    continue;
                }

                if (currentLine.Contains("|") == false)
                {
                    continue;
                }

                string[] parts = currentLine.Split('|');

                if (parts.Length < 5) continue;

                string[] dateParts = parts[0].Split(' ');
                string[] lengthParts = parts[1].Split(' ');
                string[] wordParts = parts[2].Split(' ');
                string[] resultParts = parts[3].Split(' ');
                string[] attemptsParts = parts[4].Split(' ');

                DateTime date;
                string dateText = dateParts[0] + " " + dateParts[1];
                bool dateOk = DateTime.TryParse(dateText, out date);

                if (dateOk == false)
                {
                    continue;
                }

                int wordLength = int.Parse(lengthParts[1]);

                string secretWord = wordParts[1];

                bool isWin = (resultParts[1] == "Уæлахиз");

                int attemptsUsed = int.Parse(attemptsParts[1]);

                GameRecord record = new GameRecord(playerName, date, wordLength, secretWord, isWin, attemptsUsed);
                    games.Add(record);
                
            }
        }

        private void Save()
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine("Хъазæджы турнирон таблицæ: " + playerName);
                writer.WriteLine("Бон             | Зындзинад    | Дзырд   | Фæстиуæг | Фæлварæнтæ");

                foreach (GameRecord gr in games)
                {
                    string resultText;
                    if (gr.IsWin)
                        resultText = "Уæлахиз";
                    else
                        resultText = "Фæхæрд";

                    string line = gr.Date.ToString("yyyy-MM-dd HH:mm") + " | " +
                                  gr.WordLength + " дамгъæйы | " +
                                  gr.SecretWord + " | " +
                                  resultText + " | " +
                                  gr.AttemptsUsed;
                    writer.WriteLine(line);
                }

                writer.WriteLine("Æдæппæт хъазтытæ: " + games.Count);
                writer.WriteLine("Уæлахизтæ: " + Wins);
            }
        }
    }
}
