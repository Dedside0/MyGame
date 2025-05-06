using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame.classes
{
    public class MapManager
    {
        public List<CollisionSprite> CollisionSprites;
        Sprite[,] tiles;
        Form form;
        int tileSize;
        int verticalTiles = 12;
        int horizontalTiles = 24;

        public MapManager(Form form)
        {
            CollisionSprites = new List<CollisionSprite>();
            this.form = form;
            tiles = new Sprite[verticalTiles, horizontalTiles];
            tileSize = Math.Min(form.ClientSize.Width / horizontalTiles, form.ClientSize.Height / verticalTiles);

        }

        public void UpdateSize()
        {
            tileSize = Math.Min(form.ClientSize.Width / horizontalTiles, form.ClientSize.Height / verticalTiles);
        }

        public void LoadMap()
        {
            for (int i = 0; i < verticalTiles; i++)
            {
                for (int j = 0; j < horizontalTiles; j++)
                {
                    int x = j * tileSize;
                    int y = i * tileSize;
                    if (i == 0 || i == verticalTiles - 1 || j == 0 || j == horizontalTiles - 1)
                    {
                        tiles[i, j] = new CollisionSprite("data/pictures/wall1.jpg", x, y, tileSize);
                        CollisionSprites.Add((CollisionSprite)tiles[i, j]);
                    }
                    else
                    {
                        tiles[i, j] = new Sprite("data/pictures/floor1.png", x, y, tileSize);
                    }
                }
            }
        }

        public void ClearMap()
        {

            foreach (var tile in tiles)
            {
                form.Controls.Remove(tile);
            }
            tiles = new Sprite[verticalTiles, horizontalTiles];
        }
        public void ShowMap()
        {
            foreach (var tile in tiles)
            {
                form.Controls.Add(tile);
            }
        }
    }
}
