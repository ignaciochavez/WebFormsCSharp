<%@ Page Title="Confirmacion" Language="C#" MasterPageFile="~/Pages/Shared/Template.Master" AutoEventWireup="true" CodeBehind="ConfirmFormHeroe.aspx.cs" Inherits="WebApp.Pages.Heroe.ConfirmFormHeroe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="min-height: 78.3vh;">
        <div class="mt-3 pb-3 container" style="border: 1px solid rgba(50, 50, 50, 0.3); border-radius: 6px;">
            <div class="row ">
                <div class="col-md-6 text-center my-auto mx-auto">
                    <h1 class="mt-3">Confirmacion</h1>
                </div>
            </div>

            <asp:Panel ID="pMessage" runat="server" CssClass="row justify-content-center mt-3">
                <div class="col-md-10">
                    <asp:Panel ID="pAlert" runat="server" Visible="true" role="alert">
                        <h4 id="hTitleAlert" runat="server" class="alert-heading"></h4>
                    </asp:Panel>  
                </div>
            </asp:Panel>

            <div class="col-md-10 text-right my-auto mx-auto">                
                <h6><asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="~/Pages/Heroe/List.aspx"><i class="fa fa-backward"></i> Volver</asp:HyperLink></h6>
            </div>
        </div>
    </div>

</asp:Content>
