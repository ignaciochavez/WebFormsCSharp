<%@ Page Title="Listado Example" Language="C#" MasterPageFile="~/Pages/Shared/Template.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebApp.Pages.Example.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style type="text/css">

        .column-id{
            font-weight: bold;
        }

        .password{
            width: 111px; 
            display: flex;
            overflow: auto;
            white-space: nowrap;
        }

    </style>

    <div style="min-height: 78.3vh;">
        <div class="mt-3 pb-3" style="border: 3px solid rgba(50, 50, 50, 0.3); border-radius: 6px; width: 100%; height: 100%;">
            <div class="row ">
                <div class="col-md-6 text-center my-auto mx-auto">
                    <h1 class="mt-3">Listado Example</h1>
                </div>
                <div class="col-md-6 text-center my-auto mx-auto">
                    <h2 id="hPageIndex" runat="server" class="mt-3"></h2>
                </div>
            </div>

            <asp:Panel ID="pMessage" runat="server" Visible="false" CssClass="row justify-content-center mt-3">
                <div class="col-md-10">
                    <asp:Panel ID="pAlert" runat="server" Visible="true" role="alert">
                        <h4 id="hTitleAlert" runat="server" class="alert-heading"></h4>
                    </asp:Panel>  
                </div>
            </asp:Panel>


            <div class="row justify-content-center mt-3">
                <div class="col-md-10">
                    <div class="table-responsive-sm table-responsive-md table-responsive-lg">
                        <asp:GridView ID="gvExamples" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" GridLines="None">
                            <Columns>
                                <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="column-id" />
                                <asp:BoundField HeaderText="Rut" DataField="Rut" />
                                <asp:BoundField HeaderText="Name" DataField="Name" />
                                <asp:BoundField HeaderText="LastName" DataField="LastName" />
                                <asp:BoundField HeaderText="BirthDate" DataField="BirthDate" />
                                <asp:BoundField HeaderText="Active" DataField="Active" />
                                <asp:BoundField HeaderText="Password" DataField="Password" ItemStyle-CssClass="password"/>
                                <asp:TemplateField HeaderText="Accion">
                                    <ItemTemplate>
                                        <a href='<% ResolveUrl("~"); %>/Pages/Example/Update.aspx?id=<%#Eval("Id")%>' class="btn btn-outline-secondary btn-sm"><i class="fa fa-pencil-square-o"> Editar</i></a>
                                        &nbsp;
                                        <button type="button" class="btn btn-outline-danger btn-sm" data-toggle="modal" data-target="#modalDelete" onclick="onClickOpenModalDelete(<%#Eval("Id")%>)"><i class="fa fa-trash"> Eliminar</i></button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>                 
                        </asp:GridView>                        
                    </div>
                </div>
            </div>

            <div class="row justify-content-center mt-3">
                <div class="col-md-7">
                    <nav aria-label="..." style="right: 0;">
                        <ul id="uPagination" runat="server" class="pagination">
                        </ul>
                    </nav>
                </div>
                <div class="col-md-3">
                    <div class="col-sm-12" style="float: right;">
                        <asp:HyperLink ID="hlInsert" runat="server" NavigateUrl="~/Pages/Example/Insert.aspx" CssClass="btn btn-outline-primary btn-block"><i class="fa fa-plus-circle"> Insertar Nuevo Registro</i></asp:HyperLink>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-6" style="border: 1px solid rgba(50, 50, 50, 0.3); margin-top: 30px; margin-left: auto; margin-right: auto; border-radius: 6px;">
            <div class="col-md-12">
                <span>&nbsp;</span>
                <h4 style="text-align: center;">Descargar todos los registros existentes</h4>
                <span>&nbsp;</span>
            </div>
            <div class="row justify-content-center">
                <div class="col-md-5">
                    <asp:LinkButton ID="lbDownloadExcel" runat="server" CssClass="btn btn-outline-success btn-block" OnClick="lbDownloadExcel_Click"><i class="fa fa-file-excel-o"> Descargar Excel</i></asp:LinkButton>
                </div>
                <span>&nbsp;</span>
                <div class="col-md-5">
                    <asp:LinkButton ID="lbDownloadPDF" runat="server" CssClass="btn btn-outline-danger btn-block" OnClick="lbDownloadPDF_Click"><i class="fa fa-file-pdf-o"> Descargar PDF</i></asp:LinkButton>
                </div>
            </div>
            <div class="col-md-12">
                <span>&nbsp;</span>
            </div>
        </div>
    </div>    

    <div class="modal fade" id="modalDelete" data-backdrop="static" data-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">            
                <div class="modal-header">
                    <h5 class="modal-title" id="staticBackdropLabel">Confirmación de eliminacion</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="onClickCloseModalDelete()">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>¿Estas seguro que deseas eliminar el registro Id <asp:Label ID="lId" runat="server"></asp:Label>?</p>
                </div>
                <div class="modal-footer">
                    <asp:HiddenField ID="hfId" runat="server"/>
                    <button type="button" class="btn btn-outline-primary" data-dismiss="modal" onclick="onClickCloseModalDelete()"><i class="fa fa-times"> Cerrar</i></button>
                    <asp:LinkButton ID="lbDelete" runat="server" CssClass="btn btn-outline-success" OnClick="lbDelete_Click"><i class="fa fa-trash"> Eliminar</i></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    
    <script type="text/javascript">

        function onClickOpenModalDelete(id) {
            $('#<% = hfId.ClientID %>').val(id);
            $('#<% = lId.ClientID %>').html(id);
        }

        function onClickCloseModalDelete() {
            $('#<% = hfId.ClientID %>').val('');
            $('#<% = lId.ClientID %>').html('');
        }

    </script>

</asp:Content>
