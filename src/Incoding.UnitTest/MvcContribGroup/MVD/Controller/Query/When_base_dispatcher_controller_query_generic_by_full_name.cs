﻿namespace Incoding.UnitTest.MvcContribGroup
{
    #region << Using >>

    using System;
    using System.Web;
    using Incoding.CQRS;
    using Incoding.MSpecContrib;
    using Incoding.MvcContrib.MVD;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(DispatcherControllerBase))]
    public class When_base_dispatcher_controller_query_generic_by_full_name : Context_dispatcher_controller
    {
        #region Fake classes

        public class FakeGenericByFullNameGQuery<T> : QueryBase<T>
        {
            ////ncrunch: no coverage start
            protected override T ExecuteResult()
            {
                throw new NotImplementedException();
            }

            ////ncrunch: no coverage end        
        }

        #endregion

        #region Establish value

        static string queryResult;

        #endregion

        Establish establish = () =>
                                  {
                                      Establish(types: new[] { typeof(FakeGenericByFullNameGQuery<string>) });
                                      queryResult = Pleasure.Generator.String();
                                      dispatcher.StubQuery(new FakeGenericByFullNameGQuery<string>(), queryResult);
                                  };

        Because of = () => { result = controller.Query(HttpUtility.UrlEncode(typeof(FakeGenericByFullNameGQuery<>).FullName), HttpUtility.UrlEncode(typeof(string).FullName), false); };

        It should_be_result = () => result.ShouldBeIncodingSuccess<string>(s => s.ShouldEqual(queryResult));
    }
}