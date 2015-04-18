@ModelType SaruvMaster.Models.Facultad

@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Details</title>
</head>
<body>
    <div>
        <h4>Facultad</h4>
        <hr />
        <dl class="dl-horizontal">
            <dt>
                @Html.DisplayNameFor(Function(model) model.Nombre)
            </dt>
    
            <dd>
                @Html.DisplayFor(Function(model) model.Nombre)
            </dd>
    
        </dl>
    </div>
    <p>
        @Html.ActionLink("Edit", "Edit", New With { .id = Model.ID }) |
        @Html.ActionLink("Back to List", "Index")
    </p>
</body>
</html>
