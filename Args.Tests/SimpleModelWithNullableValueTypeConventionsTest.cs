﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FluentAssertions;


namespace Args.Tests
{
    [TestFixture]
    public class SimpleModelWithNullableValueTypeConventionsTest
    {
        #region Model Under Test
        [ArgsModel(StringComparison = StringComparison.CurrentCulture, SwitchDelimiter = "-")]
        public class ModelWithNullableProperty
        {
            public Guid? Id { get; set; }
        }
        #endregion

        [Test]
        public void DecoratedModelTest()
        {
            var m = Configuration.Configure<ModelWithNullableProperty>(new ConventionBasedModelDefinitionInitializer());

            m.GetOrdinalArguments().Should().BeEmpty();
            m.StringComparer.Should().Be(StringComparer.CurrentCulture);
            m.SwitchDelimiter.Should().Be("-");

            var member = m.Members.GetMemberBindingDefinitionFor(a => a.Id);
            member.DefaultValue.Should().BeNull();
            member.Parent.Should().Be(m);
            member.SwitchValues.Count().Should().Be(2);
            member.CanHandleSwitch("I").Should().BeTrue();
            member.CanHandleSwitch("i").Should().BeFalse();
            member.CanHandleSwitch("Id").Should().BeTrue();
            member.TypeConverter.Should().BeNull();
            member.HelpText.Should().BeNull();
        }        
    }
}
