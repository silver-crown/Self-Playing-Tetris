using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Content
{
    internal abstract class Factory
    {
        public abstract Content GetContent(Content.ContentType factoryContent);
    }
}
