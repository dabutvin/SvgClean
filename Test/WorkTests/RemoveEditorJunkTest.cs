using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SvgClean.Work;

namespace Test.WorkTests
{
    [TestClass]
    public class RemoveEditorJunkTest
    {
        [TestMethod]
        public void Execute()
        {
            var worker = new RemoveEditorJunk();
            var data = new Dictionary<string, string>
            {
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\" inkscape:window-y=\"25\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><sodipodi:namedview inkscape:window-maximized=\"0\"></sodipodi:namedview><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><sodipodi:namedview /><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><inkscape:namedview /><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
            };
            foreach (var input in data.Keys)
            {
                Assert.AreEqual(data[input], worker.Work(input));
            }
        }
    }
}
