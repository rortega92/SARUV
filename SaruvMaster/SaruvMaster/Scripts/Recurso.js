$(document).ready(function () {
    $("#FechaEntrega").addClass('form-control text-box single-line valid');
    $("#ModalidadDeCursoID").change(function () {
        $("select option:selected").each(function () {
            if ($(this).html() == "Presencial" || $(this).html() == "Virtual" || $(this).html() == "Internacional") {
                $("label[for=EmpresaID], #EmpresaID").parent().hide();
                $("label[for=ClienteCorporativoID], #ClienteCorporativoID").parent().hide();
                $("label[for=DocenteID], #DocenteID").parent().show();
                $("label[for=CursoID], #CursoID").parent().show();
            } else
                if ($(this).html() == "Corporativo" || $(this).html() == "Corporativa") {
                    $("label[for=EmpresaID], #EmpresaID").parent().show();
                    $("label[for=ClienteCorporativoID], #ClienteCorporativoID").parent().show();
                    $("label[for=DocenteID], #DocenteID").parent().hide();
                    $("label[for=CursoID], #CursoID").parent().hide();
                }

        });
    }).change();
    $("#Submit").click(function () {
        $("select option:selected").each(function () {
            if ($(this).html() == "Presencial" || $(this).html() == "Virtual") {
                $("#EmpresaID").empty();
                $("#ClienteCorporativoID").empty();
            }
            if ($(this).html() == "Corporativo" || $(this).html() == "Corporativa") {
                $("#DocenteID").empty();
                $("#CursoID").empty();
            }
        });
    });
    $("#EmpresaID").change(function () {
        $.ajax({
            type: "GET",
            url: "getClientesByNombreEmpresa",
            data: { "nombreEmpresa": $("#EmpresaID option:selected").html() },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                console.log(msg[0])
                $("#ClienteCorporativoID").empty()
                $.each(msg, function () {
                    $("#ClienteCorporativoID").append($("<option></option>").val(this['ID']).html(this['Nombres']));
                });
            },
            error: function () {
                alert("An error has occurred during processing your request.");
            }
        });
    }).change()

});