// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $("#CNPJ").mask("99.999.999-9999/99", { autoclear: false });
    $("#Cep").mask("99999-999", { autoclear: false });
    $("#CPF").mask("999.999.999-99", { autoclear: false });


    $('#pj').hide();
    $('#pf').show();

    $("#btnPf").click(() => {
        habilitaForm("pf");
    })

    $("#btnPj").click(() => {
        habilitaForm("pj");
    })

    function habilitaForm(form) {
        if (form === "pj")
        {
            $('#pf').hide();
            $('#pj').show();
        }

        if (form === "pf")
        {
            $('#pf').show();
            $('#pj').hide();
        }        
    }


    function limpa_formulário_cep() {
        // Limpa valores do formulário de cep.
        $("#Logradouro").val("");
        $("#Bairro").val("");
        $("#Cidade").val("");
        $("#Uf").val("");
    }

    //Quando o campo cep perde o foco.
    $("#Cep").blur(function () {

        //Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#Logradouro").val("...");
                $("#Bairro").val("...");
                $("#Cidade").val("...");
                $("#UF").val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#Logradouro").val(dados.logradouro);
                        $("#Bairro").val(dados.bairro);
                        $("#Cidade").val(dados.localidade);
                        $("#UF").val(dados.uf);
                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });
});