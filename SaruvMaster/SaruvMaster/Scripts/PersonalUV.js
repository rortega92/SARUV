var IDUsuarioActual
var DepartamentoActual
$(document).ready(function () {
    $(".tab-bg-primary").css("background", "#394A59");
    $(".tab-bg-primary").css("padding-bottom", "10px");
    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }    
    $.ajax({
        type: "GET",
        url: "/PersonalUV/getCurrentUsuarioId",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (usuarios) {
            $.each(usuarios, function (indUsr, usuario) {
                IDUsuarioActual=usuario['ID']
                $.ajax({
                    type: "GET",
                    url: "/PersonalUV/getRecursosByUsuario",
                    data: { "idUsuario": usuarios[indUsr]['ID'] },
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (recursos) {
                        $.each(recursos, function (indRec, recurso) {
                            if (!(DepartamentoActual.Nombre == "Entrega" && recurso.Estado == "Terminado")) {
                                bindRecurso({
                                    "recurso": recurso,
                                    "usuario": usuario,
                                    "place": "#recursosPanel"
                                })
                            }
                        });
                        if (recursos.length == 0) {
                            $("#recursosPanel").append("<div id='NoRecursos' style='margin-left:40%; margin-right:40%; text-align:center;'>No hay recursos</div>");
                        }
                    },
                    error: function (dataError) {
                        alert("An error has occurred during processing your request.");
                        console.log(dataError)
                    }
                });
            });
            $.ajax({
                type: "GET",
                url: "/PersonalUV/getCurrentDepartamento",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    $.each(res, function (ind, ele) {
                        DepartamentoActual = { "ID": ele.ID, "Nombre": ele.Nombre }
                    });
                },
                error: function (dataError) { }
            });
        },
        error: function (dataError) {
            alert("An error has occurred during processing your request.");
            console.log(dataError)
        }
    });
    
    function bindRecurso(jsonData) {
        var btnEnviar = '<a id="EnviarDepartamento" class="btn btn-default btn-sm" data-toggle="modal" href="#modalEnviar_' + jsonData.recurso['ID'] + '">Enviar al siguiente departamento</a>';
        if (DepartamentoActual.Nombre == "Entrega") {
            btnEnviar = "";
        }
        var prioridad = jsonData.recurso['Prioridad'] == "Alta" ? "alert alert-danger" : jsonData.recurso['Prioridad'] == "Media" ? "alert alert-warning" : "alert alert-success"
        $(jsonData.place).append($("<div class='Recurso'></div>").html('' +
            '<div class="' + prioridad + '">' +
                '<table class="table" ' + 'id=' + '"' + jsonData.usuario['ID'] + '_Table"' + ' style="margin: 0px">' +
                    '<tr><td style="border:0px">' + jsonData.recurso['Nombre'] + '</td>' +
                     '<td class="navbar-right" style="border:0px">' +
                      '<div class="btn-group-vertical">' +
                         '<a id="CambiarEstado" class="btn btn-default btn-sm" data-toggle="modal" href="#modalCambiarEstado_' + jsonData.recurso['ID'] + '">Cambiar estado</a>' +
                          btnEnviar+
                      '</div>' +
                     '</td>' +
                    '</tr>' +
                '</table>' +
            '</div>').attr("id", jsonData.usuario['ID']+"_"+jsonData.recurso['ID'])
        );
        $.ajax({
            type: "GET",
            url: "/PersonalUV/getUsuariosDelSigDepto",
            data: { "usuarioID": jsonData.usuario["ID"] },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (usuarios) {
                $.each(usuarios, function (indUsr, usuario) {
                    $("#modalEnviar_" + jsonData.recurso["ID"]).find("#SelectUsuariosDestino").append($("<option></option>").val(usuario['ID']).html(usuario['Nombre'] + " (" + usuario["NombreDepartamento"] + ")"));
                });
            },
            error: function () { }
        });
        $.ajax({
            type: "GET",
            url: "/PersonalUV/getRecursoPorUsuario",
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
function cambiarEstado(idRecursoPorUsuario) {
    var estado = $('#modalCambiarEstado_' + idRecursoPorUsuario + ' select').val() == "1" ? "No Empezado" : $('#modalCambiarEstado_' + idRecursoPorUsuario + ' select').val() == "2" ? "En Progreso" : "Terminado";
    $.ajax({
        type: "GET",
        url: "/PersonalUV/updateEstadoRecursoPorUsuario",
        data: { "idRecursoPorUsuario": idRecursoPorUsuario, "Estado": estado },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            if (DepartamentoActual.Nombre == "Entrega" && estado == "Terminado") {
                $("#" + IDUsuarioActual + "_" + idRecursoPorUsuario).remove();
            }
        },
        error: function(dataError){}
    });
}
function enviarSiguienteDepto(idRecurso) {
    $.ajax({
        type: "GET",
        url: "/PersonalUV/getRecursoPorUsuario/",
        data: { "idUsuario": IDUsuarioActual, "idRecurso": idRecurso },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            $.each(res, function (ind, recUsr) {
                if (recUsr.Estado == "Terminado") {
                    var idUsuario = $('#modalEnviar_' + idRecurso + ' select').val()
                    $.ajax({
                        type: "GET",
                        url: "/PersonalUV/updateRecursoPorUsuario",
                        data: { "usuarioID": idUsuario, "recursoID": idRecurso },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (res) {
                            $.ajax({
                                type: "GET",
                                url: "/PersonalUV/updateEstadoRecursoPorUsuario",
                                data: { "idRecursoPorUsuario": res.idRecursoPorUsuario, "Estado": "No Empezado" },
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function () {
                                    $("#" + res.oldUser + "_" + idRecurso).remove();
                                },
                                error: function (dataError) { }
                            });
                        },
                        error: function (dataError) {
                            alert("An error has occurred during processing your request.");
                            console.log(dataError)
                        }
                    });
                } else {
                    $('<div title="Aviso">Debe Cambiar el estado del recurso a terminado para poder enviar al siguiente departamento</div>').dialog({"class":"modal-dialog modal"});
                }
            });            
        }, error: function(){
            console.log(dataError)
        }
    });
    
}