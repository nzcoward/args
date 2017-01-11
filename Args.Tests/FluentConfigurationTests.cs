using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;


namespace Args.Tests
{
    [TestFixture]
    public class FluentConfigurationTests
    {        
        #region Model Under Test
        public class SimpleTestModel
        {
            public string Name { get; set; }
            public int Id;
            public string FileName { get; set; }
        }
        #endregion

        [Test]
        public void SimpleModelFluentTest()
        {
            var m = new ModelBindingDefinition<SimpleTestModel>()
            .AsFluent().UsingStringComparer(StringComparer.CurrentCulture)
            .ParsesArgumentsWith(typeof(int), new System.ComponentModel.Int16Converter())
            .HasFirstOrdinalArgumentOf(a => a.FileName)
            .ForMember(a => a.Name)
                .WatchesFor("name", "nam")
            .ForMember(a => a.Id)
                .WatchesFor("id")
                .HasHelpTextOf("Hello World")
            .ForModel()
            .UsingSwitchDelimiter("--")
            .Initialize();

            m.GetOrdinalArguments().Count().Should().Be(1);
            m.GetOrdinalArguments().Should().Contain(m.Members.GetMemberBindingDefinitionFor(a => a.FileName).MemberInfo);
            m.SwitchDelimiter.Should().Be("--");
            m.TypeConverters.Count.Should().Be(1);
            m.TypeConverters.ContainsKey(typeof(int));
            m.TypeConverters[typeof(int)].Should().BeOfType<System.ComponentModel.Int16Converter>();

            var member = m.Members.GetMemberBindingDefinitionFor(a => a.Id);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.TypeConverter.Should().BeNull();
            member.SwitchValues.Count().Should().Be(1);
            member.CanHandleSwitch("id").Should().BeTrue();
            member.HelpText.Should().Be("Hello World");

            member = m.Members.GetMemberBindingDefinitionFor(a => a.Name);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.TypeConverter.Should().BeNull();
            member.SwitchValues.Count().Should().Be(2);

            member.CanHandleSwitch("NAM").Should().BeFalse();

            member.CanHandleSwitch("nAmE").Should().BeFalse();
            member.CanHandleSwitch("nam").Should().BeTrue();
            member.CanHandleSwitch("name").Should().BeTrue();
            member.HelpText.Should().BeNull();

            member = m.Members.GetMemberBindingDefinitionFor(a => a.FileName);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.TypeConverter.Should().BeNull();
            member.SwitchValues.Should().BeEmpty();
            member.HelpText.Should().BeNull();
        }
    }
}
