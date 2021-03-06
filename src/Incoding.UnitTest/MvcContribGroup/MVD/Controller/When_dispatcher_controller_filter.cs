﻿namespace Incoding.UnitTest.MvcContribGroup
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Incoding.MvcContrib.MVD;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(DispatcherControllerBase))]
    public class When_dispatcher_controller_filter
    {
        #region Fake classes

        public class EB61C30C_4F25_4CDA_8625_8E3BBA8D4521 { }

        public class FakeDispatcher : DispatcherControllerBase
        {
            #region Constructors

            public FakeDispatcher()
                    : base(typeof(FakeDispatcher).Assembly, type => type.Name == "EB61C30C_4F25_4CDA_8625_8E3BBA8D4521") { }

            #endregion
        }

        #endregion

        #region Establish value

        static FakeDispatcher controller;

        static List<Type> types;

        #endregion

        Establish establish = () =>
                                  {
                                      typeof(DispatcherControllerBase).GetField("types", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, new List<Type>());
                                      controller = new FakeDispatcher();
                                  };

        Because of = () => { types = typeof(DispatcherControllerBase).GetField("types", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) as List<Type>; };

        It should_be_init = () =>
                                {
                                    types.Count.ShouldEqual(27);
                                    types.First().ShouldEqual(typeof(EB61C30C_4F25_4CDA_8625_8E3BBA8D4521));
                                };
    }
}