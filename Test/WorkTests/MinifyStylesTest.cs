using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SvgClean.Work;

namespace Test.WorkTests
{
    [TestClass]
    public class MinifyStylesTest
    {
        [TestMethod]
        public void Execute()
        {
            var worker = new MinifyStyles();
            var data = new Dictionary<string, string>
            {
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><style>.cls-1, .cls-2 {    fill:none;    stroke:#438977;    stroke-miterlimit:10; }.cls-1 {    stroke-width:5px;}.cls-2 {    stroke-linecap:round;    stroke-width:3px;}.cls-3 {    fill:#438977;}</style><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><style>.cls-1,.cls-2{fill:none;stroke:#438977;stroke-miterlimit:10}.cls-1{stroke-width:5px}.cls-2{stroke-linecap:round;stroke-width:3px}.cls-3{fill:#438977}</style><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><style>This isn't CSS <***></style><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><style>This isn't CSS <***></style><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
            };

            foreach (var input in data.Keys)
            {
                Assert.AreEqual(data[input], worker.Work(input));
            }
        }
    }
}
