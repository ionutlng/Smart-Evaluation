#pragma checksum "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8455e7e5df204e38942f7953b2252376b09912c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Exams_PrepareExam), @"mvc.1.0.view", @"/Views/Exams/PrepareExam.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Exams/PrepareExam.cshtml", typeof(AspNetCore.Views_Exams_PrepareExam))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\_ViewImports.cshtml"
using Evaluation;

#line default
#line hidden
#line 2 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\_ViewImports.cshtml"
using Evaluation.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8455e7e5df204e38942f7953b2252376b09912c", @"/Views/Exams/PrepareExam.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6378dea9b0d83fb44c1b6e610a063aa21d8f68bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Exams_PrepareExam : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Evaluation.ViewModels.QuestionCourse>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
  
    ViewData["Title"] = "PrepareExam";

#line default
#line hidden
            BeginContext(107, 35, true);
            WriteLiteral("\r\n<h2>PrepareExam</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(142, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b1f548bb8f7140579432c264237250b8", async() => {
                BeginContext(165, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(179, 10, true);
            WriteLiteral("\r\n</p>\r\n\r\n");
            EndContext();
#line 13 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
  
    var questionList = (List<Question>)ViewData["MyData"];

#line default
#line hidden
            BeginContext(256, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 17 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
 foreach(var c in questionList)
{
    

#line default
#line hidden
            BeginContext(299, 20, false);
#line 19 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
Write(Html.Label(c.Answer));

#line default
#line hidden
            EndContext();
#line 19 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
                         ;
}

#line default
#line hidden
            BeginContext(325, 86, true);
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(412, 40, false);
#line 26 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
           Write(Html.DisplayNameFor(model => model.Text));

#line default
#line hidden
            EndContext();
            BeginContext(452, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(508, 42, false);
#line 29 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
           Write(Html.DisplayNameFor(model => model.Answer));

#line default
#line hidden
            EndContext();
            BeginContext(550, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 35 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(685, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(746, 39, false);
#line 39 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
               Write(Html.DisplayFor(modelItem => item.Text));

#line default
#line hidden
            EndContext();
            BeginContext(785, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(853, 41, false);
#line 42 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
               Write(Html.DisplayFor(modelItem => item.Answer));

#line default
#line hidden
            EndContext();
            BeginContext(894, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(962, 65, false);
#line 45 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
               Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1027, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(1052, 71, false);
#line 46 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
               Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1123, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(1148, 69, false);
#line 47 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
               Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1217, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 50 "C:\Users\ionut\Desktop\Evaluation\Evaluation\Views\Exams\PrepareExam.cshtml"
        }

#line default
#line hidden
            BeginContext(1272, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Evaluation.ViewModels.QuestionCourse>> Html { get; private set; }
    }
}
#pragma warning restore 1591
