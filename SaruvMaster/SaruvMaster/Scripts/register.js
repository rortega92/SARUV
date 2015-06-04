$(document).ready(function () {
    $("#isAdmin").change(function () {
        if ($("#isAdmin").val() === "Administrador") {
            $("#DepartamentoID").parent().parent().addClass("hidden");
            $("#isJefe").parent().parent().addClass("hidden");
        } else {
            $("#DepartamentoID").parent().parent().removeClass("hidden");
            $("#isJefe").parent().parent().removeClass("hidden");
        }
    }).change();
    $("#Submit").click(function () {
        if ($("#isAdmin").val() === "Administrador") {
            $("#DepartamentoID").empty();
            $("#isJefe").empty();
        } 
    });
});