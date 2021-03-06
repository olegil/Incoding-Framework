﻿namespace Incoding.UnitTest.MvcContribGroup
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Incoding.MvcContrib.MVD;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(DispatcherControllerBase))]
    public class When_dispatcher_controller_duplicate
    {
        #region Fake classes

        public class FakeDispatcher : DispatcherControllerBase
        {
            #region Constructors

            public FakeDispatcher()
                    : base(typeof(FakeDispatcher).Assembly, type => type.Name == "AmbiguousType") { }

            #endregion
        }

        #endregion

        #region Establish value

        static FakeDispatcher controller;

        static List<Type> duplicates;

        #endregion

        Establish establish = () =>
                                  {
                                      typeof(DispatcherControllerBase).GetField("types", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, new List<Type>());
                                      typeof(DispatcherControllerBase).GetField("duplicates", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, new List<Type>());
                                      controller = new FakeDispatcher();
                                  };

        Because of = () => { duplicates = typeof(DispatcherControllerBase).GetField("duplicates", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null) as List<Type>; };

        It should_be_duplicate = () => duplicates.Count.ShouldEqual(2);
    }
}