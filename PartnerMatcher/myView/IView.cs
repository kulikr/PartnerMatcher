using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerMatcher.View
{
    public interface IView
    {
        /// <summary>
        /// Prints messges from the modek
        /// </summary>
        /// <param name="text">text to display</param>
        void Output(string text);
    }
}
