Public Class CambiarPassword
    Inherits System.Web.UI.Page
    Public Shared ln As New LogicaNegocio.LogicaNegocio
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ln.conectar()
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        ln.cerrarconexion()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RequiredFieldValidator1.Validate()
        Dim codigo As String
        Dim codint As Integer
        Randomize()
        codint = CLng(Rnd() * 900000) + 100000
        codigo = codint.ToString

        'Email
        Dim emailto As String = TextBox1.Text
        If (ln.existeEmailConfirmado(emailto) And ln.codigoContraseña(emailto, codint)) Then
            ln.envioCodigoCambioContraseña(emailto, codigo)
            Label3.Visible = True
            TextBox2.Visible = True
            Button2.Visible = True
            Label6.Visible = False
            TextBox1.Enabled = False
            Button1.Enabled = False
            RequiredFieldValidator2.Enabled = True
        Else
            Label6.Text = "Error. El email o no existe o no ha sido verificado."
            Label6.Visible = True
        End If
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RequiredFieldValidator2.Enabled = True
        RequiredFieldValidator2.Validate()
        Dim aux = ln.codigoContraseñaGet(TextBox1.Text)
        If (RequiredFieldValidator2.IsValid()) Then
            If (aux.confir And aux.numero.ToString = TextBox2.Text) Then
                Label6.Visible = False
                TextBox3.Visible = True
                Button3.Visible = True
                TextBox4.Visible = True
                Label4.Visible = True
                Label5.Visible = True
                Button2.Enabled = False
                TextBox2.Enabled = False
                RequiredFieldValidator3.Enabled = True
                RequiredFieldValidator4.Enabled = True
            Else
                Label6.Text = "Error. Introduce el código correcto."
                Label6.Visible = True
            End If

        End If
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RequiredFieldValidator3.Validate()
        RequiredFieldValidator4.Validate()
        If (TextBox3.Text.Length >= 6) Then
            If (String.Compare(TextBox3.Text, TextBox4.Text) = 0) Then
                If (ln.cambiarContraseña(TextBox1.Text, TextBox3.Text)) Then
                    Label6.Visible = True
                    Label6.Text = "La contraseña se ha cambiado con éxito."
                Else
                    Label6.Visible = True
                    Label6.Text = "La contraseña no ha podido ser modificada."
                End If
            Else
                Label6.Text = "Error. Repite la misma contraseña."
                Label6.Visible = True
            End If

        Else
            Label6.Text = "Error. Introduce una contraseña de 6 o más carácteres."
            Label6.Visible = True
        End If
    End Sub
End Class