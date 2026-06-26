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
            if (!File.Exists(filePath))
                return;

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    if (line.StartsWith("Турнирная") || line.StartsWith("Дата") ||
                        line.StartsWith("Всего") || line.StartsWith("Побед"))
                        continue;
                    if (!line.Contains("|"))
                        continue;

                    string[] parts = line.Split('|');
                    if (parts.Length < 5)
                        continue;

                    DateTime date = DateTime.Parse(parts[0].Trim());
                    string wordLengthStr = parts[1].Trim().Replace(" букв", "").Trim();
                    int wordLength = int.Parse(wordLengthStr);
                    string secretWord = parts[2].Trim();
                    bool isWin;
                    if (parts[3].Trim() == "Победа")
                        isWin = true;
                    else
                        isWin = false;
                    int attemptsUsed = int.Parse(parts[4].Trim());

                    GameRecord record = new GameRecord(
                        playerName,
                        date,
                        wordLength,
                        secretWord,
                        isWin,
                        attemptsUsed
                    );
                    games.Add(record);
                }
            }
            catch
            {
                games = new List<GameRecord>();
            }
        }

        private void Save()
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine("Турнирная таблица игрока: " + playerName);
                writer.WriteLine("Дата             | Сложн.    | Слово   | Результат | Попыток");

                foreach (GameRecord gr in games)
                {
                    string resultText;
                    if (gr.IsWin)
                        resultText = "Победа";
                    else
                        resultText = "Поражение";

                    string line = gr.Date.ToString("yyyy-MM-dd HH:mm") + " | " +
                                  gr.WordLength + " букв | " +
                                  gr.SecretWord + " | " +
                                  resultText + " | " +
                                  gr.AttemptsUsed;
                    writer.WriteLine(line);
                }

                writer.WriteLine("Всего игр: " + games.Count);
                writer.WriteLine("Побед: " + Wins);
            }
        }
    }
}
