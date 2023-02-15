<%@ Page Title="Insertar" Language="C#" MasterPageFile="~/Pages/Shared/Template.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="WebApp.Pages.Heroe.Insert" %>

<%@ Register Src="~/Pages/Heroe/FormHeroe.ascx" TagPrefix="uc1" TagName="FormHeroe" %>
<%@ Register Src="~/Pages/Heroe/FormConvertImageToBase64String.ascx" TagPrefix="uc1" TagName="FormConvertImageToBase64String" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="min-height: 78.3vh;">
        <div class="mt-3 pb-3 col-md-6 container" style="border: 3px solid rgba(50, 50, 50, 0.3); border-radius: 6px;">
            <div class="row">
                <div class="col-md-12 text-center my-auto mx-auto">
                    <h1 class="mt-3">Insertar</h1>
                </div>
            </div>
            <div class="row justify-content-center mt-3">
                <uc1:FormHeroe runat="server" id="FormHeroe" />
            </div>
        </div>
    </div>

    <uc1:FormConvertImageToBase64String runat="server" id="FormConvertImageToBase64String" />

</asp:Content>
