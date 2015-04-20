Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc
Imports SaruvMaster.Controllers
<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub Index()
        ' Arrange
        Dim controller As New AreasDeConocimientoController()

        ' Act
        Dim result As ViewResult = DirectCast(controller.Index(), ViewResult)

        ' Assert
        Assert.IsNotNull(result)
    End Sub

End Class