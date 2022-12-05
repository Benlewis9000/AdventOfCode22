using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022
{
    public interface IFetcher
    {
        public Task<string> Fetch();
    }
}
