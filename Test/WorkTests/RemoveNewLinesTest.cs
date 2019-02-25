using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SvgClean.Work;

namespace Test.WorkTests
{
    [TestClass]
    public class RemoveNewLinesTest
    {
        [TestMethod]
        public void Execute()
        {
            var worker = new RemoveNewLines();
            var data = new Dictionary<string, string>
            {
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"></path></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"></path></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\">\n<path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\">\n</path>\n</svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"> <path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"> </path> </svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\">\r\n<path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\">\r\n</path>\r\n</svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"> <path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"> </path> </svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\"\nviewBox=\"0 0 12 16\"><path\n d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\">\n</path>\n</svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path  d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"> </path> </svg>" },
            };
            foreach (var input in data.Keys)
            {
                Assert.AreEqual(data[input], worker.Work(input));
            }
        }
    }
}
