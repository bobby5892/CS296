#pragma checksum "C:\code\CS296\Lab 1\ComplaintDepartment\ComplaintDepartment\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1dd2f401485e32809c070089fba388842b359fcc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\code\CS296\Lab 1\ComplaintDepartment\ComplaintDepartment\Views\_ViewImports.cshtml"
using ComplaintDepartment;

#line default
#line hidden
#line 2 "C:\code\CS296\Lab 1\ComplaintDepartment\ComplaintDepartment\Views\_ViewImports.cshtml"
using ComplaintDepartment.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1dd2f401485e32809c070089fba388842b359fcc", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89b3b42dce684397cc9a332cc9616957a8b4b613", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ComplaintDepartment.Models.View.CommentsAndComplaints>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\code\CS296\Lab 1\ComplaintDepartment\ComplaintDepartment\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    ViewData["nav-home"] = "active";

#line default
#line hidden
            BeginContext(145, 316, true);
            WriteLiteral(@"
<p>Welcome to the complaint department!  Feel free to submit a complaint. No one will respond to it, but why not. </p>

<h3>Some Useless Statistics</h3>
<table>
    <tr>
        <td><b>Stat</b></td>
        <td><b>Value</b></td>
    </tr>
    <tr>
        <td>Total Number of Complaints</td>
        <td>");
            EndContext();
            BeginContext(462, 33, false);
#line 17 "C:\code\CS296\Lab 1\ComplaintDepartment\ComplaintDepartment\Views\Home\Index.cshtml"
       Write(Model.Complaints.Complaints.Count);

#line default
#line hidden
            EndContext();
            BeginContext(495, 84, true);
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Number of Open Complaints</td>\r\n        <td>");
            EndContext();
            BeginContext(580, 42, false);
#line 21 "C:\code\CS296\Lab 1\ComplaintDepartment\ComplaintDepartment\Views\Home\Index.cshtml"
       Write(Model.Complaints.GetOpenComplaints().Count);

#line default
#line hidden
            EndContext();
            BeginContext(622, 86, true);
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Number of Closed Complaints</td>\r\n        <td>");
            EndContext();
            BeginContext(709, 44, false);
#line 25 "C:\code\CS296\Lab 1\ComplaintDepartment\ComplaintDepartment\Views\Home\Index.cshtml"
       Write(Model.Complaints.GetClosedComplaints().Count);

#line default
#line hidden
            EndContext();
            BeginContext(753, 83, true);
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Total Number of Comments</td>\r\n        <td>");
            EndContext();
            BeginContext(837, 29, false);
#line 29 "C:\code\CS296\Lab 1\ComplaintDepartment\ComplaintDepartment\Views\Home\Index.cshtml"
       Write(Model.Comments.Comments.Count);

#line default
#line hidden
            EndContext();
            BeginContext(866, 82, true);
            WriteLiteral("</td>\r\n    </tr>\r\n</table>\r\n<br />\r\n<p>Be a statistic, submit a complaint now!</p>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ComplaintDepartment.Models.View.CommentsAndComplaints> Html { get; private set; }
    }
}
#pragma warning restore 1591
