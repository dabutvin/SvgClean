using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SvgClean.Work;

namespace Test.WorkTests
{
    [TestClass]
    public class TrimAttributesTest
    {
        [TestMethod]
        public void Execute()
        {
            var worker = new TrimAttributes();
            var data = new Dictionary<string, string>
            {
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
                { "<svg extra=\"\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg  xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
                { "<svg extra=\"\"xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
                { "<svg extra=\"  \" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg  xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
                { "<svg extra=\"  \"xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg  \" viewBox=\"  0 0 12 16    \"><path d=\"M5.05.01c.81 2.17.41 \"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\"></path></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\" id=\"one\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M5.05.01c.81 2.17.41\" id=\"one\"></path></svg>" },
            };

            foreach (var input in data.Keys)
            {
                Assert.AreEqual(data[input], worker.Work(input));
            }
        }
    }
}
