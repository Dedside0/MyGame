using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MyGame.classes
{
    public class MapManager
    {
        public List<CollisionSprite> CollisionSprites;
        List<List<Sprite>> tiles;
        FormGame form;
        int tileSize;
        int verticalTiles;
        int horizontalTiles;

        public MapManager(FormGame form)
        {
            CollisionSprites = new List<CollisionSprite>();
            this.form = form;
            tiles = new List<List<Sprite>>();
        }

        public void LoadMap()
        {
            using (StreamReader sr = new StreamReader("data/levels/level1.lvl"))
            {
                while (!sr.EndOfStream)
                {
                    verticalTiles++;
                    string line = sr.ReadLine();
                    horizontalTiles = line.Length > horizontalTiles ? line.Length : horizontalTiles;
                }
            }
            tileSize = Math.Min(form.ClientSize.Width / horizontalTiles, form.ClientSize.Height / verticalTiles);
            using (StreamReader sr = new StreamReader("data/levels/level1.lvl"))
            {
                int i = 0;
                while (!sr.EndOfStream)
                {
                    tiles.Add(new List<Sprite>());
                    string stroka = sr.ReadLine();
                    for (int j = 0; j < stroka.Length; j++)
                    {
                        int x = j * tileSize;
                        int y = i * tileSize;
                        if (stroka[j] == '*')
                            tiles[i].Add(new Sprite("data/pictures/floor1.png", x, y, tileSize, form));
                        else
                        {
                            tiles[i].Add(new CollisionSprite("data/pictures/wall1.png", x, y, tileSize, form));
                            CollisionSprites.Add((CollisionSprite)tiles[i][j]);
                        }

                    }
                    i++;
                }
            }
            //for (int i = 0; i < verticalTiles; i++)
            //{
            //    for (int j = 0; j < horizontalTiles; j++)
            //    {
            //        int x = j * tileSize;
            //        int y = i * tileSize;
            //        if (i == 0 || i == verticalTiles - 1 || j == 0 || j == horizontalTiles - 1)
            //        {
            //            tiles[i, j] = new CollisionSprite("data/pictures/wall1.jpg", x, y, tileSize, form);
            //            CollisionSprites.Add((CollisionSprite)tiles[i, j]);
            //        }
            //        else
            //        {
            //            tiles[i, j] = new Sprite("data/pictures/floor1.png", x, y, tileSize,form);
            //        }
            //    }
            //}
        }

        public void ClearMap()
        {
            foreach (var list in tiles)
            {
                foreach (var tile in list)
                {
                    form.Controls.Remove(tile);

                }
            }
            tiles = new List<List<Sprite>>();
        }

        public void ShowMap()
        {
            foreach (var list in tiles)
            {
                foreach (var tile in list)
                {
                    form.Controls.Add(tile);
                    tile.Show();
                }
            }
        }
    }
}
