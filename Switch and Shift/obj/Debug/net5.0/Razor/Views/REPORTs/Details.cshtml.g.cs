#pragma checksum "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "cb6ade6cb1bbc1f6ce81c70ab1cd9d15a0d3ab189202a83fb64b96dfe01c3b25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_REPORTs_Details), @"mvc.1.0.view", @"/Views/REPORTs/Details.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Switch_And_Shift-master\Switch and Shift\Views\_ViewImports.cshtml"
using Switch_and_Shift

#nullable disable
    ;
#nullable restore
#line 2 "D:\Switch_And_Shift-master\Switch and Shift\Views\_ViewImports.cshtml"
using Switch_and_Shift.Models

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"cb6ade6cb1bbc1f6ce81c70ab1cd9d15a0d3ab189202a83fb64b96dfe01c3b25", @"/Views/REPORTs/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"d6bef1b58392662014ef458f51ddf9d8e60930db70f7710e0078945ee85e61a2", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_REPORTs_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Switch_and_Shift.Models.REPORT>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable

            WriteLiteral("\n<h1>Details</h1>\n\n<div>\n    <h4>REPORT</h4>\n    <hr />\n    <dl class=\"row\">\n        <dt class = \"col-sm-2\">\n            ");
            Write(
#nullable restore
#line 14 "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml"
             Html.DisplayNameFor(model => model.product_model)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
            Write(
#nullable restore
#line 17 "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml"
             Html.DisplayFor(model => model.product_model)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
            Write(
#nullable restore
#line 20 "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml"
             Html.DisplayNameFor(model => model.product_brand)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
            Write(
#nullable restore
#line 23 "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml"
             Html.DisplayFor(model => model.product_brand)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
            Write(
#nullable restore
#line 26 "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml"
             Html.DisplayNameFor(model => model.product_price)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
            Write(
#nullable restore
#line 29 "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml"
             Html.DisplayFor(model => model.product_price)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
            Write(
#nullable restore
#line 32 "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml"
             Html.DisplayNameFor(model => model.buyer_email)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
            Write(
#nullable restore
#line 35 "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml"
             Html.DisplayFor(model => model.buyer_email)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\n        </dd>\n        <dt class = \"col-sm-2\">\n            ");
            Write(
#nullable restore
#line 38 "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml"
             Html.DisplayNameFor(model => model.seller_email)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\n        </dt>\n        <dd class = \"col-sm-10\">\n            ");
            Write(
#nullable restore
#line 41 "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml"
             Html.DisplayFor(model => model.seller_email)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\n        </dd>\n    </dl>\n</div>\n<div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb6ade6cb1bbc1f6ce81c70ab1cd9d15a0d3ab189202a83fb64b96dfe01c3b257659", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
            WriteLiteral(
#nullable restore
#line 46 "D:\Switch_And_Shift-master\Switch and Shift\Views\REPORTs\Details.cshtml"
                                        Model.report_Id

#line default
#line hidden
#nullable disable
            );
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cb6ade6cb1bbc1f6ce81c70ab1cd9d15a0d3ab189202a83fb64b96dfe01c3b259864", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Switch_and_Shift.Models.REPORT> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
