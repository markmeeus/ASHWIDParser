using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using ASWHIDParser;

namespace ASHWIDParserTest
{
    [TestClass]
    public class ASHWIDParserTest
    {
        [TestMethod]
        public void TestParsesSingleProcessorComponent()
        {
            var ar = new byte[4] { 1, 0, 201, 001 };
            var components = ASHWIDParser.ParseBytes(ar);            
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.Processor, components.First().Type);
            Assert.AreEqual(201, components.First().Value[0]);
            Assert.AreEqual(001, components.First().Value[1]);
        }
        
        [TestMethod]
        public void TestParsesSingleMemoryComponent()
        {
            var ar = new byte[4] { 2, 0, 202, 002 };
            var components = ASHWIDParser.ParseBytes(ar);
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.Memory, components.First().Type);
            Assert.AreEqual(202, components.First().Value[0]);
            Assert.AreEqual(002, components.First().Value[1]);
        }

        [TestMethod]
        public void TestParsesSingleDiskDeviceComponent()
        {
            var ar = new byte[4] { 3, 0, 203, 003 };
            var components = ASHWIDParser.ParseBytes(ar);
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.DiskDevice, components.First().Type);
            Assert.AreEqual(203, components.First().Value[0]);
            Assert.AreEqual(003, components.First().Value[1]);
        }

        [TestMethod]
        public void TestParsesSingleNetworkAdapterComponent()
        {
            var ar = new byte[4] { 4, 0, 204, 004 };
            var components = ASHWIDParser.ParseBytes(ar);
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.NetworkAdapter, components.First().Type);
            Assert.AreEqual(204, components.First().Value[0]);
            Assert.AreEqual(004, components.First().Value[1]);
        }

        [TestMethod]
        public void TestParsesSingleAudioAdapterComponent()
        {
            var ar = new byte[4] { 5, 0, 205, 005};
            var components = ASHWIDParser.ParseBytes(ar);
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.AudioAdapter, components.First().Type);
            Assert.AreEqual(205, components.First().Value[0]);
            Assert.AreEqual(005, components.First().Value[1]);
        }

        [TestMethod]
        public void TestParsesSingleDockingStationComponent()
        {
            var ar = new byte[4] { 6, 0, 206, 006 };
            var components = ASHWIDParser.ParseBytes(ar);
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.DockingStation, components.First().Type);
            Assert.AreEqual(206, components.First().Value[0]);
            Assert.AreEqual(006, components.First().Value[1]);
        }

        [TestMethod]
        public void TestParsesSingleMobileBroadBandComponent()
        {
            var ar = new byte[4] { 7, 0, 207, 007 };
            var components = ASHWIDParser.ParseBytes(ar);
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.MobileBroadBand, components.First().Type);
            Assert.AreEqual(207, components.First().Value[0]);
            Assert.AreEqual(007, components.First().Value[1]);
        }

        [TestMethod]
        public void TestParsesSingleBlueToothComponent()
        {
            var ar = new byte[4] { 8, 0, 208, 008 };
            var components = ASHWIDParser.ParseBytes(ar);
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.BlueTooth, components.First().Type);
            Assert.AreEqual(208, components.First().Value[0]);
            Assert.AreEqual(008, components.First().Value[1]);
        }

        [TestMethod]
        public void TestParsesSingleSystemBIOSComponent()
        {
            var ar = new byte[4] { 9, 0, 209, 009 };
            var components = ASHWIDParser.ParseBytes(ar);
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.SystemBIOS, components.First().Type);
            Assert.AreEqual(209, components.First().Value[0]);
            Assert.AreEqual(009, components.First().Value[1]);
        }

        [TestMethod]
        public void TestParsesMultipleItems()
        {
            var ar = new byte[8] { 1 , 0, 201, 001, 9, 0, 209, 009 };
            var components = ASHWIDParser.ParseBytes(ar);
            Assert.AreEqual(2, components.Count());
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.Processor, components[0].Type);
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.SystemBIOS, components[1].Type);
        }

        [TestMethod]
        public void TestParsesMultipleItemsOfSameType()
        {
            var ar = new byte[8] { 1, 0, 201, 001, 1, 0, 209, 009 };
            var components = ASHWIDParser.ParseBytes(ar);
            Assert.AreEqual(2, components.Count());
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.Processor, components[0].Type);
            Assert.AreEqual(ASHWIDParser.ASHWIDComponentType.Processor, components[1].Type);
        }        
    }
}
