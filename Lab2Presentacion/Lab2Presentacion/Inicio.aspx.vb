Public Class Inicio
    Inherits System.Web.UI.Page
    Public Shared ln As New LogicaNegocio.LogicaNegocio

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RequiredFieldValidator1.Validate()
        RequiredFieldValidator2.Validate()

        If (ln.existeEmailConfirmado(TextBox1.Text)) Then
            If (ln.emailContraseña(TextBox1.Text, TextBox2.Text)) Then 'Si la contraseña corresponde al email introducido
                Session("email") = TextBox1.Text
                If ln.esAlumno(TextBox1.Text) Then
                    Response.Redirect(“Alumno.aspx")
                Else
                    Response.Redirect(“Profesor.aspx")
                End If

            Else
                    Label4.Visible = True
                Label4.Text = "Contraseña Erronea."
            End If
        Else
            Label4.Visible = True
            Label4.Text = "El email es erroneo."
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect(“registro.aspx")
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Response.Redirect(“CambiarPassword.aspx")
    End Sub
End Class