namespace Incoding.UnitTest.MvcContribGroup
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Net;
    using System.Web.WebPages;
    using Incoding.MSpecContrib;
    using Incoding.MvcContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(IncodingMetaCallbackJqueryDsl))]
    public class When_incoding_meta_language_dsl_jquery
    {
        #region Establish value

        static Selector value = Selector.Value("Value");

        #endregion

        #region Attributes

        
        It should_be_set_attr = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                              .Do().Direct()
                                              .OnSuccess(dsl => dsl.Self().Core().JQuery.Attributes.SetAttr(HtmlAttribute.Href, value))
                                              .GetExecutable<ExecutableEvalMethod>()
                                              .ShouldEqualData(new Dictionary<string, object>
                                                                   {
                                                                           { "method", "attr" },
                                                                           { "args", new[] { "href", "Value" } },
                                                                           { "context", "$(this.target)" }
                                                                   });

        It should_be_set_attr_without_value = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                            .Do().Direct()
                                                            .OnSuccess(dsl => dsl.Self().Core().JQuery.Attributes.SetAttr(HtmlAttribute.Href))
                                                            .GetExecutable<ExecutableEvalMethod>()
                                                            .ShouldEqualData(new Dictionary<string, object>
                                                                                 {
                                                                                         { "method", "attr" },
                                                                                         { "args", new[] { "href", "href" } },
                                                                                         { "context", "$(this.target)" }
                                                                                 });

        It should_be_remove_attr = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                 .Do().Direct()
                                                 .OnSuccess(dsl => dsl.Self().Core().JQuery.Attributes.RemoveAttr(HtmlAttribute.Href | HtmlAttribute.Accept))
                                                 .GetExecutable<ExecutableEvalMethod>()
                                                 .ShouldEqualData(new Dictionary<string, object>
                                                                      {
                                                                              { "method", "removeAttr" },
                                                                              { "args", new[] { "accept href" } },
                                                                              { "context", "$(this.target)" }
                                                                      });

        It should_be_remove_prop = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                 .Do().Direct()
                                                 .OnSuccess(dsl => dsl.Self().Core().JQuery.Attributes.RemoveProp(HtmlAttribute.Href))
                                                 .GetExecutable<ExecutableEvalMethod>()
                                                 .ShouldEqualData(new Dictionary<string, object>
                                                                      {
                                                                              { "method", "removeProp" },
                                                                              { "args", new[] { "href" } },
                                                                              { "context", "$(this.target)" }
                                                                      });

        It should_be_set_prop = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                              .Do().Direct()
                                              .OnSuccess(dsl => dsl.Self().Core().JQuery.Attributes.SetProp(HtmlAttribute.Href, value))
                                              .GetExecutable<ExecutableEvalMethod>()
                                              .ShouldEqualData(new Dictionary<string, object>
                                                                   {
                                                                           { "method", "prop" },
                                                                           { "args", new[] { "href", "Value" } },
                                                                           { "context", "$(this.target)" }
                                                                   });

        It should_be_set_prop_without_value = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                            .Do().Direct()
                                                            .OnSuccess(dsl => dsl.Self().Core().JQuery.Attributes.SetProp(HtmlAttribute.Href))
                                                            .GetExecutable<ExecutableEvalMethod>()
                                                            .ShouldEqualData(new Dictionary<string, object>
                                                                                 {
                                                                                         { "method", "prop" },
                                                                                         { "args", new[] { "href", "href" } },
                                                                                         { "context", "$(this.target)" }
                                                                                 });

        It should_be_set_prop_with_empty_value = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                               .Do().Direct()
                                                               .OnSuccess(dsl => dsl.Self().Core().JQuery.Attributes.SetProp(HtmlAttribute.Href, string.Empty))
                                                               .GetExecutable<ExecutableEvalMethod>()
                                                               .ShouldEqualData(new Dictionary<string, object>
                                                                                    {
                                                                                            { "method", "prop" },
                                                                                            { "args", new[] { "href", string.Empty } },
                                                                                            { "context", "$(this.target)" }
                                                                                    });

        It should_be_remove_class = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                  .Do().Direct()
                                                  .OnSuccess(r => r.Self().Core().JQuery.Attributes.RemoveClass("class"))
                                                  .GetExecutable<ExecutableEvalMethod>()
                                                  .ShouldEqualData(new Dictionary<string, object>
                                                                       {
                                                                               { "method", "removeClass" },
                                                                               { "args", new[] { "class" } },
                                                                               { "context", "$(this.target)" }
                                                                       });

        It should_be_toggle_class = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                  .Do().Direct()
                                                  .OnSuccess(r => r.Self().Core().JQuery.Attributes.ToggleClass("class"))
                                                  .GetExecutable<ExecutableEvalMethod>()
                                                  .ShouldEqualData(new Dictionary<string, object>
                                                                       {
                                                                               { "method", "toggleClass" },
                                                                               { "args", new[] { "class" } },
                                                                               { "context", "$(this.target)" }
                                                                       });

        It should_be_toggle_disabled = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                     .Do().Direct()
                                                     .OnSuccess(r => r.Self().Core().JQuery.Attributes.ToggleDisabled())
                                                     .GetExecutable<ExecutableEvalMethod>()
                                                     .ShouldEqualData(new Dictionary<string, object>
                                                                          {
                                                                                  { "method", "toggleProp" },
                                                                                  { "args", new[] { "disabled" } },
                                                                                  { "context", "$(this.target)" }
                                                                          });

        It should_be_toggle_readonly = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                     .Do().Direct()
                                                     .OnSuccess(r => r.Self().Core().JQuery.Attributes.ToggleReadonly())
                                                     .GetExecutable<ExecutableEvalMethod>()
                                                     .ShouldEqualData(new Dictionary<string, object>
                                                                          {
                                                                                  { "method", "toggleProp" },
                                                                                  { "args", new[] { "readonly" } },
                                                                                  { "context", "$(this.target)" }
                                                                          });

        It should_be_toggle_checked = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                    .Do().Direct()
                                                    .OnSuccess(r => r.Self().Core().JQuery.Attributes.ToggleChecked())
                                                    .GetExecutable<ExecutableEvalMethod>()
                                                    .ShouldEqualData(new Dictionary<string, object>
                                                                         {
                                                                                 { "method", "toggleProp" },
                                                                                 { "args", new[] { "checked" } },
                                                                                 { "context", "$(this.target)" }
                                                                         });

        It should_be_add_class = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                               .Do().Direct()
                                               .OnSuccess(r => r.Self().Core().JQuery.Attributes.AddClass("class"))
                                               .GetExecutable<ExecutableEvalMethod>()
                                               .ShouldEqualData(new Dictionary<string, object>
                                                                    {
                                                                            { "method", "addClass" },
                                                                            { "context", "$(this.target)" },
                                                                            { "args", new[] { "class" } }
                                                                    });

        It should_be_val_string = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                .Do().Direct()
                                                .OnSuccess(r => r.Self().Core().JQuery.Attributes.Val("aws"))
                                                .GetExecutable<ExecutableEval>()
                                                .ShouldEqualData(new Dictionary<string, object>
                                                                     {
                                                                             { "code", "$(this.target).val(\"aws\");" },
                                                                     });

        It should_be_val_null = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                              .Do().Direct()
                                              .OnSuccess(r => r.Self().Core().JQuery.Attributes.Val(null))
                                              .GetExecutable<ExecutableEvalMethod>()
                                              .ShouldEqualData(new Dictionary<string, object>
                                                                   {
                                                                           { "method", "val" },
                                                                           { "args", new[] { "" } },
                                                                           { "context", "$(this.target)" }
                                                                   });

        It should_be_val_selector = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                  .Do().Direct()
                                                  .OnSuccess(r => r.Self().Core().JQuery.Attributes.Val(Selector.Jquery.Class("class")))
                                                  .GetExecutable<ExecutableEvalMethod>()
                                                  .ShouldEqualData(new Dictionary<string, object>
                                                                       {
                                                                               { "method", "val" },
                                                                               { "args", new[] { "$('.class')" } },
                                                                               { "context", "$(this.target)" }
                                                                       });

        It should_be_val_selector_by_func = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                          .Do().Direct()
                                                          .OnSuccess(r => r.Self().Core().JQuery.Attributes.Val(selector => selector.Class("class")))
                                                          .GetExecutable<ExecutableEvalMethod>()
                                                          .ShouldEqualData(new Dictionary<string, object>
                                                                               {
                                                                                       { "method", "val" },
                                                                                       { "args", new[] { "$('.class')" } },
                                                                                       { "context", "$(this.target)" }
                                                                               });

        It should_be_val_array = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                               .Do().Direct()
                                               .OnSuccess(r => r.Self().Core().JQuery.Attributes.Val(Pleasure.ToArray("aws", "aws1")))
                                               .GetExecutable<ExecutableEval>()
                                               .ShouldEqualData(new Dictionary<string, object>
                                                                    {
                                                                            { "code", "$(this.target).val([\"aws\",\"aws1\"]);" }
                                                                    });

        #endregion

        #region Css

        It should_be_css_set = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                             .Do().Direct()
                                             .OnSuccess(dsl => dsl.Self().Core().JQuery.Css.Set(CssStyling.FontFamily, value))
                                             .GetExecutable<ExecutableEvalMethod>()
                                             .ShouldEqualData(new Dictionary<string, object>
                                                                  {
                                                                          { "method", "css" },
                                                                          { "args", new[] { "font-family", "Value" } },
                                                                          { "context", "$(this.target)" }
                                                                  });

        It should_be_css_set_empty = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                   .Do().Direct()
                                                   .OnSuccess(dsl => dsl.Self().Core().JQuery.Css.Set(CssStyling.Width, string.Empty))
                                                   .GetExecutable<ExecutableEvalMethod>()
                                                   .ShouldEqualData(new Dictionary<string, object>
                                                                        {
                                                                                { "method", "css" },
                                                                                { "args", new[] { "width", string.Empty } },
                                                                                { "context", "$(this.target)" }
                                                                        });

        It should_be_display = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                             .Do().Direct()
                                             .OnSuccess(dsl => dsl.Self().Core().JQuery.Css.Display(Display.TableCaption))
                                             .GetExecutable<ExecutableEvalMethod>()
                                             .ShouldEqualData(new Dictionary<string, object>
                                                                  {
                                                                          { "method", "css" },
                                                                          { "args", new[] { "display", "table-caption" } },
                                                                          { "context", "$(this.target)" }
                                                                  });

        It should_be_height = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                            .Do().Direct()
                                            .OnSuccess(dsl => dsl.Self().Core().JQuery.Css.Height(10))
                                            .GetExecutable<ExecutableEvalMethod>()
                                            .ShouldEqualData(new Dictionary<string, object>
                                                                 {
                                                                         { "method", "height" },
                                                                         { "args", new[] { "10" } },
                                                                         { "context", "$(this.target)" }
                                                                 });

        It should_be_scroll_left = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                 .Do().Direct()
                                                 .OnSuccess(dsl => dsl.Self().Core().JQuery.Css.ScrollLeft(25))
                                                 .GetExecutable<ExecutableEvalMethod>()
                                                 .ShouldEqualData(new Dictionary<string, object>
                                                                      {
                                                                              { "method", "scrollLeft" },
                                                                              { "args", new[] { "25" } },
                                                                              { "context", "$(this.target)" }
                                                                      });

        It should_be_scroll_top = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                .Do().Direct()
                                                .OnSuccess(dsl => dsl.Self().Core().JQuery.Css.ScrollTop(25))
                                                .GetExecutable<ExecutableEvalMethod>()
                                                .ShouldEqualData(new Dictionary<string, object>
                                                                     {
                                                                             { "method", "scrollTop" },
                                                                             { "args", new[] { "25" } },
                                                                             { "context", "$(this.target)" }
                                                                     });

        It should_be_width = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                           .Do().Direct()
                                           .OnSuccess(dsl => dsl.Self().Core().JQuery.Css.Width(25))
                                           .GetExecutable<ExecutableEvalMethod>()
                                           .ShouldEqualData(new Dictionary<string, object>
                                                                {
                                                                        { "method", "width" },
                                                                        { "args", new[] { "25" } },
                                                                        { "context", "$(this.target)" }
                                                                });

        #endregion

        #region Func

        It should_be_increment_with_selector = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                             .Do().Direct()
                                                             .OnSuccess(r => r.Self().Core().Func.IncrementVal(Selector.Jquery.Self()))
                                                             .GetExecutable<ExecutableEvalMethod>()
                                                             .ShouldEqualData(new Dictionary<string, object>
                                                                                  {
                                                                                          { "method", "increment" },
                                                                                          { "context", "$(this.target)" },
                                                                                          { "args", new[] { "$(this.self)" } },
                                                                                  });

        It should_be_increment = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                               .Do().Direct()
                                               .OnSuccess(r => r.Self().Core().Func.IncrementVal())
                                               .GetExecutable<ExecutableEvalMethod>()
                                               .ShouldEqualData(new Dictionary<string, object>
                                                                    {
                                                                            { "method", "increment" },
                                                                            { "context", "$(this.target)" },
                                                                            { "args", new[] { "1" } },
                                                                    });

        It should_be_decrement = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                               .Do().Direct()
                                               .OnSuccess(r => r.Self().Core().Func.DecrementVal())
                                               .GetExecutable<ExecutableEvalMethod>()
                                               .ShouldEqualData(new Dictionary<string, object>
                                                                    {
                                                                            { "method", "increment" },
                                                                            { "context", "$(this.target)" },
                                                                            { "args", new[] { "-1" } },
                                                                    });

        It should_be_jquery_plug_in = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                    .Do().Direct()
                                                    .OnSuccess(r => r.Self().Core().JQuery.PlugIn("MyPlugIn", new { position = "left", width = 15 }))
                                                    .GetExecutable<ExecutableEval>()
                                                    .ShouldEqualData(new Dictionary<string, object>
                                                                         {
                                                                                 { "code", @"$(this.target).MyPlugIn({""position"":""left"",""width"":15});" }
                                                                         });

        It should_be_jquery_call = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                 .Do().Direct()
                                                 .OnSuccess(r => r.Self().Core().JQuery.Call("Call", "15"))
                                                 .GetExecutable<ExecutableEvalMethod>()
                                                 .ShouldEqualData(new Dictionary<string, object>
                                                                      {
                                                                              { "method", @"Call" },
                                                                              { "args", new[] { "15" } },
                                                                              { "context", "$(this.target)" }
                                                                      });

        #endregion

        #region Manipilation

        It should_be_remove = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                            .Do().Direct()
                                            .OnSuccess(r => r.Self().Core().JQuery.Manipulation.Remove())
                                            .GetExecutable<ExecutableEvalMethod>()
                                            .ShouldEqualData(new Dictionary<string, object>
                                                                 {
                                                                         { "method", "remove" },
                                                                         { "args", new string[] { } },
                                                                         { "context", "$(this.target)" }
                                                                 });

        It should_be_empty = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                           .Do().Direct()
                                           .OnSuccess(r => r.Self().Core().JQuery.Manipulation.Empty())
                                           .GetExecutable<ExecutableEvalMethod>()
                                           .ShouldEqualData(new Dictionary<string, object>
                                                                {
                                                                        { "method", "empty" },
                                                                        { "args", new string[] { } },
                                                                        { "context", "$(this.target)" }
                                                                });

        It should_be_detach = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                            .Do().Direct()
                                            .OnSuccess(r => r.Self().Core().JQuery.Manipulation.Detach())
                                            .GetExecutable<ExecutableEvalMethod>()
                                            .ShouldEqualData(new Dictionary<string, object>
                                                                 {
                                                                         { "method", "detach" },
                                                                         { "args", new string[] { } },
                                                                         { "context", "$(this.target)" }
                                                                 });

        It should_be_wrap = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                          .Do().Direct()
                                          .OnSuccess(r => r.Self().Core().JQuery.Manipulation.Wrap(o => new HelperResult(writer => writer.WriteLine("<div>"))))
                                          .GetExecutable<ExecutableEvalMethod>()
                                          .ShouldEqualData(new Dictionary<string, object>
                                                               {
                                                                       { "method", "wrap" },
                                                                       { "args", new[] { "<div>" } },
                                                                       { "context", "$(this.target)" }
                                                               });

        It should_be_wrap_all = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                              .Do().Direct()
                                              .OnSuccess(r => r.Self().Core().JQuery.Manipulation.WrapAll(o => new HelperResult(writer => writer.WriteLine("<div>"))))
                                              .GetExecutable<ExecutableEvalMethod>()
                                              .ShouldEqualData(new Dictionary<string, object>
                                                                   {
                                                                           { "method", "wrapAll" },
                                                                           { "args", new[] { "<div>" } },
                                                                           { "context", "$(this.target)" }
                                                                   });

        It should_be_text_empty = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                .Do().Direct()
                                                .OnSuccess(r => r.Self().Core().JQuery.Manipulation.Text(string.Empty))
                                                .GetExecutable<ExecutableEvalMethod>()
                                                .ShouldEqualData(new Dictionary<string, object>
                                                                     {
                                                                             { "method", "text" },
                                                                             { "args", new[] { string.Empty } },
                                                                             { "context", "$(this.target)" }
                                                                     });

        It should_be_text = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                          .Do().Direct()
                                          .OnSuccess(r => r.Self().Core().JQuery.Manipulation.Text(o => new HelperResult(writer => writer.WriteLine("<div>"))))
                                          .GetExecutable<ExecutableEvalMethod>()
                                          .ShouldEqualData(new Dictionary<string, object>
                                                               {
                                                                       { "method", "text" },
                                                                       { "args", new[] { "<div>" } },
                                                                       { "context", "$(this.target)" }
                                                               });

        It should_be_append = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                            .Do().Direct()
                                            .OnSuccess(r => r.Self().Core().JQuery.Manipulation.Append(o => new HelperResult(writer => writer.WriteLine("<div>"))))
                                            .GetExecutable<ExecutableEvalMethod>()
                                            .ShouldEqualData(new Dictionary<string, object>
                                                                 {
                                                                         { "method", "append" },
                                                                         { "args", new[] { "<div>" } },
                                                                         { "context", "$(this.target)" }
                                                                 });

        It should_be_append_selector = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                     .Do().Direct()
                                                     .OnSuccess(r => r.Self().Core().JQuery.Manipulation.Append(Selector.JS.Location.Href))
                                                     .GetExecutable<ExecutableEvalMethod>()
                                                     .ShouldEqualData(new Dictionary<string, object>
                                                                          {
                                                                                  { "method", "append" },
                                                                                  { "args", new[] { "||javascript*window.location.href||" } },
                                                                                  { "context", "$(this.target)" }
                                                                          });

        It should_be_prepend = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                             .Do().Direct()
                                             .OnSuccess(r => r.Self().Core().JQuery.Manipulation.Prepend(o => new HelperResult(writer => writer.Write("<div>"))))
                                             .GetExecutable<ExecutableEvalMethod>()
                                             .ShouldEqualData(new Dictionary<string, object>
                                                                  {
                                                                          { "method", "prepend" },
                                                                          { "args", new[] { "<div>" } },
                                                                          { "context", "$(this.target)" }
                                                                  });

        It should_be_after = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                           .Do().Direct()
                                           .OnSuccess(r => r.Self().Core().JQuery.Manipulation.After(o => new HelperResult(writer => writer.Write("<div>"))))
                                           .GetExecutable<ExecutableEvalMethod>()
                                           .ShouldEqualData(new Dictionary<string, object>
                                                                {
                                                                        { "method", "after" },
                                                                        { "args", new[] { "<div>" } },
                                                                        { "context", "$(this.target)" }
                                                                });

        It should_be_before = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                            .Do().Direct()
                                            .OnSuccess(r => r.Self().Core().JQuery.Manipulation.Before(o => new HelperResult(writer => writer.Write("<div>"))))
                                            .GetExecutable<ExecutableEvalMethod>()
                                            .ShouldEqualData(new Dictionary<string, object>
                                                                 {
                                                                         { "method", "before" },
                                                                         { "args", new[] { "<div>" } },
                                                                         { "context", "$(this.target)" }
                                                                 });

        It should_be_html_string = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                 .Do().Direct()
                                                 .OnSuccess(r => r.Self().Core().JQuery.Manipulation.Html(o => new HelperResult(writer => writer.Write("<div>"))))
                                                 .GetExecutable<ExecutableEvalMethod>()
                                                 .ShouldEqualData(new Dictionary<string, object>
                                                                      {
                                                                              { "method", "html" },
                                                                              { "args", new[] { "<div>" } },
                                                                              { "context", "$(this.target)" }
                                                                      });

        It should_be_html_jquery_selector = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                          .Do().Direct()
                                                          .OnSuccess(r => r.Self().Core().JQuery.Manipulation.Html(Selector.Jquery.Id("id")))
                                                          .GetExecutable<ExecutableEvalMethod>()
                                                          .ShouldEqualData(new Dictionary<string, object>
                                                                               {
                                                                                       { "method", "html" },
                                                                                       { "args", new[] { "$('#id')" } },
                                                                                       { "context", "$(this.target)" }
                                                                               });

        It should_be_replace_with = () => new IncodingMetaLanguageDsl(JqueryBind.Click)
                                                  .Do().Direct()
                                                  .OnSuccess(r => r.Self().Core().JQuery.Manipulation.ReplaceWith(o => new HelperResult(writer => writer.Write("<div>"))))
                                                  .GetExecutable<ExecutableEvalMethod>()
                                                  .ShouldEqualData(new Dictionary<string, object>
                                                                       {
                                                                               { "method", "replaceWith" },
                                                                               { "args", new[] { "<div>" } },
                                                                               { "context", "$(this.target)" }
                                                                       });

        #endregion
    }
}