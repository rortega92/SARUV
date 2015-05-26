$(document).ready(function () {
    $(".tab-bg-primary").css("background", "#394A59");
    $(".tab-bg-primary").css("padding-bottom", "10px");
    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }
    var idUsuario = getParameterByName("idUsuario");
    
    $.ajax({
        type: "GET",
        url: "getUsuarioById",
        data: { "idUsuario": idUsuario },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (usuarios) {
            $.each(usuarios, function (indUsr, usuario) {
                $.ajax({
                    type: "GET",
                    url: "getRecursosByUsuario",
                    data: { "idUsuario": usuarios[indUsr]['ID'] },
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (recursos) {
                        $.each(recursos, function (indRec, recurso) {
                            bindRecurso({
                                "recurso": recurso,
                                "usuario": usuario,
                                "place": "#recursosPanel"
                            })
                        });
                    },
                    error: function (dataError) {
                        alert("An error has occurred during processing your request.");
                        console.log(dataError)
                    }
                });
            });
        },
        error: function (dataError) {
            alert("An error has occurred during processing your request.");
            console.log(dataError)
        }
    });

    function bindRecurso(jsonData) {
        var prioridad = jsonData.recurso['Prioridad'] == "Alta" ? "alert alert-danger" : jsonData.recurso['Prioridad'] == "Media" ? "alert alert-warning" : "alert alert-success"
        $(jsonData.place).append($("<div class='Recurso'></div>").html('' +
            '<div class="' + prioridad + '">' +
                '<table class="table" ' + 'id=' + '"' + jsonData.usuario['ID'] + '_Table"' + ' style="margin: 0px">' +
                    '<tr><td style="border:0px">' + jsonData.recurso['Nombre'] + '</td>' +
                     '<td class="navbar-right" style="border:0px">' +
                      '<div class="btn-group-vertical">' +
                         '<a id="CambiarEstado" class="btn btn-default btn-sm" data-toggle="modal" href="#modalCambiarEstado_' + jsonData.recurso['ID'] + '">Cambiar estado</a>' +
                         '<a id="EnviarDepartamento" class="btn btn-default btn-sm" href="javascript:enviarSiguienteDepto(' + jsonData.usuario['ID'] + ',' + jsonData.recurso['ID'] + ');">Enviar al siguiente departamento</a>' +
                      '</div>' +
                     '</td>' +
                    '</tr>' +
                '</table>' +
            '</div>').attr("id", jsonData.usuario['ID']+"_"+jsonData.recurso['ID'])
        );
        $.ajax({
            type: "GET",
            url: "getRecursoPorUsuario",
            data: { "idUsuario": jsonData.usuario.ID, "idRecurso": jsonData.recurso.ID },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (recursoPorUsuario) {
                $.each(recursoPorUsuario, function (ind, recUsr) {
                    $("#modalCambiarEstado_" + jsonData.recurso.ID + " select option").filter(function () {
                        return $(this).text() == recUsr.Estado
                    }).prop("selected",true);
                });
            },
            error: function (dataError) {
                alert("An error has occurred during processing your request.");
                console.log(dataError)
            }
        });
    }
});
function cambiarEstado(recursoPorUsuario) {
    var estado = $('#modalCambiarEstado_' + recursoPorUsuario + ' select').val() == "1" ? "No Empezado" : $('#modalCambiarEstado_' + recursoPorUsuario + ' select').val() == "2" ? "En Progreso" : "Terminado";
    $.ajax({
        type: "GET",
        url: "updateEstadoRecursoPorUsuario",
        data: { "idRecursoPorUsuario": recursoPorUsuario, "Estado": estado },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
        },
        error: function(dataError){}
    });
}
function enviarSiguienteDepto(idUsuario,idRecurso) {
    $.ajax({
        type: "GET",
        url: "getRecursoPorUsuario",
        data: { "idUsuario": idUsuario, "idRecurso": idRecurso},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (recursoPorUsuario) {
            $.each(recursoPorUsuario, function (ind, recUsr) {
                $.ajax({
                    type: "GET",
                    url: "updateUsuarioRecursoPorUsuario",
                    data: { "usuarioID": idUsuario, "idRecursoPorUsuario": recUsr['ID'] },
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function () {
                        $("#"+idUsuario + "_" + idRecurso).parent().empty();
                    },
                    error: function (dataError) {
                        alert("An error has occurred during processing your request.");
                        console.log(dataError)
                    }
                });
            });
        },
        error: function (dataError) {
            alert("An error has occurred during processing your request.");
            console.log(dataError)
        }
    });
}