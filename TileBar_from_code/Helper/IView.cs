using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileBar_from_code.Helper
{
    public interface IView
    {
        double Top { get; }
        double Left { get; }
        double Height { get; }
        double Width { get; }
    }
}
