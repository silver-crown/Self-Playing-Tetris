using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Content
{
    internal class TetrisFactory : Factory
    {
        public override Content GetContent(Content.ContentType tetrisBlockType) {
            switch (tetrisBlockType) {
                case (Content.ContentType)TetrisBlock.ContentType.T:
                    break;
                case (Content.ContentType)TetrisBlock.ContentType.LINE:
                    break;
                case (Content.ContentType)TetrisBlock.ContentType.SQUARE:
                    break;
                case (Content.ContentType)TetrisBlock.ContentType.Z:
                    break;
                case (Content.ContentType)TetrisBlock.ContentType.REVERSE_Z:
                    break;
                case (Content.ContentType)TetrisBlock.ContentType.L:
                    break;
                case (Content.ContentType)TetrisBlock.ContentType.REVERSE_L:
                    break;
            }
            throw new NotImplementedException();
        }
    }
}
