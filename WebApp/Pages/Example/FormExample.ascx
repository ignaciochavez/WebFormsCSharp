<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormExample.ascx.cs" Inherits="WebApp.Pages.Example.FormExample" %>

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

    .div-radio-options {
        margin-top: 7px;
    }
</style>


<div class="col-md-10 mt-3">
    <asp:HiddenField ID="hfId" runat="server" />
    <div class="justify-content-center row form-group">
        <div class="col-sm-3">
            <asp:Label ID="lRut" runat="server" Text="Rut" AssociatedControlID="tbRut" CssClass="col-form-label"></asp:Label>
        </div>
        <div class="col-sm-9">
            <asp:TextBox ID="tbRut" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="justify-content-center row form-group">
        <div class="col-sm-3">
            <asp:Label ID="lName" runat="server" Text="Name" AssociatedControlID="tbName" CssClass="col-form-label"></asp:Label>
        </div>
        <div class="col-sm-9">
            <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="justify-content-center row form-group">
        <div class="col-sm-3">
            <asp:Label ID="lLastName" runat="server" Text="LastName" AssociatedControlID="tbLastName" CssClass="col-form-label"></asp:Label>
        </div>
        <div class="col-sm-9">
            <asp:TextBox ID="tbLastName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="justify-content-center row form-group">
        <div class="col-sm-3">
            <asp:Label ID="lBirthDate" runat="server" Text="BirthDate" AssociatedControlID="tbBirthDate" CssClass="col-form-label"></asp:Label>
        </div>
        <div class="col-sm-9">
            <asp:TextBox ID="tbBirthDate" runat="server" CssClass="form-control"></asp:TextBox>
            <i class="fa fa-custom fa-calendar" onclick="onShowInputBirthDate()"></i>
        </div>
    </div>
     <div class="justify-content-center row form-group">
        <div class="col-sm-3">
            <asp:Label ID="lActive" runat="server" Text="Active" AssociatedControlID="rbYesActive" CssClass="col-form-label"></asp:Label>
        </div>
        <div class="col-sm-9">
            <div class="form-check form-check-inline div-radio-options">
                <asp:RadioButton ID="rbYesActive" GroupName="ActiveRadioOptions" runat="server" CssClass="form-check-input" />
                <asp:Label ID="lYesActive" runat="server" Text="Yes" AssociatedControlID="rbYesActive" CssClass="form-check-label"></asp:Label>
            </div>
            <div class="form-check form-check-inline div-radio-options">
                <asp:RadioButton ID="rbNonActive" GroupName="ActiveRadioOptions" runat="server" CssClass="form-check-input" />
                <asp:Label ID="lNonActive" runat="server" Text="No" AssociatedControlID="rbNonActive" CssClass="form-check-label"></asp:Label>
            </div>
        </div>
    </div>
     <div class="justify-content-center row form-group">
        <div class="col-sm-3">
            <asp:Label ID="lPassword" runat="server" Text="Password" AssociatedControlID="tbPassword" CssClass="col-form-label"></asp:Label>
        </div>
        <div class="col-sm-9">
            <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div class="justify-content-center row form-group" style="margin-top: 40px; border: 1px solid rgba(0,0,0,.125);">
    </div>
    <div class="justify-content-center row form-group" style="margin-top: 40px; margin-bottom: 40px;">
        <div class="col-lg-4">
            <button type="button" class="btn btn-outline-secondary btn-block" onclick="onClickClean()"><i class="fa fa-eraser">Limpiar</i></button>
        </div>
        <div class="col-lg-4">
            <asp:LinkButton ID="lbSubmit" runat="server" CssClass="btn btn-outline-success btn-block" OnClientClick="return onValidateFormExample();" OnClick="lbSubmit_Click"></asp:LinkButton>
        </div>
        <div class="col-lg-4">
            <asp:HyperLink ID="hlBackward" runat="server" NavigateUrl="~/Pages/Example/List.aspx" CssClass="btn btn-outline-primary btn-block"><i class="fa fa-backward">Volver</i></asp:HyperLink>
        </div>
    </div>
</div>

