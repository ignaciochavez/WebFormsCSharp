<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormHeroe.ascx.cs" Inherits="WebApp.Pages.Heroe.FormHeroe" %>


<style type="text/css">
    .fa-custom {
        position: absolute;
        right: 25px;
        top: 11px;
        font: normal normal normal 14px/1 FontAwesome;
        font-size: inherit;
        text-rendering: auto;
        -webkit-font-smoothing: antialiased;
    }
</style>

<div class="col-md-10 mt-3" style="padding-bottom: 40px;">
    <asp:HiddenField ID="hfId" runat="server" />

    <div class="card h-100">
        <asp:Image ID="iImgBase64String" runat="server" CssClass="card-img-top" />
        <div class="card-body">
            <div class="justify-content-center row form-group">
                <div class="col-sm-4">
                    <asp:Label ID="lName" runat="server" Text="Name" AssociatedControlID="tbName" CssClass="col-form-label"></asp:Label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="justify-content-center row form-group">
                <div class="col-sm-4">
                    <asp:Label ID="lHome" runat="server" Text="Home" AssociatedControlID="tbHome" CssClass="col-form-label"></asp:Label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="tbHome" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="justify-content-center row form-group">
                <div class="col-sm-4">
                    <asp:Label ID="lAppearance" runat="server" Text="Appearance" AssociatedControlID="tbAppearance" CssClass="col-form-label"></asp:Label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="tbAppearance" runat="server" CssClass="form-control"></asp:TextBox>
                    <i class="fa fa-custom fa-calendar" onclick="showInputAppearance()"></i>
                </div>
            </div>
            <div class="justify-content-center row form-group">
                <div class="col-sm-4">
                    <asp:Label ID="lDescription" runat="server" Text="Description" AssociatedControlID="tbDescription" CssClass="col-form-label"></asp:Label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="tbDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="justify-content-center row form-group">
                <div class="col-sm-4">
                    <asp:Label ID="lImgBase64String" runat="server" Text="ImgBase64String" AssociatedControlID="tbImgBase64String" CssClass="col-form-label"></asp:Label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="tbImgBase64String" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="justify-content-center row form-group">
                <div class="col-sm-12">
                    <button type="button" class="btn btn-outline-secondary btn-block" onclick="onClickDisplayImage()"><i class="fa fa-picture-o">Visualizar Imagen</i></button>
                </div>
            </div>
            <div class="justify-content-center row form-group" style="margin-top: 40px; border: 1px solid rgba(0,0,0,.125);">
            </div>
            <div class="justify-content-center row form-group" style="margin-top: 40px; margin-bottom: 40px;">
                <div class="col-lg-4">
                    <button type="button" class="btn btn-outline-secondary btn-block" onclick="onClickClean()"><i class="fa fa-eraser">Limpiar</i></button>
                </div>
                <div class="col-lg-4">
                    <asp:LinkButton ID="lbSubmit" runat="server" CssClass="btn btn-outline-success btn-block" OnClientClick="return onValidateFormHeroe();" OnClick="lbSubmit_Click"></asp:LinkButton>
                </div>
                <div class="col-lg-4">
                    <asp:HyperLink ID="hlBackward" runat="server" NavigateUrl="~/Pages/Heroe/List.aspx" CssClass="btn btn-outline-primary btn-block"><i class="fa fa-backward">Volver</i></asp:HyperLink>
                </div>
            </div>
        </div>

    </div>
</div>

