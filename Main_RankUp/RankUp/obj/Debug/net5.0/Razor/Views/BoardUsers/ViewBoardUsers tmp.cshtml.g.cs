#pragma checksum "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\BoardUsers\ViewBoardUsers tmp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "651704aef8eda4a2f2b9c590b049477a2a2fd588"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BoardUsers_ViewBoardUsers_tmp), @"mvc.1.0.view", @"/Views/BoardUsers/ViewBoardUsers tmp.cshtml")]
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
#line 1 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\_ViewImports.cshtml"
using RankUp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\_ViewImports.cshtml"
using RankUp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"651704aef8eda4a2f2b9c590b049477a2a2fd588", @"/Views/BoardUsers/ViewBoardUsers tmp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55eb3dd419a25f53547f75f9ba95739dede72b17", @"/Views/_ViewImports.cshtml")]
    public class Views_BoardUsers_ViewBoardUsers_tmp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RankUp.Models.BoardUsers>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Content/BoardUsers/css/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\BoardUsers\ViewBoardUsers tmp.cshtml"
  

    Layout = "~/Views/Shared/_navBar.cshtml";
    ViewBag.Title = "RankUp - HR Panel";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "651704aef8eda4a2f2b9c590b049477a2a2fd5884905", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


<div class=""main-panel"">
    <div class=""content-wrapper"">

        <div class=""row "">
            <div class=""col grid-margin stretch-card"">
                <div class=""card"">
                    <div class=""card-body"">
                        <h4 class=""card-title"">Filter</h4>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "651704aef8eda4a2f2b9c590b049477a2a2fd5886348", async() => {
                WriteLiteral(@"
                            <div class=""row"">

                                <div class=""col"">
                                    <div class=""form-group row"">
                                        <p class=""col-4"">Name</p>
                                        <div class=""col-8"">
                                            <input style=""color:white"" type=""text"" class=""form-control"" id=""name"">
                                        </div>
                                    </div>
                                </div>
                                <div class=""col"">
                                    <div class=""form-check form-check-flat form-check-primary"">
                                        <label class=""form-check-label"">
                                            <input type=""checkbox"" class=""form-check-input""> Is Admin?<i class=""input-helper""></i>
                                        </label>
                                    </div>
                                ");
                WriteLiteral(@"</div>
                                <div class=""col"">
                                    <div class=""form-check form-check-flat form-check-primary"">
                                        <label class=""form-check-label"">
                                            <input type=""checkbox"" class=""form-check-input""> Is Available?<i class=""input-helper""></i>
                                        </label>
                                    </div>
                                </div>

                                <div class=""col"">
                                    <button style=""float:right"" type=""submit"" class=""btn btn-success"">Search</button>
                                </div>
                            </div>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>

        <div class=""row "">
            <div class=""col grid-margin stretch-card"">
                <div class=""card"">
                    <div class=""card-body"">

                        <div class=""row"">

                            <div class=""col-6"">
                                <h4 style=""display:inline"" class=""card-title"">Board Users</h4>
                            </div>

                            <div class=""col-6"">
                                <label class=""m-0"">Total HR members: ");
#nullable restore
#line 68 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\BoardUsers\ViewBoardUsers tmp.cshtml"
                                                                Write(ViewBag.AllBoardUsers.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                                <a style=""float:right"" class=""m-0 btn btn-success create-new-button"" id=""addUser"" href=""#"">+ Add new HR member</a>
                            </div>

                        </div>

                        <div class=""table-responsive"">
                            <table class=""table"">
                                <thead>
                                    <tr>

                                        <th> Name </th>
                                        <th> Is Admin </th>
                                        <th> Is Available </th>

                                </thead>
                                <tbody>

");
#nullable restore
#line 86 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\BoardUsers\ViewBoardUsers tmp.cshtml"
                                     foreach (var boardUser in ViewBag.AllBoardUsers)
                                    {
                                        //<partial name ="Shared/_displayBoardUsers" model="boardUser" />

                                        //Html.RenderPartialAsync("_displayBoardUsers", boardUser)
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <!-- content-wrapper ends -->
    <!-- partial:partials/_footer.html -->
</div>
<!-- main-panel ends -->


");
            WriteLiteral(@"<div id=""deleteUserModal"" class=""modal"">

    <div class=""modal-content"">
        <div class=""modal-headerr"" style=""text-align:center"">
            <span class=""close"" onclick=""closeModal()"">&times;</span>

        </div>


        <div class=""modal-body"">

            <h5 id=""deleteHeader"" style=""margin-bottom: 2rem""></h5>
        </div>

        <div style=""text-align:center"" class=""modal-footer"">
            <button style=""margin-left:auto;margin-right:auto"" class=""btn"" onclick=""closeModal()"">Close</button>
            <button style=""margin-left:auto;margin-right:auto"" class=""btn"" onclick=""DeleteBoardUser()"">Yes</button>

        </div>
    </div>
</div>


");
            WriteLiteral(@"<div id=""ResetPasswordModal"" class=""modal"">

    <div class=""modal-content"">
        <div class=""modal-headerr"" style=""text-align:center"">
            <span class=""close"" onclick=""closeModal()"">&times;</span>

        </div>


        <div class=""modal-body"">

            <h5 id=""updatePasswordHeader"" style=""margin-bottom: 2rem""></h5>
        </div>

        <div style=""text-align:center"" class=""modal-footer"">
            <button style=""margin-left:auto;margin-right:auto"" class=""btn"" onclick=""closeModal()"">Close</button>
            <button style=""margin-left:auto;margin-right:auto"" class=""btn"" onclick=""ResetBoardUserPassword()"">Yes</button>

        </div>
    </div>
</div>

");
            WriteLiteral(@"<div id=""confirmationMsgModal"" class=""modal"">

    <div class=""modal-content"">
        <div class=""modal-headerr"" style=""text-align:center"">
            <span class=""close"" onclick=""closeModal()"">&times;</span>

        </div>


        <div class=""modal-body"">

            <h5 id=""confirmationHeader"" style=""margin-bottom: 2rem""></h5>
        </div>

        <div style=""text-align:center"" class=""modal-footer"">
            <button style=""margin-left:auto;margin-right:auto"" class=""btn"" onclick=""closeModal()"">OK</button>

        </div>
    </div>
</div>


<div class=""loading-modal""><!-- Place at bottom of page --></div>



<script>
    var modal = """";
    var selectedUserId = """";


    function showDeleteUserModal(userId, userFirstName, userLastName) {//userId, userLastName, userFirstName) {

        modal = document.getElementById('deleteUserModal');

        selectedUserId = userId;
        document.getElementById('deleteHeader').innerText = (""Are you sure you want to delet");
            WriteLiteral(@"e user: "" + userFirstName + "" "" + userLastName);

        modal.style.display = 'block';
        // alert(""showDeleteUserModal"")
    }

    function showResetPasswordModal(userId, userFirstName, userLastName) {//userId, userLastName, userFirstName) {

        // lih msh rady yb3t boardUser.user.Id ??????
        console.log(""user id is:"")
        console.log(userId)


        modal = document.getElementById('ResetPasswordModal');

        selectedUserId = userId;

        document.getElementById('updatePasswordHeader').innerText = (""Are you sure you want to reset password for user: "" + userFirstName + "" "" + userLastName);

        modal.style.display = 'block';
    }

    function closeModal() {

        modal.style.display = ""none"";
    }

    function DeleteBoardUser() {

        // call ajax

        modal.style.display = ""none"";

        alert(""Call ajax for delete, user id:"");
        alert(selectedUserId);
        alert(typeof(selectedUserId));

        $.ajax({
   ");
            WriteLiteral("         type:\'GET\', // lazem tkon GET ???\r\n            url: \'");
#nullable restore
#line 232 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\BoardUsers\ViewBoardUsers tmp.cshtml"
             Write(Url.Action("DeleteBoardUser", "BoardUsers"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            dataType: 'json',
            contentType: ""application/json; charset=utf-8"",
            // to send parameters to the action:
            data: { ""deletedBoardUserId"": selectedUserId },
            success: function (result) {
                if (result == ""error"") {

                    console.log(""success, but error :|"")

                    modal = document.getElementById(""confirmationMsgModal"");
                    document.getElementById(""confirmationHeader"").innerText = ""Couldn't delete user!""
                    modal.style.display = 'block';

                }
                else {
                    console.log(""Done deleting"");

                    modal = document.getElementById(""confirmationMsgModal"");
                    document.getElementById(""confirmationHeader"").innerText = ""User have been deleted successfully""
                    modal.style.display = 'block';
                }
            },
            error: function (xhr, ajaxOptions, thrownError");
            WriteLiteral(@") {
                console.log(""Error calling ajax!!!"")
              }
        });

    }

    function ResetBoardUserPassword() {

        // call ajax
        modal.style.display = ""none"";

        alert(""Call ajax for update, user id:"");
        alert(selectedUserId);

        $.ajax({
            type: 'GET',

            url: '");
#nullable restore
#line 273 "E:\Rank Up\2_Complete RankUp - with separate registration form\Complete RankUp - with separate registration form\Project versions\RankUp 07-10-2021\RankUp\Views\BoardUsers\ViewBoardUsers tmp.cshtml"
             Write(Url.Action("ResetBoardUserPassword", "BoardUsers"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            dataType: 'json',
            contentType: ""application/json; charset=utf-8"",
            // to send parameters to the action:
            data: { ""boardUserId"": selectedUserId },
            success: function (result) {
                if (result == ""error"") {

                    modal = document.getElementById(""confirmationMsgModal"");
                    document.getElementById(""confirmationHeader"").innerText = ""Couldn't delete user!""
                    modal.style.display = 'block';

                }
                else {
                    modal = document.getElementById(""confirmationMsgModal"");
                    document.getElementById(""confirmationHeader"").innerText = ""User have benn deleted successfully""
                    modal.style.display = 'block';
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(""Error calling ajax!!"");
              }
        });
    }

</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RankUp.Models.BoardUsers> Html { get; private set; }
    }
}
#pragma warning restore 1591
