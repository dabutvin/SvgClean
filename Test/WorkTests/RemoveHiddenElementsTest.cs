using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SvgClean.Work;

namespace Test.WorkTests
{
    [TestClass]
    public class RemoveHiddenElementsTest
    {
        [TestMethod]
        public void Execute()
        {
            var worker = new RemoveHiddenElements();
            var data = new Dictionary<string, string>
            {
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"/></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"/></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path display=\"none\" d=\"M5.05.01c.81 2.17.41\"/></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><g display=\"none\"><path d=\"M5.05.01c.81 2.17.41\"/><path d=\"M5.05.01c.81 2.17.41\"/></g></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path display=\"none\" d=\"M5.05.01c.81 2.17.41\"/><path display=\"none\" d=\"M5.05.01c.81 2.17.41\"/></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path display=\"none\" d=\"M5.05.01c.81 2.17.41\"/><path visibility=\"hidden\" d=\"M5.05.01c.81 2.17.41\"/></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><circle r=\"0\" /><path d=\"M5.05.01c.81 2.17.41\"/></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"/></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><rect width=\"0\" /><path d=\"M5.05.01c.81 2.17.41\"/></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"/></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><rect height=\"0\" /><path d=\"M5.05.01c.81 2.17.41\"/></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"/></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><rect height=\"0\" /><circle r=\"0\" /><path d=\"M5.05.01c.81 2.17.41\"/></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"/></svg>" },
            };
            foreach (var input in data.Keys)
            {
                Assert.AreEqual(data[input], worker.Work(input));
            }
        }
    }
}