<script type="text/javascript">
    window.onload = function ()
    {
        $.datetimepicker.setLocale('es');

        $('#<% = tbAppearance.ClientID %>').datetimepicker(
            {
            minDate: getMinDateInputAppearance(),
            maxDate: getMaxDateInputAppearance(),
            timepicker: false,
            format: 'Y-m-d'
            }
        );

        $('#<% = tbName.ClientID %>').attr('maxlength', getMaxValueInputName());
        $('#<% = tbHome.ClientID %>').attr('maxlength', getMaxValueInputHome());
        $('#<% = tbAppearance.ClientID %>').attr('maxlength', getMaxValueInputAppearance());
        $('#<% = tbAppearance.ClientID %>').attr('onkeypress', "return onOnlyCharactersOfAppearance(event)");
        $('#<% = tbDescription.ClientID %>').attr('maxlength', getMaxValueInputDescription());
    }

    function getMaxValueInputName()
    {
        return 45;
    }

    function getMaxValueInputHome()
    {
        return 35;
    }

    function getMaxValueInputDescription()
    {
        return 450;
    }

    function getMinDateInputAppearance()
    {
        var date = '1900-01-01';
        return date;
    }

    function getMaxDateInputAppearance()
    {
        var date = '<% = DateTime.Now.ToString("yyyy-MM-dd") %>';
        return date;
    }

    function getMaxValueInputAppearance()
    {
        return 10;
    }

    function onOnlyCharactersOfAppearance(evt)
    {
        var code = (evt.which) ? evt.which : evt.keyCode;

        if (code >= 48 && code <= 57)
        {
            return true;
        }
        else if (code == 45)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    function notIncludeConventionsInputImgBase64String(value)
    {
        var arrayValue = value.split(',');
        var convention = arrayValue[0].toLowerCase();

        if (!convention.includes('data:image/bmp;base64') && !convention.includes('data:image/emf;base64') && !convention.includes('data:image/exif;base64')
            && !convention.includes('data:image/gif;base64') && !convention.includes('data:image/icon;base64') && !convention.includes('data:image/jpeg;base64')
            && !convention.includes('data:image/jpg;base64') && !convention.includes('data:image/png;base64') && !convention.includes('data:image/tiff;base64')
            && !convention.includes('data:image/wmf;base64'))
        {
            return 'Parámetro ImgBase64String no es válido. El formato debe ser bmp, emf, exif, gif, icon, jpeg, jpg, png, tiff o wmf';
        }
        else
        {
            return '';
        }
    }

    function validateBase64String(value)
    {       
        const isBase64String = '^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{4})$';
        const regularExpression = new RegExp(isBase64String);
        if (!regularExpression.test(value))
            return 'Parámetro ImgBase64String no es válido';
        else
            return '';
    }
    
    function showInputAppearance()
    {
        $('#<% = tbAppearance.ClientID %>').datetimepicker('show');
    }
    
    function onClickDisplayImage()
    {
        var valInputImgBase64String = $('#<% = tbImgBase64String.ClientID %>').val();

        var notIncludeConventions = notIncludeConventionsInputImgBase64String(valInputImgBase64String);
        if (notIncludeConventions.length > 0)
        {
            swal('Requerido', '- ' + notIncludeConventions, 'info');
            return;
        }

        var arrayValInputImgBase64String = valInputImgBase64String.split(',');
        var isBase64String = validateBase64String(arrayValInputImgBase64String[1]);
        if (isBase64String.length > 0)
        {
            swal('Requerido', '- ' + isBase64String, 'info');
            return;
        }

        if (valInputImgBase64String.trim().length == 0)
        {
            $('#<% = iImgBase64String.ClientID %>').css('display', 'none');
            $('#<% = iImgBase64String.ClientID %>').attr('src', '');
            $('#<% = iImgBase64String.ClientID %>').attr('alt', '');
        }
        else
        {
            var valInputName = $('#<% = tbName.ClientID %>').val();
            if (valInputName.trim().length == 0)
            {
                $('#<% = iImgBase64String.ClientID %>').attr('alt', '');
            }
            else
            {
                $('#<% = iImgBase64String.ClientID %>').attr('alt', valInputName.trim());
            }

            $('#<% = iImgBase64String.ClientID %>').css('display', 'block');
            $('#<% = iImgBase64String.ClientID %>').attr('src', valInputImgBase64String.trim());
        }
    }

    function onClickClean()
    {
        $('#<% = tbName.ClientID %>').val('');
        $('#<% = tbHome.ClientID %>').val('');
        $('#<% = tbAppearance.ClientID %>').val('');
        $('#<% = tbDescription.ClientID %>').val('');
        $('#<% = tbImgBase64String.ClientID %>').val('');
        $('#<% = iImgBase64String.ClientID %>').css('display', 'none');
        $('#<% = iImgBase64String.ClientID %>').attr('src', '');
    }

    function onValidateFormHeroe()
    {
        var stringMessage = '';
        
        var valInputName = $('#<% = tbName.ClientID %>').val();
        if (valInputName.trim().length == 0)
        {
            stringMessage = '- Parámetro Name no puede estar vacio';
        }
        else if (valInputName.trim().length > getMaxValueInputName())
        {
            stringMessage = '- Parámetro Name no debe ser mayor a ' + getMaxValueInputName() + ' caracteres de largo';
        }

        var valInputHome = $('#<% = tbHome.ClientID %>').val();
        if (valInputHome.trim().length == 0)
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Home no puede estar vacio';
            else
                stringMessage = stringMessage + '\n- Parámetro Home no puede estar vacio';

        }
        else if (valInputHome.trim().length > getMaxValueInputHome())
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Home no debe ser mayor a ' + getMaxValueInputHome() + ' caracteres de largo';
            else
                stringMessage = stringMessage + '\n- Parámetro Home no debe ser mayor a ' + getMaxValueInputHome() + ' caracteres de largo';

        }

        var valInputAppearancee = $('#<% = tbAppearance.ClientID %>').val();
        if (valInputAppearancee == '')
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Appearance no puede estar vacio';
            else
                stringMessage = stringMessage + '\n- Parámetro Appearance no puede estar vacio';

        }
        else
        {

            var date = new Date(valInputAppearancee);
            var today = new Date(getMaxDateInputAppearance());
            if (date > today)
            {

                if (stringMessage.length == 0)
                    stringMessage = '- Parámetro Appearance no puede ser mayor a la fecha actual';
                else
                    stringMessage = stringMessage + '\n- Parámetro Appearance no puede ser mayor a la fecha actual';

            }

        }

        var valInputDescription = $('#<% = tbDescription.ClientID %>').val();
        if (valInputDescription.trim().length == 0)
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Description no puede estar vacio';
            else
                stringMessage = stringMessage + '\n- Parámetro Description no puede estar vacio';

        }
        else if (valInputDescription.trim().length > getMaxValueInputDescription())
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Description no debe ser mayor a ' + getMaxValueInputDescription() + ' caracteres de largo';
            else
                stringMessage = stringMessage + '\n- Parámetro Description no debe ser mayor a ' + getMaxValueInputDescription() + ' caracteres de largo';

        }

        var valInputImgBase64String = $('#<% = tbImgBase64String.ClientID %>').val();
        if (valInputImgBase64String.trim().length == 0)
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro ImgBase64String no puede estar vacio';
            else
                stringMessage = stringMessage + '\n- Parámetro ImgBase64String no puede estar vacio';

        }

        else
        {
            var notIncludeConventions = notIncludeConventionsInputImgBase64String(valInputImgBase64String);
            if (notIncludeConventions.length > 0)
            {

                if (stringMessage.length == 0)
                    stringMessage = '- ' + notIncludeConventions;
                else
                    stringMessage = stringMessage + '\n- ' + notIncludeConventions;

            }
            else
            {
                var arrayValInputImgBase64String = valInputImgBase64String.split(',');
                var isBase64String = validateBase64String(arrayValInputImgBase64String[1]);
                if (isBase64String.length > 0)
                {

                    if (stringMessage.length == 0)
                        stringMessage = '- ' + isBase64String;
                    else
                        stringMessage = stringMessage + '\n- ' + isBase64String;
                }
            }
        }         

        if (stringMessage.length == 0) {
            return true;
        }
        else {
            swal('Requerido', stringMessage, 'info');
            return false;
        }
    }
</script>