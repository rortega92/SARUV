﻿var IDUsuarioActual
var DepartamentoActual
$(document).ready(function () {
    $(".col-lg-12").css("width", "50%");
    $(".col-lg-12").css("float", "left");
    $(".tab-bg-primary").css("background", "#394A59");
    $(".tab-bg-primary").css("padding-bottom", "10px");

    $.ajax({
        type: "GET",
        url: "/PersonalUV/getCurrentDepartamento",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            $.each(res, function (ind, ele) {
                DepartamentoActual = { "ID": ele.ID, "Nombre": ele.Nombre }
            });
            $.ajax({
                type: "GET",
                url: "/PersonalUV/getUsuariosByNombreDepartamento",
                data: { "nombreDepartamento": DepartamentoActual.Nombre },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#NavTabs").empty();
                    $.each(data, function (ind, usuario) {
                        $("#NavTabs").append($("<li></li>").append($("<a data-toggle='tab'></a>").html(usuario['Nombre']).attr("href", "." + usuario['Nombre'])));
                        $.ajax({
                            type: "GET",
                            url: "/PersonalUV/getRecursosByUsuario",
                            data: { "idUsuario": data[ind]['ID'] },
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (recursosPorUsuario) {
                                $("#TabContent").append($("<div class='tab-pane recurso-container'></div>").html('').attr("id", usuario['ID']));
                                $("#" +usuario['ID']).addClass(usuario['Nombre'])
                                $.each(recursosPorUsuario, function (indRec, recurso) {
                                    bindRecurso({
                                        "recurso": recurso,
                                        "usuario": usuario,
                                        "place": "#" + usuario['ID']
                                    })
                                });
                                if (recursosPorUsuario.length == 0) {
                                    $("#" + usuario['ID']).append("<div id='NoRecursos' style='margin-left:40%; margin-right:40%; text-align:center;'>No hay recursos</div>");
                                }
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
            $.ajax({
                type: "GET",
                url: "/PersonalUV/getIdJefeByNombreDepartamento",
                data: { "nombreDepartamento": DepartamentoActual.Nombre },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (usuarios) {
                    $.each(usuarios, function (indUsr, usuario) {
                        $.ajax({
                            type: "GET",
                            url: "/PersonalUV/getRecursosByUsuario",
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
                        url: "/PersonalUV/getCurrentUsuarioId",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (usuarios) {
                            $.each(usuarios, function (indUsr, usuario) {
                                IDUsuarioActual = usuario['ID']
                            });
                        }
                    });
                },
                error: function (dataError) {
                    alert("An error has occurred during processing your request.");
                    console.log(dataError)
                }
            });
        },
        error: function (dataError) { }
    });


    
    

    function bindRecurso(jsonData) {
        var btnEnviar = '<a id="EnviarDepartamento" class="btn btn-default btn-sm" data-toggle="modal" href="#modalEnviar_' + jsonData.recurso['ID'] + '">Enviar al siguiente departamento</a>';
        var btnFuente = '<a id="OperacionesFuente" class="btn btn-default btn-sm" data-toggle="modal" href="#modalFuente_' + jsonData.recurso['ID'] + '">Fuente</a>';
        if (DepartamentoActual.Nombre == "Grabación" || DepartamentoActual.Nombre == "Entrega") {
            btnFuente = "";
        }
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
                         btnEnviar+" "+btnFuente+
                      '</div>' +
                     '</td>' +
                    '</tr>' +
                '</table>' +
            '</div>').attr("id", jsonData.usuario['ID'] + "_" + jsonData.recurso['ID'])
        );
        $("#" + jsonData.usuario['ID'] + "_" + jsonData.recurso['ID']).css("width", $("#TabContent").css("width"));
        $("#" + jsonData.usuario['Nombre']).css("height", "100%")
        $("#TabContent").children().css("height", "100%")
        $("#TabContent").children().css("min-height", "200px")
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
        $('.recurso-container').sortable({ connectWith: '.recurso-container' }).droppable({
            drop: function (evt, draggableObject) {
                //console.log(evt,draggableObject)
                if (evt.target.classList.contains("panel-body")) {
                    //mover recurso al Jefe
                    $.ajax({
                        type: "GET",
                        url: "/PersonalUV/getIdJefeByNombreDepartamento",
                        data: { "nombreDepartamento": DepartamentoActual.Nombre },
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (usuarios) {
                            $.each(usuarios, function (ind, usuario) {
                                asignarRecursoParaUsuario(draggableObject.draggable.attr("id").split("_")[0], usuario["ID"], draggableObject.draggable.attr("id").split("_")[1]);
                                draggableObject.draggable.attr("id", usuario["ID"] + "_" + draggableObject.draggable.attr("id").split("_")[1]);
                                //quitar el #NoRecursos
                                $("#recursosPanel #NoRecursos").remove();
                                //Ver si el usuario desde donde se movió el recurso quedó vacio
                                /*$.ajax({
                                    type: "GET", url: "/PersonalUV/getRecursosByUsuario",
                                    data: { "idUsuario": draggableObject.draggable.attr("id").split("_")[0] }, contentType: "application/json; charset=utf-8", dataType: "json",
                                    success: function (recursosPorUsuario) {
                                        if (recursosPorUsuario.length == 0) {
                                            $("#" + draggableObject.draggable.attr("id").split("_")[0]).append("<div id='NoRecursos' style='margin-left:40%; margin-right:40%; text-align:center;'>No hay recursos</div>");
                                        }
                                    },
                                    error: function (dataError) {alert("An error has occurred during processing your request.");console.log(dataError)}
                                });*/

                            });
                        },
                        error: function(errorData) {
                        }
                    });
                } else {
                    //mover recurso al personal
                    $.ajax({
                        type: "GET",
                        url: "/PersonalUV/getIdJefeByNombreDepartamento",
                        data: { "nombreDepartamento": DepartamentoActual.Nombre},
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (usuarios) {
                            $.each(usuarios, function (ind, usuario) {
                                asignarRecursoParaUsuario(draggableObject.draggable.attr("id").split("_")[0], evt.target.id, draggableObject.draggable.attr("id").split("_")[1]);
                                draggableObject.draggable.attr("id", evt.target.id + "_" + draggableObject.draggable.attr("id").split("_")[1])
                                //quitar el #NoRecursos
                                $("#" + evt.target.id + " #NoRecursos").remove();
                                //Ver si el usuario desde donde se movió el recurso quedó vacio
                                /*$.ajax({
                                    type: "GET", url: "/PersonalUV/getRecursosByUsuario",
                                    data: { "idUsuario": draggableObject.draggable.attr("id").split("_")[0] }, contentType: "application/json; charset=utf-8", dataType: "json",
                                    success: function (recursosPorUsuario) {
                                        if (recursosPorUsuario.length == 0) {
                                            $("#recursosPanel").append("<div id='NoRecursos' style='margin-left:40%; margin-right:40%; text-align:center;'>No hay recursos</div>");
                                        }
                                    },
                                    error: function (dataError) { alert("An error has occurred during processing your request."); console.log(dataError) }
                                });*/
                            });
                        },
                        error: function (errorData) {
                        }
                    });
                }
            }
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
                    }).prop("selected", true);
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
        url: "/PersonalUV/updateEstadoRecursoPorUsuario",
        data: { "idRecursoPorUsuario": recursoPorUsuario, "Estado": estado },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            if (DepartamentoActual.Nombre == "Entrega" && estado == "Terminado") {
                $("#" + IDUsuarioActual + "_" + idRecursoPorUsuario).remove();
            }
        },
        error: function (dataError) { }
    });
}
/*function enviarSiguienteDepto(idRecurso) {
    var idUsuario = $('#modalEnviar_' + idRecurso + ' select').val();
    //var estado = $('#modalCambiarEstado_' + idRecurso + ' select').val() == "1" ? "No Empezado" : $('#modalCambiarEstado_' + idRecurso + ' select').val() == "2" ? "En Progreso" : "Terminado";
    //if (estado == "Terminado") {
        $.ajax({
            type: "GET",
            url: "/PersonalUV/updateRecursoPorUsuario",
            data: { "usuarioID": idUsuario, "recursoID": idRecurso },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (res) {
                $("#" + res.oldUser + "_" + idRecurso).remove();
            },
            error: function (dataError) {
                alert("An error has occurred during processing your request.");
                console.log(dataError)
            }
        });
    //}
}*/

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
                    $("#linkAviso").click();
                    $("#aviso .modal-body").html("Debe Cambiar el estado del recurso a terminado para poder enviar al siguiente departamento")
                    
                }
            });
        }, error: function () {
            console.log(dataError)
        }
    });

}

function asignarRecursoParaUsuario(idUsuarioAnterior,idNuevoUsuario, idRecurso) {
    $.ajax({
        type: "GET",
        url: "/PersonalUV/getRecursoPorUsuario",
        data: { "idUsuario": idUsuarioAnterior, "idRecurso": idRecurso },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (recursoPorUsuario) {
            $.each(recursoPorUsuario, function (ind, recUsr) {
                console.log("passed getRecursoPorUsuario")
                $.ajax({
                    type: "GET",
                    url: "/PersonalUV/updateUsuarioRecursoPorUsuarioAsignar",
                    data: { "usuarioID": idNuevoUsuario, "idRecursoPorUsuario": recUsr['ID'], "idRecurso": idRecurso },
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function () {
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