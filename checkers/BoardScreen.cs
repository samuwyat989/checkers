using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace checkers
{
    public partial class BoardScreen : UserControl
    {
        public BoardScreen()
        {
            InitializeComponent();
        }
        string[] boardVals;
        string selectPlayer = "", movePlayer = "";
        int squareLength = 30;
        bool isCaps = false, playerTurn = false;
        Dictionary<string, Region> boardRegions = new Dictionary<string, Region>();
        SolidBrush drawBrush = new SolidBrush(Color.Beige);
        List<string> redPLayers = new List<string>();
        List<string> brownPLayers = new List<string>();
        Graphics g;

        private void BoardScreen_Load(object sender, EventArgs e)
        {
            boardVals = new string[64];
            Char c;
            Rectangle square;
            
            int rowVal = -1, counter = 0;
            for(int i = 0; i < boardVals.Length; i++)
            {
                if(i%8==0)
                {
                    rowVal++;
                    counter = 0;
                }
                c = (Char)((isCaps ? 65 : 97) + rowVal);
                boardVals[i] = c.ToString() + (counter+1).ToString();
                square = new Rectangle(rowVal * squareLength, counter* squareLength, squareLength, squareLength);
                boardRegions.Add(boardVals[i], new Region(square));
                counter++;             
            }
            redPLayers = new List<string> { "a1", "a3", "b2", "c1", "c3", "d2", "e1", "e3", "f2", "g1", "g3", "h2" };
            brownPLayers = new List<string> { "a7", "b6", "b8", "c7", "d6", "d8", "e7", "f6", "f8", "g7", "h6", "h8" };
        }

        private void BoardScreen_Paint(object sender, PaintEventArgs e)
        {
            int paintOffset = 0;
            for (int i = 0; i < boardVals.Length; i++)
            {
                if(i%8 == 0)
                {
                    paintOffset++;
                }
                if ((i+paintOffset) % 2 == 0)
                {
                    drawBrush.Color = Color.White;
                }
                else
                {
                    drawBrush.Color = Color.Black;
                }
                e.Graphics.FillRegion(drawBrush, boardRegions[boardVals[i]]);
            }
            DrawPLayers();
        }

        public void DrawPLayers()
        {
            g = this.CreateGraphics();

            for (int i = 0; i < redPLayers.Count(); i++)
            {
                g.FillEllipse(Brushes.BurlyWood, boardRegions[brownPLayers[i]].GetBounds(g).X, boardRegions[brownPLayers[i]].GetBounds(g).Y, squareLength, squareLength);
                g.FillEllipse(Brushes.Firebrick, boardRegions[redPLayers[i]].GetBounds(g).X, boardRegions[redPLayers[i]].GetBounds(g).Y, squareLength, squareLength);
            }
        }

        private void BoardScreen_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
           
            int xPos = this.PointToClient(MousePosition).X;
            int yPos = this.PointToClient(MousePosition).Y;

            string col = "";
            int row = 0;

            for(int i = 0; i <boardVals.Length; i+=8)
            {
                try
                {
                    if (xPos > boardRegions[boardVals[i]].GetBounds(g).X && xPos < boardRegions[boardVals[i + 8]].GetBounds(g).X)
                    {
                        char c = (Char)((isCaps ? 65 : 97) + i / 8);
                        col = c.ToString();
                    }
                }
                catch
                {
                    col = "h";
                }
            }

            for (int k = 0; k < boardVals.Length / 8; k++)
            {
                if (yPos > boardRegions[boardVals[k]].GetBounds(g).Y && yPos < boardRegions[boardVals[k + 1]].GetBounds(g).Y)
                {
                    row = k + 1;
                    break;
                }
                else
                {
                    row = 8;
                }
            }

            string position = col + row.ToString();

            if (selectPlayer == "")
            {
                selectPlayer = position;
                if(playerTurn)
                {
                    playerTurn = false;
                }
                else
                {
                    playerTurn = true;
                }
            }
            else
            {
                movePlayer = position;
                if(playerTurn)
                {
                    int playerIndex = redPLayers.IndexOf(selectPlayer);//red players need to be added 
                    redPLayers.Insert(playerIndex, movePlayer);
                    redPLayers.Remove(selectPlayer);
                    selectPlayer = "";
                    movePlayer = "";
                }
                else
                {
                    int playerIndex = brownPLayers.IndexOf(selectPlayer);//red players need to be added 
                    brownPLayers.Insert(playerIndex, movePlayer);
                    brownPLayers.Remove(selectPlayer);
                    selectPlayer = "";
                    movePlayer = "";
                }
            }
            
            g.FillRegion(Brushes.Green, boardRegions[position]);
            DrawPLayers();
        }
    }
}