<script type="text/javascript">
    window.onload = function ()
    {
        $.datetimepicker.setLocale('es');

        $('#<% = tbBirthDate.ClientID %>').datetimepicker(
            {
            minDate: getMinDateInputBirthDate(),
            maxDate: getMaxDateInputBirthDate(),
            timepicker: false,
            format: 'Y-m-d'
            }
        );

        $('#<% = tbRut.ClientID %>').attr('maxlength', getMaxValueInputRut());
        $('#<% = tbRut.ClientID %>').attr('onblur', "onFormatRut()");
        $('#<% = tbRut.ClientID %>').attr('onkeypress', "return onOnlyCharactersOfRut(event)");
        $('#<% = tbName.ClientID %>').attr('maxlength', getMaxValueInputName());
        $('#<% = tbLastName.ClientID %>').attr('maxlength', getMaxValueInputLastName());
        $('#<% = tbBirthDate.ClientID %>').attr('onkeypress', "return onOnlyCharactersOfBirthDate(event)");
        $('#<% = tbBirthDate.ClientID %>').attr('maxlength', getMaxValueInputBirthDate());
        $('#<% = tbPassword.ClientID %>').attr('maxlength', getMaxValueInputPassword());
    }    

    function getMaxValueInputRut()
    {
        return 12;
    }

    function getMaxValueInputName()
    {
        return 45;
    }

    function getMaxValueInputLastName()
    {
        return 45;
    }

    function getMaxValueInputPassword()
    {
        return 16;
    }

    function getMinDateInputBirthDate()
    {
        var date = '1900-01-01';
        return date;
    }

    function getMaxDateInputBirthDate()
    {
        var date = '<% = DateTime.Now.ToString("yyyy-MM-dd") %>';
        return date;
    }

    function getMaxValueInputBirthDate()
    {
        return 10;
    }

    function onOnlyCharactersOfRut(evt)
    {
        var code = (evt.which) ? evt.which : evt.keyCode;

        if (code >= 48 && code <= 57)
        {
            return true;
        }
        else if (code == 46 || code == 45)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    function onOnlyCharactersOfBirthDate(evt)
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

    function onFormatRut()
    {
        var rut = $('#<% = tbRut.ClientID %>').val();
        if (rut.trim().length == 0 || rut.trim().length == 1 || (rut.trim().includes('-') && rut.trim().length == 2))
        {
            $('#<% = tbRut.ClientID %>').val(rut.trim().toUpperCase());
        }
        else
        {
            rut = rut.replaceAll(' ', '');
            rut = rut.replaceAll('.', '');
            rut = rut.replaceAll('-', '');
            rut = rut.toUpperCase();
            var counter = 0;
            var rutInvested = "";
            var finalRut = "";
            
            for (var i = rut.length - 1; i >= 0; i--)
            {
                rutInvested += rut.charAt(i);
                if (i == rut.length - 1)
                {
                    rutInvested += "-";
                }
                else if (counter == 3)
                {
                    rutInvested += ".";
                    counter = 0;
                }
                counter++;
            }

            for (var j = rutInvested.length - 1; j >= 0; j--)
            {
                if (rutInvested.charAt(rutInvested.length - 1) != ".")
                    finalRut += rutInvested.charAt(j);
                else if (j != rutInvested.length - 1)
                    finalRut += rutInvested.charAt(j);

            }
            $('#<% = tbRut.ClientID %>').val(finalRut.toUpperCase());
        }        
    }


    function onShowInputBirthDate()
    {
        $('#<% = tbBirthDate.ClientID %>').datetimepicker('show');
    }

    function onClickClean()
    {
        $('#<% = tbRut.ClientID %>').val('');
        $('#<% = tbName.ClientID %>').val('');
        $('#<% = tbLastName.ClientID %>').val('');
        $('#<% = tbBirthDate.ClientID %>').val('');
        $('#<% = rbYesActive.ClientID %>').prop('checked', false);
        $('#<% = rbNonActive.ClientID %>').prop('checked', false);
        $('#<% = tbPassword.ClientID %>').val('');
    }

    function onValidateRut(value)
    {
        value = value.replaceAll(' ', '');
        value = value.replaceAll('.', '');
        value = value.toUpperCase();

        const isRut = '^([0-9]+-{1}[0-9kK]{1})$';
        const regularExpression = new RegExp(isRut);

        if (!regularExpression.test(value))
        {
            return false;
        }
        else
        {
            var arrayValue = value.split('-');
            var rut = arrayValue[0];
            var digitCheck = arrayValue[1];
            if (digitCheck == 'K')
                digitCheck = 'k';

            var M = 0, S = 1;
            for (; rut; rut = Math.floor(rut / 10))
                S = (S + rut % 10 * (9 - M++ % 6)) % 11;

            return digitCheck == (S ? S - 1 : 'k');
        }
    }

    function onValidateFormExample()
    {
        var stringMessage = '';

        var valInputId = $('#<% = hfId.ClientID %>').val();
        if (valInputId < 0)
            stringMessage = '- Parámetro id debe ser mayor o igual que 0';

        var valInputRut = $('#<% = tbRut.ClientID %>').val();
        if (valInputRut.trim().length == 0)
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Rut no puede estar vacio';
            else
                stringMessage = stringMessage + '\n- Parámetro Rut no puede estar vacio';

        }
        else if (valInputRut.trim().length > getMaxValueInputRut())
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Rut no debe ser mayor a ' + getMaxValueInputRut() + ' caracteres de largo';
            else
                stringMessage = stringMessage + '\n- Parámetro Rut no debe ser mayor a ' + getMaxValueInputRut() + ' caracteres de largo';

        }
        else if (!onValidateRut(valInputRut))
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Rut no es válido';
            else
                stringMessage = stringMessage + '\n- Parámetro Rut no es válido';

        }

        var valInputName = $('#<% = tbName.ClientID %>').val();
        if (valInputName.trim().length == 0)
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Name no puede estar vacio';
            else
                stringMessage = stringMessage + '\n- Parámetro Name no puede estar vacio';

        }
        else if (valInputName.trim().length > getMaxValueInputName())
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Name no debe ser mayor a ' + getMaxValueInputName() + ' caracteres de largo';
            else
                stringMessage = stringMessage + '\n- Parámetro Name no debe ser mayor a ' + getMaxValueInputName() + ' caracteres de largo';

        }

        var valInputLastName = $('#<% = tbLastName.ClientID %>').val();
        if (valInputLastName.trim().length == 0)
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro LastName no puede estar vacio';
            else
                stringMessage = stringMessage + '\n- Parámetro LastName no puede estar vacio';

        }
        else if (valInputLastName.trim().length > getMaxValueInputLastName())
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro LastName no debe ser mayor a ' + getMaxValueInputLastName() + ' caracteres de largo';
            else
                stringMessage = stringMessage + '\n- Parámetro LastName no debe ser mayor a ' + getMaxValueInputLastName() + ' caracteres de largo';

        }

        var valInputBirthDate = $('#<% = tbBirthDate.ClientID %>').val();
        if (valInputBirthDate == '')
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro BirthDate no puede estar vacio';
            else
                stringMessage = stringMessage + '\n- Parámetro BirthDate no puede estar vacio';

        }
        else
        {

            var date = new Date(valInputBirthDate);
            var today = new Date(getMaxDateInputBirthDate());
            if (date > today)
            {

                if (stringMessage.length == 0)
                    stringMessage = '- Parámetro BirthDate no puede ser mayor a la fecha actual';
                else
                    stringMessage = stringMessage + '\n- Parámetro BirthDate no puede ser mayor a la fecha actual';

            }

        }


        var valInputYesActive = $('input:radio[id=<% = rbYesActive.ClientID %>]:checked').val();
        var valInputNonActive = $('input:radio[id=<% = rbNonActive.ClientID %>]:checked').val();
        if (valInputYesActive == undefined && valInputNonActive == undefined)
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Active no esta seleccionado. Debe seleccionar una opcion';
            else
                stringMessage = stringMessage + '\n- Parámetro Active no esta seleccionado. Debe seleccionar una opcion';

        }

        var valInputPassword = $('#<% = tbPassword.ClientID %>').val();
        if (valInputPassword.trim().length == 0)
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Password no puede estar vacio';
            else
                stringMessage = stringMessage + '\n- Parámetro Password no puede estar vacio';

        }
        else if (valInputLastName.trim().length > getMaxValueInputPassword())
        {

            if (stringMessage.length == 0)
                stringMessage = '- Parámetro Password no debe ser mayor a ' + getMaxValueInputPassword() + ' caracteres de largo';
            else
                stringMessage = stringMessage + '\n- Parámetro Password no debe ser mayor a ' + getMaxValueInputPassword() + ' caracteres de largo';

        }

        if (stringMessage.length == 0)
        {
            return true;
        }
        else
        {
            swal('Requerido', stringMessage, 'info');
            return false;
        }
    }
</script>
