using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;


namespace Args.Tests
{
    [TestFixture]
    public class SimpleModelConventionsTest
    {
        #region Model Under Test

        public class SimpleModelClass
        {
            [ArgsMemberSwitch(0)]
            public string Name { get; set; }

            [ArgsMemberSwitch("sd")]
            public DateTime StartDate { get; set; }

            [System.ComponentModel.Description("Forces the command")]
            public bool Force { get; set; }

            [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.GuidConverter))]
            public Guid Id { get; set; }

            [System.ComponentModel.TypeConverter("System.ComponentModel.Int32Converter, System.ComponentModel.TypeConverter, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
            public int Number { get; set; }

            public decimal Amount { get; set; }

            public float Angle { get; set; }

            public double PrecisionAngle { get; set; }

            [System.ComponentModel.DefaultValue(88888888888)]
            public long BigNumber { get; set; }

            [ArgsTypeConverterAttribute(typeof(SimpleConverter))]
            public int ConverterProperty { get; set; }
        }
        #endregion

        [Test]
        public void BasicConventionsTest()
        {
            var m = Configuration.Configure<SimpleModelClass>(new ConventionBasedModelDefinitionInitializer());

            m.GetOrdinalArguments().Count().Should().Be(1);
            m.GetOrdinalArguments().Should().Contain(m.Members.GetMemberBindingDefinitionFor(a => a.Name).MemberInfo);
            m.StringComparer.Should().Be(StringComparer.CurrentCultureIgnoreCase);
            m.SwitchDelimiter.Should().Be("/");
            m.TypeConverters.Should().BeEmpty();

            var member = m.Members.GetMemberBindingDefinitionFor(a => a.Amount);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("am").Should().BeTrue();
            member.CanHandleSwitch("amount").Should().BeTrue();
            member.TypeConverter.Should().BeNull();
            member.HelpText.Should().BeNull();

            member = m.Members.GetMemberBindingDefinitionFor(a => a.Angle);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("an").Should().BeTrue();
            member.CanHandleSwitch("angle").Should().BeTrue();
            member.TypeConverter.Should().BeNull();
            member.HelpText.Should().BeNull();

            member = m.Members.GetMemberBindingDefinitionFor(a => a.BigNumber);
            member.DefaultValue.Should().Be(88888888888);
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("b").Should().BeTrue();
            member.CanHandleSwitch("bignumber").Should().BeTrue();
            member.TypeConverter.Should().BeNull();
            member.HelpText.Should().BeNull();

            member = m.Members.GetMemberBindingDefinitionFor(a => a.Force);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("f").Should().BeTrue();
            member.CanHandleSwitch("force").Should().BeTrue();
            member.TypeConverter.Should().BeNull();
            member.HelpText.Should().Be("Forces the command");

            member = m.Members.GetMemberBindingDefinitionFor(a => a.Id);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("i").Should().BeTrue();
            member.CanHandleSwitch("id").Should().BeTrue();
            member.TypeConverter.Should().BeOfType<System.ComponentModel.GuidConverter>();
            member.HelpText.Should().BeNull();

            member = m.Members.GetMemberBindingDefinitionFor(a => a.Name);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Should().BeEmpty();
            member.TypeConverter.Should().BeNull();
            member.HelpText.Should().BeNull();

            member = m.Members.GetMemberBindingDefinitionFor(a => a.Number);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("nu").Should().BeTrue();
            member.CanHandleSwitch("number").Should().BeTrue();
            member.TypeConverter.Should().BeOfType<System.ComponentModel.Int32Converter>();
            member.HelpText.Should().BeNull();

            member = m.Members.GetMemberBindingDefinitionFor(a => a.PrecisionAngle);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("p").Should().BeTrue();
            member.CanHandleSwitch("P").Should().BeTrue();
            member.CanHandleSwitch("precisionangle").Should().BeTrue();
            member.CanHandleSwitch("pReCiSionAnGlE").Should().BeTrue();
            member.TypeConverter.Should().BeNull();
            member.HelpText.Should().BeNull();

            member = m.Members.GetMemberBindingDefinitionFor(a => a.StartDate);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(1);
            member.CanHandleSwitch("sd").Should().BeTrue();
            member.CanHandleSwitch("SD").Should().BeTrue();
            member.TypeConverter.Should().BeNull();
            member.HelpText.Should().BeNull();

            member = m.Members.GetMemberBindingDefinitionFor(a => a.ConverterProperty);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("c").Should().BeTrue();
            member.CanHandleSwitch("converterproperty").Should().BeTrue();
            member.TypeConverter.Should().NotBeNull();
            (member.TypeConverter as ArgsTypeConverter).Converter.GetType().Should().Be<SimpleConverter>();
            member.HelpText.Should().BeNull();
        }
    }
}
