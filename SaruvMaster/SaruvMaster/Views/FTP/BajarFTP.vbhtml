@Code
    ViewData("Title") = "BajarFTP"
End Code

<h2>BajarFTP</h2>

Dim db = New NorthwindEntities()
Dim items As IEnumerable(Of SelectListItem) = db.Categories.[Select](Function(c) New SelectListItem() With { _
	Key .Value = c.CategoryID.ToString(), _
	Key .Text = c.CategoryName _
})
ViewBag.CategoryID = items

