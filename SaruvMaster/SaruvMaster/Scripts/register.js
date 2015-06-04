$(document).ready(function () {
    $("#isAdmin").change(function () {
        if ($("#isAdmin").val() === "Administrador") {
            $("#DepartamentoID").parent().parent().addClass("hidden");
            $("#isBoss").parent().parent().addClass("hidden");
        } else {
            $("#DepartamentoID").parent().parent().removeClass("hidden");
            $("#isBoss").parent().parent().removeClass("hidden");
        }
    });
    $("#Submit").click(function () {
        if ($("#isAdmin").checked) {
            $("#DepartamentoID").empty();
        }
    });
});