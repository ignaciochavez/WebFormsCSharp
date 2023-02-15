<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Template.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="WebApp.Pages.Example.Update" %>

<%@ Register Src="~/Pages/Example/FormExample.ascx" TagPrefix="uc1" TagName="FormExample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div style="min-height: 78.3vh;">
        <div class="mt-3 pb-3 col-md-6 container" style="border: 1px solid rgba(50, 50, 50, 0.3); border-radius: 6px;">
            <div class="row">
                <div class="col-md-12 text-center my-auto mx-auto">
                    <h1 id="hTitle" runat="server" class="mt-3"></h1>
                </div>
            </div>
            <asp:Panel ID="pMessage" runat="server" Visible="false" CssClass="row justify-content-center mt-3">
                <div class="col-md-10">
                    <asp:Panel ID="pAlert" runat="server" Visible="true" role="alert">
                        <h4 id="hTitleAlert" runat="server" class="alert-heading"></h4>
                    </asp:Panel>  
                </div>
            </asp:Panel>
            <asp:Panel ID="pUpdate" runat="server" Visible="false" CssClass="row justify-content-center mt-3">
                <uc1:FormExample runat="server" ID="FormExample" />
            </asp:Panel>
        </div>
    </div>

</asp:Content>
