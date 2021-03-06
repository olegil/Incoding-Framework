﻿namespace Incoding.UnitTest.MvcContribGroup
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Reflection;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Incoding.Block.IoC;
    using Incoding.CQRS;
    using Incoding.Extensions;
    using Incoding.Maybe;
    using Incoding.MSpecContrib;
    using Incoding.MvcContrib.MVD;
    using Moq;

    #endregion

    public class Context_dispatcher_controller
    {
        #region Fake classes

        public class FakeDispatcher : DispatcherControllerBase
        {
            #region Constructors

            public FakeDispatcher()
                    : base(new[] { typeof(Context_dispatcher_controller).Assembly }) { }

            #endregion
        }

        #endregion

        #region Establish value

        protected static FakeDispatcher controller;

        protected static Mock<IDispatcher> dispatcher;

        protected static ActionResult result;

        #endregion

        protected static void Establish(Type[] types = null, bool isAjax = true)
        {
            typeof(DispatcherControllerBase).GetField("types", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, new List<Type>());

            dispatcher = Pleasure.Mock<IDispatcher>();
            IoCFactory.Instance.StubTryResolve(dispatcher.Object);
            controller = new FakeDispatcher();

            var requestBase = Pleasure.MockAsObject<HttpRequestBase>(mock =>
                                                                         {
                                                                             if (isAjax)
                                                                                 mock.SetupGet(r => r.Headers).Returns(new NameValueCollection { { "X-Requested-With", "XMLHttpRequest" } });

                                                                             mock.SetupGet(r => r.Form).Returns(new NameValueCollection()
                                                                                                                    {
                                                                                                                            { "[0].Name", "Value" },
                                                                                                                            { "[1].Name", "Value" },
                                                                                                                    });
                                                                         });
            controller.ControllerContext = new ControllerContext(Pleasure.MockStrictAsObject<HttpContextBase>(mock => mock.SetupGet(r => r.Request).Returns(requestBase)), new RouteData(), controller);
            controller.ValueProvider = Pleasure.MockStrictAsObject<IValueProvider>(mock => mock.Setup(r => r.GetValue(Pleasure.MockIt.IsAny<string>())).Returns(new ValueProviderResult(string.Empty, string.Empty, Thread.CurrentThread.CurrentCulture)));

            var modelBinderDictionary = new ModelBinderDictionary();
            var modelBinder = Pleasure.MockAsObject<IModelBinder>(mock => mock.Setup(r => r.BindModel(Pleasure.MockIt.IsAny<ControllerContext>(),
                                                                                                      Pleasure.MockIt.IsAny<ModelBindingContext>())));
            foreach (var type in types.Recovery(new Type[] { }))
                modelBinderDictionary.Add(type, modelBinder);
            controller.SetValue("Binders", modelBinderDictionary);
        }
    }
}