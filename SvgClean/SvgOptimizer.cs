using System.Runtime.CompilerServices;
using System;
using System.IO;
using System.Linq;
using SvgClean.Work;

[assembly: InternalsVisibleTo("Test")]

namespace SvgClean
{
    public class SvgOptimizer
    {
        private SvgOptimizerOptions _options;

        public SvgOptimizer() : this(new SvgOptimizerOptions())
        {
        }
        public SvgOptimizer(SvgOptimizerOptions options)
        {
            _options = options;
        }

        public string Optimize(string original)
        {
            return GetWorkers().Aggregate(original, (svg, next) => next.Work(svg));
        }

        public FileInfo Optimize(FileInfo original)
        {
            throw new NotImplementedException();
        }

        private IWork[] GetWorkers()
        {
            return new IWork[]
            {
                new RemoveNewLines(),
                new RemoveComments(),
                new MinifyStyles(),
                new TrimAttributes(),
                new TrimSpaces(),
            };
        }
    }
}
