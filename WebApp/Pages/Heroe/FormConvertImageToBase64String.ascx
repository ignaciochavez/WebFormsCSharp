<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormConvertImageToBase64String.ascx.cs" Inherits="WebApp.Pages.Heroe.FormConvertImageToBase64String" %>


<div class="col-md-6" style="border: 1px solid rgba(50, 50, 50, 0.3); margin-top: 30px; margin-left: auto; margin-right: auto; border-radius: 6px;">
    <div class="col-md-12">
        <span>&nbsp;</span>
        <h4 style="text-align: center;">Transformar imagen a Base64String</h4>
        <span>&nbsp;</span>
    </div>
    <div class="justify-content-center row form-group" style="margin-bottom: 40px; border: 1px solid rgba(0,0,0,.125);">
    </div>
    <div class="justify-content-center row">
        <div class="form-group col-md-8">   
            <asp:Image ID="iNewImgBase64String" CssClass="card-img-top" runat="server" />         
            <img id="imgNewImgBase64String" class="card-img-top" style="display: none;"  />
        </div>
    </div>
    <div class="justify-content-center row">
        <div class="form-group col-lg-8">
            <asp:FileUpload ID="fuFileImage" runat="server" CssClass="form-control-file" />
        </div>
    </div>
    <div class="justify-content-center row form-group" style="margin-top: 25px; border: 1px solid rgba(0,0,0,.125);">
    </div>
    <div class="justify-content-center row">
        <h6 style="text-align: center;">Resultado</h6>
    </div>
    <div class="justify-content-center row">
        <div class="form-group col-md-10">
            <asp:TextBox ID="tbNewImgBase64String" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>
    </div>
    <div class="col-md-12">
        <span>&nbsp;</span>
    </div>
</div>

<script type="text/javascript">

    document.querySelector('#<% = fuFileImage.ClientID %>').addEventListener('change', onReadFile);

    function onReadFile() {
        
        if (!this.files || !this.files[0])
            return;

        var arrayFileName = this.files[0].name.split('.');
        var extension = arrayFileName[arrayFileName.length - 1];
        
        if (!extension.includes('bmp') && !extension.includes('emf') && !extension.includes('exif')
            && !extension.includes('gif') && !extension.includes('icon') && !extension.includes('jpeg')
            && !extension.includes('jpg') && !extension.includes('png') && !extension.includes('tiff')
            && !extension.includes('wmf'))
        {
            $('#<% = fuFileImage.ClientID %>').val('');
            $('#<% = iNewImgBase64String.ClientID %>').css('display', 'none');
            $('#<% = iNewImgBase64String.ClientID %>').attr('src', '');
            $('#<% = tbNewImgBase64String.ClientID %>').val('');
            swal('Requerido', '- Parámetro File Image no es válido. El formato debe ser bmp, emf, exif, gif, icon, jpeg, jpg, png, tiff o wmf', 'info');
            return;
        }

        const fileReader = new FileReader();

        fileReader.addEventListener("load", function (evt) {
            $('#<% = iNewImgBase64String.ClientID %>').css('display', 'block');
            $('#<% = iNewImgBase64String.ClientID %>').attr('src', evt.target.result);
            $('#<% = tbNewImgBase64String.ClientID %>').val(evt.target.result);
            
        });

        fileReader.readAsDataURL(this.files[0]);
    }

</script>