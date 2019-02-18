using Microsoft.VisualStudio.TestTools.UnitTesting;
using SvgClean;

namespace Test
{
    [TestClass]
    public class E2ETest
    {
        [TestMethod]
        public void GivenSimpleSvg_ShouldOptimizeUsingDefaults()
        {
            var input = "<svg  xmlns=\"http://www.w3.org/2000/svg\" \n viewBox=\"0 0 12 16\">\n<path d=\"M5.05.01c.81 2.17.41\">\n</path>\n   </svg>    \n\n  ";
            var svgOptimizer = new SvgOptimizer();
            var output = svgOptimizer.Optimize(input);
            Assert.AreEqual("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", output);
        }
    }
}
