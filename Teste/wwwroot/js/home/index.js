$(document).ready(function () {
    ListarDadosFuncionario();
});

function ListarDadosFuncionario() {

    $.ajax({
        url: "/Home/ListarDadosFuncionario",
        type: "GET",
        contentType: 'application/json; charset=UTF-8',
        success: function (response) {
            $("#divListarFuncionarios").html(response)
        },
        error: function (response) {
            console.log(response)
            swal("Opss", "Aconteceu um imprevisto. Contate o administrador!", "error");
        }
    });

}