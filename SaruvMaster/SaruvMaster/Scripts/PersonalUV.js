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
    var $overlay = $('<div class="ui-overlay"><div class="ui-widget-overlay" style="background:#111111"><img src="Content/layout/loader.gif" style="position: absolute;top: 50%; left: 50%; width: 50px; height: 50px;"></div></div>').hide().appendTo('body');
    $overlay.fadeIn();

    $(window).resize(function () {
        $overlay.width($(document).width());
        $overlay.height($(document).height());
    });
    $.ajax({
        type: "GET",
        url: "/PersonalUV/getCurrentDepartamento",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            $.each(res, function (ind, ele) {
                DepartamentoActual = { "ID": ele.ID, "Nombre": ele.Nombre }
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
                                    var contRecursos = 0;
                                    $.each(recursos, function (indRec, recurso) {
                                        if (!(DepartamentoActual.Nombre == "Entrega" && recurso.Estado == "Terminado")) {
                                            bindRecurso({
                                                "recurso": recurso,
                                                "usuario": usuario,
                                                "place": "#recursosPanel"
                                            })
                                            contRecursos++;
                                        } else {
                                            $overlay.fadeOut();
                                        }
                                    });
                                    if (contRecursos == 0) {
                                        $("#recursosPanel").append("<div id='NoRecursos' style='margin-left:40%; margin-right:40%; text-align:center;'>No hay recursos</div>");
                                        $overlay.fadeOut();
                                    }
                                    
                                },
                                error: function (dataError) {
                                    toastr.error("Ha ocurrido un error por parte del servidor");
                                    console.log(dataError)
                                    $overlay.fadeOut();
                                }
                            });//end getRecursosByUsuario
                        });                    
                    },
                    error: function (dataError) {
                        toastr.error("Ha ocurrido un error por parte del servidor");
                        console.log(dataError)
                        $overlay.fadeOut();
                    }
                })//end getCurrentUsuarioId
            });
        },
        error: function (dataError) { toastr.error("Ha ocurrido un error por parte del servidor"); }
    });//end getCurrentDepto
    
    function bindRecurso(jsonData) {
        var btnEnviar = '<a id="EnviarDepartamento" class="btn btn-default btn-sm" data-toggle="modal" href="#modalEnviar_' + jsonData.recurso['ID'] + '">Enviar al siguiente departamento</a>';
        var btnFuente = '<a id="SubirFuente" class="btn btn-default btn-sm" data-toggle="modal" href="#modalFuente_' + jsonData.recurso['ID'] + '">Fuente</a>';
        var btnRecurso = '<a id="SubirRecurso" class="btn btn-default btn-sm" data-toggle="modal" href="#modalRecurso_' + jsonData.recurso['ID'] + '">Recurso</a>';

        if (DepartamentoActual.Nombre == "Entrega") {
            btnEnviar = "";
        }
        var prioridad = jsonData.recurso['Prioridad'] == "Alta" ? "alert alert-danger" : jsonData.recurso['Prioridad'] == "Media" ? "alert alert-warning" : "alert alert-success"
        $(jsonData.place).append($("<div class='Recurso'></div>").html('' +
            '<div class="' + prioridad + '" >' +
                '<table class="table" ' + 'id=' + '"' + jsonData.usuario['ID'] + '_Table"' + ' style="margin: 0px">' +
                    '<tr><td style="border:0px">' + jsonData.recurso['Nombre'] + '</td>' +
                     '<td class="navbar-right" style="border:0px">' +
                      '<div class="btn-group-vertical">' +
                         '<a id="CambiarEstado" class="btn btn-default btn-sm" data-toggle="modal" href="#modalCambiarEstado_' + jsonData.recurso['ID'] + '">Cambiar estado</a>' +
                         ((DepartamentoActual.Nombre == "Diseño" || DepartamentoActual.Nombre == "Corrección")?btnFuente:'') +
                         btnRecurso +
                         btnEnviar +
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
                    }).prop("selected", true);
                    if (recUsr.Estado == "No Empezado") {
                        $("#modalCambiarEstado_" + jsonData.recurso.ID + " select option")[2].remove();
                    }
                    if (recUsr.Estado == "En Progreso") {
                        $("#modalCambiarEstado_" + jsonData.recurso.ID + " select option")[0].remove();
                    }
                    if (recUsr.Estado == "Terminado") {
                        $("#modalCambiarEstado_" + jsonData.recurso.ID + " select option")[0].remove();
                        $("#modalCambiarEstado_" + jsonData.recurso.ID + " select option")[0].remove();
                    }
                });
            },
            error: function (dataError) {
                toastr.error("Ha ocurrido un error por parte del servidor");
                console.log(dataError)
            }
        });
        $.ajax({
            type: "GET",
            url: "/FTP/getArchivosByRecursoId",
            data: { "recursoId": jsonData.recurso.ID },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (archivos) {
                var contFuente = 0;
                var contRecurso = 0;
                var files = []
                $.each(archivos, function (ind, archivo) {
                    files.push(archivo)
                });
                var filesSorted = [];
                while (files.length > 0) {
                    filesSorted.push(files.pop())
                }
                filesSorted.forEach(function (ele, idx) {
                    //console.log(ele.NombreArchivo.split("_")[1].split(".")[0])
                    if (ele.TipoArchivo == 0) {
                        contFuente++;
                        $("#modalFuente_" + jsonData.recurso["ID"]).find("input:file").on('change', function () { $("#" + jsonData.recurso.ID + ".frmUpFuente").parent().find("#Submit").removeProp("disabled") })
                        //if(contFuente<=1) //Mostrar solo el último Archivo subido
                        $("#modalFuente_" + jsonData.recurso["ID"]).find("#selectArchivosFuente_" + jsonData.recurso.ID).append($("<option></option>").val(ele['ID']).html(ele['NombreArchivo']));
                    } else {
                        contRecurso++;
                        $("#modalRecurso_" + jsonData.recurso["ID"]).find("input:file").on('change', function () { $("#" + jsonData.recurso.ID + ".frmUpRecurso").parent().find("#Submit").removeProp("disabled") })
                        //if(contRecurso<=1) //Mostrar solo el último Archivo subido
                        $("#modalRecurso_" + jsonData.recurso["ID"]).find("#selectArchivosRecurso_" + jsonData.recurso.ID).append($("<option></option>").val(ele['ID']).html(ele['NombreArchivo']));
                    }
                })
                if (contFuente == 0) {
                    $("#" + jsonData.recurso.ID + ".frmDesFuente").find("#Submit").prop("disabled", "disabled");
                    $("#" + jsonData.recurso.ID + ".frmDelFuente").find("#Submit").prop("disabled", "disabled");
                }
                if (contRecurso == 0) {
                    $("#" + jsonData.recurso.ID + ".frmDesRecurso").find("#Submit").prop("disabled", "disabled");
                    $("#" + jsonData.recurso.ID + ".frmDelRecurso").find("#Submit").prop("disabled", "disabled");
                }
                $overlay.fadeOut();
            },
            error: function (error) { toastr.error("Ha ocurrido un error por parte del servidor"); console.log("Error con Archivos",error) }
        })

    

        $("#"+jsonData.usuario['ID']+"_"+jsonData.recurso['ID']).click(function(e){
            mostrarObservacion(jsonData);
        });
    }
});
function cambiarEstado(idRecursoPorUsuario) {
    var estado = $('#modalCambiarEstado_' + idRecursoPorUsuario + ' select').val()
    $.ajax({
        type: "GET",
        url: "/PersonalUV/updateEstadoRecursoPorUsuario",
        data: { "idRecursoPorUsuario": idRecursoPorUsuario, "Estado": estado },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            updateCicloDeVida(idRecursoPorUsuario)
            if (DepartamentoActual.Nombre == "Entrega" && estado == "Terminado") {
                $("#" + IDUsuarioActual + "_" + idRecursoPorUsuario).remove();
            }
            toastr.success("El estado del recurso ha sido actualizado")
            if (estado != "Terminado") {
                history.go(0)
            }
        },
        error: function (dataError) { toastr.error("Ha ocurrido un error por parte del servidor"); console.log(dataError)}
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
                if ($("#txtObservacion_" + idRecurso).val().length > 0) {
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
                                        toastr.success("El recurso ha sido enviado a otro departamento ")
                                    },
                                    error: function (dataError) { toastr.error("Ha ocurrido un error por parte del servidor"); console.log(dataError) }
                                });
                                $.ajax({
                                    type: "GET",
                                    url: "/PersonalUV/updateCicloDeVidaAsignacion",
                                    data: { "usuarioID": idUsuario, "recursoID": idRecurso },
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (usuarios) {
                                    },
                                    error: function (errorData) {
                                        toastr.error("Ha ocurrido un error por parte del servidor");
                                    }
                                });
                                $.ajax({
                                    type: "GET",
                                    url: "/PersonalUV/updateObservacion",
                                    data: { "observacion": $('#txtObservacion_' + idRecurso).val(), "recursoID": idRecurso },
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (usuarios) {
                                    },
                                    error: function (errorData) {
                                        toastr.error("Ha ocurrido un error por parte del servidor");
                                    }
                                });
                            },
                            error: function (dataError) {
                                toastr.error("Ha ocurrido un error por parte del servidor");
                                console.log(dataError)
                            }
                        });
                    } else {
                        $("#linkAviso").click();
                        $("#aviso .modal-body").html("Debe Cambiar el estado del recurso a terminado para poder enviar al siguiente departamento");
                    }
                }//si llenó la observacion
                else {
                    $("#linkAviso").click();
                    $("#aviso .modal-body").html("Debe ingresar la observación");
                }
            });            
        }, error: function(errorData){
            toastr.error("Ha ocurrido un error por parte del servidor");
            console.log(errorData)
        }
    });
    
}

