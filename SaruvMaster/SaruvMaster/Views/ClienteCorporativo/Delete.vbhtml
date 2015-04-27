@ModelType SaruvMaster.ClienteCorporativo
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout2.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>ClienteCorporativo</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Empresa.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Empresa.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombres)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombres)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Apellidos)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Apellidos)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NumeroIdentidad)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NumeroIdentidad)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.CorreoElectronico)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.CorreoElectronico)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Telefono)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Telefono)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
