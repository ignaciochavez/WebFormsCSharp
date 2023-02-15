<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Pages/Shared/Template.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApp.Pages.Home.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="height: 80vh;">
        <div class="jumbotron">
            <h1>Bienvenido!</h1>
            <p class="lead">Esta aplicación es una pagina web WebForms de muestra</p>
            <hr class="my-4" />
            <p>Para comenzar, asegurate de tener en ejecución la aplicación SOAPCSharp la cual es un servicio SOAP que es consumida por esta aplicación. Tambien debe apuntar correctamente en el archivo de configuración web.config. en el caso de que no este apuntando correctamente a la url</p>
        </div>
    </div>

</asp:Content>
