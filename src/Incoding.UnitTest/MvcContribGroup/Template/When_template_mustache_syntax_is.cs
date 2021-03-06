namespace Incoding.UnitTest.MvcContribGroup
{
    #region << Using >>

    using Incoding.MvcContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(TemplateMustacheSyntax<>))]
    public class When_template_mustache_syntax_is : Context_template
    {
        Because of = () =>
                         {
                             var each = new TemplateMustacheSyntax<FakeModel>(htmlHelper.Original, "Data", true);
                             var newEach = each.Is(r => r.Name);
                             newEach.Dispose();
                         };

        It should_be_writer_start_not = () => htmlHelper.ShouldBeWriter("{{#Name}}");

        It should_be_writer_end_not = () => htmlHelper.ShouldBeWriter("{{/Name}}");
    }
}