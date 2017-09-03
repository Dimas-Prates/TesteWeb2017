/*Máscaras*/
$(document).ready(function () {
    $("#txtPreco").maskMoney({
        prefix: "R$",
        decimal: ",",
        thousands: "."
    });
    $("#ContentPlaceHolder1_txtPreco").maskMoney({
        prefix: "R$",
        decimal: ",",
        thousands: "."
    });
});

/*Codigo em caixa alta*/
$(document).ready(function () {
    $("#txtCodigo").keyup(function () {
        $(this).val($(this).val().trim().toUpperCase());
    });
    $("#ContentPlaceHolder1_txtCodigo").keyup(function () {
        $(this).val($(this).val().trim().toUpperCase());
    });
});

/*Validação do formulário (Mercadorias/Consulta)*/
function validaForm(frm) {

    if (frm.txtCodigo.value == null || frm.txtCodigo.value == "" || frm.txtCodigo.value.length < 6 || frm.txtCodigo.value.indexOf(" ") > -1) {
        alert('É necessário que o código tenha 6 ou mais caracteres e não contenha espaços.');
        frm.txtCodigo.focus();
        return false;
    }
    if (frm.txtTipo.value == null || frm.txtTipo.value == "" || frm.txtTipo.value.length < 3) {
        alert('É necessário que o tipo tenha 3 caracteres ou mais.');
        frm.txtTipo.focus();
        return false;
    }
    if (frm.txtNome.value == null || frm.txtNome.value == "" || frm.txtNome.value.length < 3) {
        alert('É necessário que o nome tenha 3 caracteres ou mais.');
        frm.txtNome.focus();
        return false;
    }
    if (frm.cbQuantidade.value == null || frm.cbQuantidade.value == "" || frm.cbQuantidade.value <= 0) {
        alert('É necessário que a quantidade seja maior que zero.');
        frm.cbQuantidade.focus();
        return false;
    }
    if (frm.txtPreco.value == null || frm.txtPreco.value == "" || frm.txtPreco.value <= 0) {
        alert('É necessário que o preço seja maior que zero.');
        frm.txtPreco.focus();
        return false;
    }
    if (frm.ddlNegocio.value == null || frm.ddlNegocio.value == "" || frm.ddlNegocio.value == "Tipo de Negócio") {
        alert('É necessário selecionar um tipo de negócio válido.');
        frm.ddlNegocio.focus();
        return false;
    }

    /*VALIDAÇÃO ID ASP*/
    if (frm.ContentPlaceHolder1_txtCodigo.value == null || frm.ContentPlaceHolder1_txtCodigo.value == "" || frm.ContentPlaceHolder1_txtCodigo.value.length < 6 || frm.ContentPlaceHolder1_txtCodigo.value.indexOf(" ") > -1) {
        alert('É necessário que o código tenha 6 ou mais caracteres e não contenha espaços.');
        frm.ContentPlaceHolder1_txtCodigo.focus();
        return false;
    }
    if (frm.ContentPlaceHolder1_txtTipo.value == null || frm.ContentPlaceHolder1_txtTipo.value == "" || frm.ContentPlaceHolder1_txtTipo.value.length < 3) {
        alert('É necessário que o tipo tenha 3 caracteres ou mais.');
        frm.ContentPlaceHolder1_txtTipo.focus();
        return false;
    }
    if (frm.ContentPlaceHolder1_txtNome.value == null || frm.ContentPlaceHolder1_txtNome.value == "" || frm.ContentPlaceHolder1_txtNome.value.length < 3) {
        alert('É necessário que o nome tenha 3 caracteres ou mais.');
        frm.ContentPlaceHolder1_txtNome.focus();
        return false;
    }
    if (frm.ContentPlaceHolder1_cbQuantidade.value == null || frm.ContentPlaceHolder1_cbQuantidade.value == "" || frm.ContentPlaceHolder1_cbQuantidade.value <= 0) {
        alert('É necessário que a quantidade seja maior que zero.');
        frm.ContentPlaceHolder1_cbQuantidade.focus();
        return false;
    }
    if (frm.ContentPlaceHolder1_txtPreco.value == null || frm.ContentPlaceHolder1_txtPreco.value == "" || frm.ContentPlaceHolder1_txtPreco.value <= 0) {
        alert('É necessário que o preço seja maior que zero.');
        frm.ContentPlaceHolder1_txtPreco.focus();
        return false;
    }
    if (frm.ContentPlaceHolder1_ddlNegocio.value == null || frm.ContentPlaceHolder1_ddlNegocio.value == "" || frm.ContentPlaceHolder1_ddlNegocio.value == "Tipo de Negócio") {
        alert('É necessário selecionar um tipo de negócio válido.');
        frm.ContentPlaceHolder1_ddlNegocio.focus();
        return false;
    }
}

