$(document).ready(function () {
    function descargarFuente(recursoId) {
        var url = "/FTP/download/";
        var idArchivo = $('#selectArchivosFuente_' + recursoId).val();
        $("#" + recursoId + ".frmDesFuente").prop("action", url + "?archivoId=" + idArchivo);
        return true;
    }
    function descargarRecurso(recursoId) {
        var url = "/FTP/download/";
        var idArchivo = $('#selectArchivosRecurso_' + recursoId).val();
        $("#" + recursoId + ".frmDesRecurso").prop("action", url + "?archivoId=" + idArchivo);
        return true;
    }
    
    $.ajax({
        type: "GET",
        url: "/Recurso/RecursosCompletos",
        data: { "wantsJson": true },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (res) {
            $.each(res, function (ind, ele) {
                $.ajax({
                    type: "GET",
                    url: "/FTP/getArchivosByRecursoId",
                    data: { "recursoId": ele.ID },
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
                            if (ele.TipoArchivo == 0) {
                                contFuente++;
                                $("#trRec_"+ele.ID).find("#selectArchivosFuente_" + ele.ID).append($("<option></option>").val(ele['ID']).html(ele['NombreArchivo']));
                            } else {
                                contRecurso++;
                                $("#trRec_" + ele.ID).find("#selectArchivosRecurso_" + ele.ID).append($("<option></option>").val(ele['ID']).html(ele['NombreArchivo']));
                            }
                        })
                        if (contFuente == 0) {
                            $("#trRec_" + ele.ID).find("#btnDescargarFuente_" + ele.ID).prop("disabled", "disabled");
                        }
                        if (contRecurso == 0) {
                            $("#trRec_" + ele.ID).find("#btnDescargarRecurso_" + ele.ID).prop("disabled", "disabled");
                        }
                    },
                    error: function (error) { toastr.error("Ha ocurrido un error por parte del servidor"); console.error("Error con Archivos", error);  }
                })//getArchivosByRecursoId
            });
        },
        error: function (error) {
            toastr.error("Ha ocurrido un error por parte del servidor"); 
            console.log("Error con Archivos", error)
        }
    })
    /*$.ajax({
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
        error: function (error) { toastr.error("Ha ocurrido un error por parte del servidor"); console.log("Error con Archivos", error) }
    })*/
})