<%@ Page Title="No encontrado" Language="C#" MasterPageFile="~/Pages/Shared/Template.Master" AutoEventWireup="true" CodeBehind="NotFound.aspx.cs" Inherits="WebApp.Pages.Home.NotFound" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height: 78.3vh;" class="text-center">
        <h3 class="mt-3">Pagina no encontrada</h3>
        <p>Lo siento, la pagina que esta buscando no se ha encontrado</p>
        <hr class="my-4"/>
        <h6>
            <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="~/Pages/Home/Index.aspx">Volver a la pagina de inicio</asp:HyperLink></h6>
    </div>

</asp:Content>
