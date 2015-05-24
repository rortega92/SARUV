$(document).ready(function () {
    $(".col-lg-12").css("width", "50%");
    $(".col-lg-12").css("float", "left");
    $(".tab-bg-primary").css("background", "#394A59");
    $(".tab-bg-primary").css("padding-bottom", "10px");
    $.ajax({
        type: "GET",
        url: "getUsuariosByNombreDepartamento",
        data: { "nombreDepartamento": "Diseno" },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#NavTabs").empty();
            $.each(data, function (ind, usuario) {
                $("#NavTabs").append($("<li></li>").append($("<a data-toggle='tab'></a>").html(usuario['Nombre']).attr("href", "#" + usuario['Nombre'])));
                $.ajax({
                    type: "GET",
                    url: "getRecursosByUsuario",
                    data: { "idUsuario": data[ind]['ID'] },
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (recursosPorUsuario) {
                        //$("#NavContent").empty();
                        //console.log("data retrieved from getRecursosByUsuario: ", recursosPorUsuario)
                        $("#TabContent").append($("<div class='tab-pane'></div>").html('').attr("id", usuario['Nombre']));
                        $.each(recursosPorUsuario, function (indRec, recurso) {
                            var prioridad = recurso['Prioridad'] == "Alta" ? "alert alert-danger" : recurso['Prioridad'] == "Media" ? "alert alert-warning" : "alert alert-success"
                            $("#" + usuario['Nombre']).append($("<div class='tab-pane'></div>").html('<div class="' + prioridad + '"><table class="table" ' + 'id=' + '"' + usuario['ID'] + '_Table"' + ' style="margin: 0px"><tr><td style="border:0px">' + recurso['Nombre'] + '</td></tr>').attr("id", usuario['Nombre']));
                        });
                        $($(".panel .panel-heading ul li a")[0]).click()
                    },
                    error: function (dataError) {
                        alert("An error has occurred during processing your request.");
                        console.log(dataError)
                    }
                });
            });
        },
        error: function () {
            alert("An error has occurred during processing your request.");
        }
    });
});