function updateCicloDeVida(recursoPorUsuario) {
    var estado = $('#modalCambiarEstado_' + recursoPorUsuario + ' select').val();
    $.ajax({
        type: "GET",
        url: "/PersonalUV/updateCicloDeVidaEstado",
        data: { "recursoID": recursoPorUsuario, "Estado": estado },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
        },
        error: function (dataError) { toastr.error("Ha ocurrido un error por parte del servidor"); }
    });
}
function descargarFuente(recursoId) {
    var url = "/FTP/download/";
    var idArchivo = $('#selectArchivosFuente_' + recursoId).val();
    $("#" + recursoId + ".frmDesFuente").prop("action", url + "?archivoId=" + idArchivo);
    return true;
}
function eliminarFuente(recursoId) {
    var url = "/FTP/delete/"
    var idArchivo = $('#selectArchivosFuente_' + recursoId).val()
    $('#selectArchivosFuente_' + recursoId).remove(idArchivo);
    $("#" + recursoId + ".frmDelFuente").prop("action", url + "?archivoId=" + idArchivo);
    return true;
}
function descargarRecurso(recursoId) {
    var url = "/FTP/download/";
    var idArchivo = $('#selectArchivosRecurso_' + recursoId).val();
    $("#" + recursoId + ".frmDesRecurso").prop("action", url + "?archivoId=" + idArchivo);
    return true;
}
function eliminarRecurso(recursoId) {
    var url = "/FTP/delete/"
    var idArchivo = $('#selectArchivosRecurso_' + recursoId).val()
    $('#selectArchivosRecurso_' + recursoId).remove(idArchivo);
    $("#" + recursoId + ".frmDelRecurso").prop("action", url + "?archivoId=" + idArchivo);
    return true;
}

