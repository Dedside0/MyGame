using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace MyGame.classes
{
    public class MapManager
    {
        public List<CollisionSprite> CollisionSprites;
        public List<CollisionSprite> KilledSprites;
        Sprite[,] tiles;

        FormGame form;
        int tileSize;
        int horizontalTiles, verticalTiles;

        public MapManager(FormGame form)
        {
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
                        if (j >= stroka.Length || stroka[j] == '*')
                            tiles[i, j] = (new Sprite("data/pictures/floor1.png", x, y, tileSize, form));
                        else
                        {
                            tiles[i, j] = (new CollisionSprite("data/pictures/wall1.png", x, y, tileSize, form));
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

        public void SummonEnemy(Random rand)
        {
            if (CountOfEnemy() > 10)
                return;
            int x, y;
            do
            {
                x = rand.Next(0, verticalTiles);
                y = rand.Next(0, horizontalTiles);
            }
            while (tiles[y,x] is CollisionSprite);
            Enemy enemy = new Enemy("data/pictures/enemy1.jpg", x * tileSize, y * tileSize, 64, form);
            form.Controls.Add(enemy);
            form.Controls.SetChildIndex(enemy, 0);
            enemy.StartMove(form.player.X, form.player.Y);
        }
        public Player SummonPlayer(Random rand)
        {
            int x, y;
            do
            {
                x = rand.Next(0, verticalTiles);
                y = rand.Next(0, horizontalTiles);
            }
            while (tiles[y,x] is CollisionSprite);
            Player player = new Player("data/pictures/player1.png", x*tileSize, y*tileSize, 50, form);
            player.Show();
            player.mapManager = this;
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
    }
}
