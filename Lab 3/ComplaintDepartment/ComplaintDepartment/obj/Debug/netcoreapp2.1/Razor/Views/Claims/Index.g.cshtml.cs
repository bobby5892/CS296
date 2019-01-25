#pragma checksum "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\Claims\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2cae22f8f6442c588ac767e989709d1af399ffd8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Claims_Index), @"mvc.1.0.view", @"/Views/Claims/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Claims/Index.cshtml", typeof(AspNetCore.Views_Claims_Index))]
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
#line 1 "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\_ViewImports.cshtml"
using ComplaintDepartment;

#line default
#line hidden
#line 2 "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\_ViewImports.cshtml"
using ComplaintDepartment.Models;

#line default
#line hidden
#line 3 "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cae22f8f6442c588ac767e989709d1af399ffd8", @"/Views/Claims/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d055a165d738b7176b796bb91a415ec78e55ae6", @"/Views/_ViewImports.cshtml")]
    public class Views_Claims_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<System.Security.Claims.Claim>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 236, true);
            WriteLiteral("\r\n<div class=\"bg-primary m-1 p-1 text-white\"><h4>Claims</h4></div>\r\n\r\n<table class=\"table table-sm table-bordered\">\r\n    <tr>\r\n        <th>Subject</th>\r\n        <th>Issuer</th>\r\n        <th>Type</th>\r\n        <th>Value</th>\r\n    </tr>\r\n");
            EndContext();
#line 12 "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\Claims\Index.cshtml"
     if (Model == null || Model.Count() == 0)
    {

#line default
#line hidden
            BeginContext(340, 69, true);
            WriteLiteral("        <tr><td colspan=\"4\" class=\"text-center\">No Claims</td></tr>\r\n");
            EndContext();
#line 15 "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\Claims\Index.cshtml"
    }
    else
    {
        

#line default
#line hidden
#line 18 "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\Claims\Index.cshtml"
         foreach (var claim in Model.OrderBy(x => x.Type))
        {

#line default
#line hidden
            BeginContext(504, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(543, 18, false);
#line 21 "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\Claims\Index.cshtml"
               Write(claim.Subject.Name);

#line default
#line hidden
            EndContext();
            BeginContext(561, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(589, 12, false);
#line 22 "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\Claims\Index.cshtml"
               Write(claim.Issuer);

#line default
#line hidden
            EndContext();
            BeginContext(601, 26, true);
            WriteLiteral("</td>\r\n                <td");
            EndContext();
            BeginWriteAttribute("identity-claim-type", " identity-claim-type=\"", 627, "\"", 660, 1);
#line 23 "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\Claims\Index.cshtml"
WriteAttributeValue("", 649, claim.Type, 649, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(661, 28, true);
            WriteLiteral("></td>\r\n                <td>");
            EndContext();
            BeginContext(690, 11, false);
#line 24 "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\Claims\Index.cshtml"
               Write(claim.Value);

#line default
#line hidden
            EndContext();
            BeginContext(701, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 26 "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\Claims\Index.cshtml"
        }

#line default
#line hidden
#line 26 "C:\code\CS296\Lab 3\ComplaintDepartment\ComplaintDepartment\Views\Claims\Index.cshtml"
         
    }

#line default
#line hidden
            BeginContext(745, 10, true);
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<System.Security.Claims.Claim>> Html { get; private set; }
    }
}
#pragma warning restore 1591
