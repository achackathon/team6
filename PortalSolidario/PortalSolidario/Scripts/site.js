function PostUser() {
    var userData = {

        Id_usuario: 100,
        Id_perfil: parseInt($("#registerPerfil").val()),
        Nome: $("#registerNome").val(),
        endereco: $("#registerLogradouro").val(),
        Email: $("#registerEmail").val(),
        Cep: $("#registerCep").val(),
        Documento: $("#registerDocumento").val()
    }

    $.post("http://localhost:50429/portalsolidario/usuarios/", userData, function (data, status) {
        console.log(data);
        console.log(status);
    });
}

function GetPerfil() {
    $.get("http://localhost:50429/portalsolidario/perfil/", function (data, status) {
        console.log(data);
        console.log(status);
    });
}

function GetAddress() {
    
    $.get("http://api.postmon.com.br/v1/cep/" + $("#registerCep").val(), function (data, status) {
        console.log(data);
        $("#registerEstado").val(data.estado);
        $("#registerCidade").val(data.cidade);
        $("#registerBairro").val(data.bairro);
        $("#registerLogradouro").val(data.logradouro);
        
        console.log(status);
    });

}

$("#registerCep").blur(
    function () {
        $("#registerEstado").val("");
        $("#registerCidade").val("");
        $("#registerBairro").val("");
        $("#registerLogradouro").val("");
        GetAddress();
    });


$("#buttonSubmit").click(
    function() {
        console.log("TRACE: PostUser");
       // PostUser();
    });