Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SaruvMaster.Controllers

<TestClass()> Public Class AreaDeConocimientoControllerTest

    <TestMethod()> Public Sub Index()
        ' Arrange
        Dim controller As New AreasDeConocimientoController()

        ' Act
        Dim result As ActionResult = DirectCast(controller.Index(), ViewResult)

        ' Assert
        Assert.IsNotNull(result)
    End Sub

End Class
