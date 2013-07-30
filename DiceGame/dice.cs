using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DiceGame
{
    class dice : PictureBox
    {
        
        //resource images from http://openclipart.org

        //Constructor
        internal dice(int value, int rollCount)
        {
            this.Size = new Size(100, 100);
            switch (value)
            {
            case 1:
            this.Image = DiceGame.Properties.Resources.die1;
            break;
            case 2:
            this.Image = DiceGame.Properties.Resources.die2;
            break;
            case 3:
            this.Image = DiceGame.Properties.Resources.die3;
            break;
            case 4:
            this.Image = DiceGame.Properties.Resources.die4;
            break;
            case 5:
            this.Image = DiceGame.Properties.Resources.die5;
            break;
            case 6:
            this.Image = DiceGame.Properties.Resources.die6;
            break;
            default: 
            break;
            }
            switch (rollCount)
            {
                case 1:
                    this.Location = new Point(170, 200);
                    break;
                case 2:
                    this.Location = new Point(276, 200);
                    break;
                case 3:
                    this.Location = new Point(382, 200);
                    break;
                case 4:
                    this.Location = new Point(488, 200);
                    break;
                default:
                    break;
            }
            
        }

       


    }
}
