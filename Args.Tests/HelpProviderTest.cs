﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Args.Help;
using FluentAssertions;


namespace Args.Tests
{
    [TestFixture]
    public class HelpProviderTest
    {
        #region Model Under Test
        [ArgsModel(SwitchDelimiter = "//")]
        [SimpleResourceMemberHelp("This is my console application")]
        public class HelpClassTest
        {
            [System.ComponentModel.Description("This is the Id")]
            public int Id { get; set; }

            [System.ComponentModel.Description("This is the name you should put in.")]
            public string Name { get; set; }

            [System.ComponentModel.Description("Force it!")]
            public bool Switch { get; set; }

            [System.ComponentModel.Description("Effective date")]
            [ArgsMemberSwitch(0)]
            public DateTime Date { get; set; }


        }
        #endregion

        [Test]
        public void VerifyHelpData()
        {
            var config = Configuration.Configure<HelpClassTest>();
            var help = new HelpProvider();

            var result = help.GenerateModelHelp(config);

            result.SwitchDelimiter.Should().Be("//");
            result.Members.Count().Should().Be(4);
            result.HelpText.Should().Be("This is my console application");

            var m = result.Members.Where(h => h.Name == "Id").Single();
            m.HelpText.Should().Be("This is the Id");
            m.OrdinalIndex.Should().Be(default(int?));
            m.Switches.Should().BeEquivalentTo(new[] { "Id", "I" });

            m = result.Members.Where(h => h.Name == "Name").Single();
            m.HelpText.Should().Be("This is the name you should put in.");
            m.OrdinalIndex.Should().Be(default(int?));
            m.Switches.Should().BeEquivalentTo(new[] { "Name", "N" });

            m = result.Members.Where(h => h.Name == "Switch").Single();
            m.HelpText.Should().Be("Force it!");
            m.OrdinalIndex.Should().Be(default(int?));
            m.Switches.Should().BeEquivalentTo(new[] { "Switch", "S" });

            m = result.Members.Where(h => h.Name == "Date").Single();
            m.HelpText.Should().Be("Effective date");
            m.OrdinalIndex.Should().Be(0);
            m.Switches.Should().BeEmpty();
        }
    }
}
