using System;
using System.IO;
using NUnit.Framework;

namespace Recursion.Tests
{
    public class FileSystemTests
    {
        [Test]
        public void Walk()
        {
            var directory = new DirectoryInfo(Environment.CurrentDirectory);

            var projectFolder = directory.Parent.Parent.Parent.FullName;

            var results = FileSystem.Walk(projectFolder);

            Assert.Greater(results.Count, 100);
        }
    }
}
