#pragma checksum "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\Funder\GetAllCause.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1f09fe9aebddfcab0864a2f954cc696c840fa25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Funder_GetAllCause), @"mvc.1.0.view", @"/Views/Funder/GetAllCause.cshtml")]
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
#nullable restore
#line 1 "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\_ViewImports.cshtml"
using frontend;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\_ViewImports.cshtml"
using frontend.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1f09fe9aebddfcab0864a2f954cc696c840fa25", @"/Views/Funder/GetAllCause.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61a0032050492aba87e35431d6bb7e644e53465d", @"/Views/_ViewImports.cshtml")]
    public class Views_Funder_GetAllCause : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<api.Models.Cause>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\Funder\GetAllCause.cshtml"
  
    ViewData["Title"] = "GetAllCause";
    Layout = "~/Views/Shared/_LayoutSignIn.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>All the fundraisers</h1>\r\n<hr />\r\n<table class=\"table table-bordered table-hover\">\r\n    <thead class = \"thead-dark\">\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 14 "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\Funder\GetAllCause.cshtml"
           Write(Html.DisplayNameFor(model => model.Cid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\Funder\GetAllCause.cshtml"
           Write(Html.DisplayNameFor(model => model.Reason));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Target\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 26 "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\Funder\GetAllCause.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 29 "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\Funder\GetAllCause.cshtml"
           Write(Html.DisplayFor(modelItem => item.Cid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 32 "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\Funder\GetAllCause.cshtml"
           Write(Html.DisplayFor(modelItem => item.Reason));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\Funder\GetAllCause.cshtml"
           Write(Html.DisplayFor(modelItem => item.Money));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 38 "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\Funder\GetAllCause.cshtml"
           Write(Html.ActionLink("Donate now!", "AddFunderCause", new { id=item.Cid }, new {@class = "border border-success text-success p-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span> | </span>\r\n                ");
#nullable restore
#line 39 "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\Funder\GetAllCause.cshtml"
           Write(Html.ActionLink("Click to know more", "CauseDetail", new { id=item.Cid }, new {@class = "border border-primary p-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 42 "C:\Users\d.c.wsa4\Desktop\demo\finalproject\frontend\Views\Funder\GetAllCause.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<api.Models.Cause>> Html { get; private set; }
    }
}
#pragma warning restore 1591