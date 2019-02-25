using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SvgClean.Work;

namespace Test.WorkTests
{
    [TestClass]
    public class CollapseGroupsTest
    {
        [TestMethod]
        public void Execute()
        {
            var worker = new CollapseGroups();
            var data = new Dictionary<string, string>
            {
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"/></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"/></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><g></g><path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\" /></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"/></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><g> </g><path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\" /><g>  </g></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"/></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><g fill=\"blue\"><path /></g><path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"></path><g>  </g></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path fill=\"blue\"/><path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"/></svg>" },
                { "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><g fill=\"blue\"><g><path /></g></g><path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"></path><g>  </g></svg>", "<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 12 16\"><path fill=\"blue\"/><path d=\"M 10,30 A 20,20 0,0,1 50,30 A 20,20 0,0,1 90,30 Q 90,60 50,90 Q 10,60 10,30 z\"/></svg>" },

            };
            foreach (var input in data.Keys)
            {
                Assert.AreEqual(data[input], worker.Work(input));
            }
        }
    }
}