function validarEnviarSiguienteDepto(idRecurso) {
    $.ajax({
        type: "GET",
        url: "/PersonalUV/getRecursoPorUsuario/",
        data: { "idUsuario": IDUsuarioActual, "idRecurso": idRecurso },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            $.each(res, function (ind, recUsr) {
                if (recUsr.Estado == "Terminado") {
                    $('#linkEscribaObservacion_'+idRecurso).click()
                } else {
                    $("#linkAviso").click();
                    $("#aviso .modal-body").html("Debe Cambiar el estado del recurso a terminado para poder enviar al siguiente departamento");
                }
            })
        },
        error: function (errorData) {
            toastr.error("Ha ocurrido un error por parte del servidor");
        }
    });
}
function mostrarObservacion(jsonData) {
    $.ajax({
        type: "GET",
        url: "/PersonalUV/mostrarObservacion/",
        data: { "recursoID": jsonData.recurso.ID },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            if (res.hasOwnProperty("isRead")) { } else {
                $("#linkAviso").click();
                $("#aviso .modal-body").html("Observacion: " + res.Observacion);
                $("#" + jsonData.usuario['ID'] + "_" + jsonData.recurso['ID']).unbind('click')
            }            
        },
        error: function () {
            toastr.error("Ha ocurrido un error por parte del servidor");
        }
    })
}