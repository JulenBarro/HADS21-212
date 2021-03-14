Public Class Confirmar
    Inherits System.Web.UI.Page
    Public Shared ln As New LogicaNegocio.LogicaNegocio
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim email As String = Request.QueryString("mbr")
        Dim codigo As String = Request.QueryString("numconf")

        If ((ln.emailycodigoCorrectos(email, codigo)) And ln.cambioConfirmado(email)) Then
            Label1.Visible = True
            Label1.Text = "El registro ha sido verificado "
            LinkButton1.Visible = True
        Else
            Label1.Visible = True
            Label1.Text = "Identificación Incorrecta. Número de confirmación incorrecto."
            LinkButton1.Visible = True
        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect(“Inicio.aspx")
    End Sub
End Class