using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;


namespace Args.Tests
{
    [TestFixture]
    public class ModelWithFieldsConventionsTest
    {
        #region Model Under Test
        public class SimpleModelClassUsingFields
        {
            public string Name;
            public DateTime StartDate;
            public bool Force;
            public Guid Id;
            public int Number;
            public decimal Amount;
            public float Angle;
            public double PrecisionAngle;
            public long BigNumber;
        }
        #endregion

        [Test]
        public void ModelTestWithFields()
        {
            var m = Configuration.Configure<SimpleModelClassUsingFields>(new ConventionBasedModelDefinitionInitializer());

            m.GetOrdinalArguments().Should().BeEmpty();
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
            member.DefaultValue.Should().BeNull();
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
            member.HelpText.Should().BeNull();

            member = m.Members.GetMemberBindingDefinitionFor(a => a.Id);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("i").Should().BeTrue();
            member.CanHandleSwitch("id").Should().BeTrue();
            member.TypeConverter.Should().BeNull();
            member.HelpText.Should().BeNull();

            member = m.Members.GetMemberBindingDefinitionFor(a => a.Name);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("na").Should().BeTrue();
            member.CanHandleSwitch("name").Should().BeTrue();
            member.TypeConverter.Should().BeNull();
            member.HelpText.Should().BeNull();

            member = m.Members.GetMemberBindingDefinitionFor(a => a.Number);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("nu").Should().BeTrue();
            member.CanHandleSwitch("number").Should().BeTrue();
            member.TypeConverter.Should().BeNull();
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
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("s").Should().BeTrue();
            member.CanHandleSwitch("Startdate").Should().BeTrue();
            member.TypeConverter.Should().BeNull();
            member.HelpText.Should().BeNull();
        }
    }
}
