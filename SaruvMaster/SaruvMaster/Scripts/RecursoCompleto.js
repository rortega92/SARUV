$(document).ready(function () {
    
    
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
                                $("#trRec_" + ele.RecursoID).find("#selectArchivosFuente_" + ele.RecursoID).append($("<option></option>").val(ele['ID']).html(ele['NombreArchivo']));
                            } else {
                                contRecurso++;
                                $("#trRec_" + ele.RecursoID).find("#selectArchivosRecurso_" + ele.RecursoID).append($("<option></option>").val(ele['ID']).html(ele['NombreArchivo']));
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
})
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