namespace Incoding.UnitTest.MvcContribGroup
{
    #region << Using >>

    using Incoding.MvcContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(IIncodingMetaLanguageEventBuilderDsl))]
    public class When_incoding_meta_language_dsl_on
    {
        It should_be_on_success = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                .Direct()
                                                .OnSuccess(r => r.Self().Core().Form.Validation.Parse())
                                                .GetExecutable<ExecutableValidationParse>()
                                                ["onStatus"].ShouldEqual(2);

        It should_be_on_before = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                               .Direct()
                                               .OnBegin(r => r.Self().Core().Form.Validation.Parse())
                                               .GetExecutable<ExecutableValidationParse>()
                                               ["onStatus"].ShouldEqual(1);

        It should_be_on_error = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                              .Direct()
                                              .OnError(r => r.Self().Core().Form.Validation.Parse())
                                              .GetExecutable<ExecutableValidationParse>()
                                              ["onStatus"].ShouldEqual(3);

        It should_be_on_complete = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                 .Direct()
                                                 .OnComplete(r => r.Self().Core().Form.Validation.Parse())
                                                 .GetExecutable<ExecutableValidationParse>()
                                                 ["onStatus"].ShouldEqual(4);

        It should_be_on_break = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                              .Direct()
                                              .OnBreak(r => r.Self().Core().Form.Validation.Parse())
                                              .GetExecutable<ExecutableValidationParse>()
                                              ["onStatus"].ShouldEqual(5);
    }
}