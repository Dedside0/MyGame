using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace MyGame.classes
{
    public class MapManager
    {
        Stopwatch reloadTimer = new Stopwatch();
        public bool isReload
        {
            get
            {
                if (reloadTimer.ElapsedMilliseconds >= 500)
                {
                    reloadTimer.Restart();
                    return true;
                }
                return false;
            }
        }
        public List<CollisionSprite> CollisionSprites;
        public List<CollisionSprite> KilledSprites;
        Sprite[,] tiles;
        List<Record> records = new List<Record>();

        Random rand;
        FormGame form;
        int tileSize;
        int horizontalTiles, verticalTiles;

        public MapManager(FormGame form)
        {
            string json = File.ReadAllText("Records.json");
            records = JsonConvert.DeserializeObject<List<Record>>(json);
            if(records == null)
                records = new List<Record>();

            reloadTimer = new Stopwatch();
            reloadTimer.Start();
            rand = new Random();
            KilledSprites = new List<CollisionSprite>();
            CollisionSprites = new List<CollisionSprite>();
            this.form = form;
        }

        public void LoadMap()
        {
            using (StreamReader sr = new StreamReader("data/levels/level1.lvl"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    horizontalTiles++;
                    verticalTiles = line.Length > verticalTiles ? line.Length : verticalTiles;
                }
            }
            tiles = new Sprite[horizontalTiles, verticalTiles];
            tileSize = Math.Min(form.ClientSize.Width / verticalTiles, form.ClientSize.Height / horizontalTiles);
            using (StreamReader sr = new StreamReader("data/levels/level1.lvl"))
            {

                int i = 0;
                while (!sr.EndOfStream)
                {
                    string stroka = sr.ReadLine();
                    for (int j = 0; j < verticalTiles; j++)
                    {
                        int x = j * tileSize;
                        int y = i * tileSize;
                        if (j >= stroka.Length || stroka[j] == '*' || stroka[j] == ' ')
                            tiles[i, j] = (new Sprite("data/pictures/floor1.jpg", x, y, tileSize, form));
                        else
                        {
                            tiles[i, j] = (new CollisionSprite("data/pictures/wall1.jpg", x, y, tileSize, form));
                            CollisionSprites.Add((CollisionSprite)tiles[i, j]);
                        }

                    }
                    i++;
                }
            }

        }

        public void ClearMap()
        {
            if (tiles == null)
                return;
            foreach (var tile in tiles)
            {
                form.Controls.Remove(tile);
            }
            tiles = null;
        }

        public void ShowMap()
        {
            foreach (var tile in tiles)
            {
                form.Controls.Add(tile);
                tile.Show();
            }
        }

        public void SummonEnemy()
        {
            if (CountOfEnemy() > 7)
                return;
            int x, y;
            do
            {
                x = rand.Next(0, verticalTiles);
                y = rand.Next(0, horizontalTiles);
            }
            while (tiles[y, x] is CollisionSprite);
            int type = rand.Next(1, 3);
            Enemy summonSprite = new Enemy(type, x * tileSize, y * tileSize, 45, form);
            form.Controls.Add(summonSprite);
            form.Controls.SetChildIndex(summonSprite, 0);
            summonSprite.StartMove(form.player.X, form.player.Y);
        }


        public Player SummonPlayer(string skinID)
        {
            int x, y;
            do
            {
                x = rand.Next(0, verticalTiles);
                y = rand.Next(0, horizontalTiles);
            }
            while (tiles[y, x] is CollisionSprite);

            Player player = new Player(skinID, x * tileSize, y * tileSize, 50, form);
            player.Show();
            form.Controls.Add(player);
            form.Controls.SetChildIndex(player, 0);
            return player;
        }

        int CountOfEnemy()
        {
            int cnt = 0;
            foreach (var sprite in form.mapManager.CollisionSprites)
            {
                if (sprite is Enemy)
                    cnt++;
            }
            return cnt;
        }

        public void GameOver(Player player)
        {
            form.timerEnemySpawn.Stop();
            player.DeleteSprite();
            foreach (var item in CollisionSprites)
            {
                if (item is Enemy)
                    KilledSprites.Add(item);
            }
            MessageBox.Show($"Вы проиграли, набрав {player.Score} очков");
            FormAddRecord formAddRecord = new FormAddRecord();
            formAddRecord.ShowDialog();
            Record newRecord = new Record(formAddRecord.UserName, player.Score);
            AddNewRecord(newRecord);

            FormRecords formRecords = new FormRecords();
            formRecords.ShowDialog();
        }

        void AddNewRecord(Record record)
        {
            for (int i = 0;i<records.Count;i++)
            {
                if (records[i].Score < record.Score)
                {
                    records.Insert(i,record);
                    break;
                }
            }
            string temp = JsonConvert.SerializeObject(records, Formatting.Indented);
            File.WriteAllText("Records.json", temp);
        }
    }
}
