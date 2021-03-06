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
    public class When_base_dispatcher_controller_query_to_file_by_full_name : Context_dispatcher_controller
    {
        #region Fake classes

        public class FakeFileByFullNameQuery<T> : QueryBase<byte[]>
        {
            ////ncrunch: no coverage start
            protected override byte[] ExecuteResult()
            {
                throw new NotImplementedException();
            }

            ////ncrunch: no coverage end        
        }

        #endregion

        #region Establish value

        static byte[] content;

        static string contentType;

        static string fileName;

        #endregion

        Establish establish = () =>
                                  {
                                      Establish(types: new[] { typeof(FakeFileByFullNameQuery<>) });
                                      content = Pleasure.Generator.Bytes();
                                      contentType = Pleasure.Generator.String();
                                      fileName = Pleasure.Generator.String();

                                      dispatcher.StubQuery(new FakeFileByFullNameQuery<string>(), content);
                                  };

        Because of = () =>
                         {
                             {
                                 result = controller.QueryToFile(HttpUtility.UrlEncode(typeof(FakeFileByFullNameQuery<>).FullName), typeof(string).FullName, contentType, fileName);
                             }

                             ;
                         };

        It should_be_result = () => result.ShouldBeFileContent(content, 
                                                               contentType: contentType, 
                                                               fileDownloadName: fileName);
    }
}