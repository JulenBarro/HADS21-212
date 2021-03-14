
Public Class Registro
    Inherits System.Web.UI.Page
    Public Shared ln As New LogicaNegocio.LogicaNegocio
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = ln.conectar()
        Label8.Text = result
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        ln.cerrarconexion()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label9.Visible = False
        RequiredFieldValidator1.Validate()
        RequiredFieldValidator2.Validate()
        RequiredFieldValidator3.Validate()
        RequiredFieldValidator4.Validate()
        RequiredFieldValidator5.Validate()
        RegularExpressionValidator1.Validate()
        'Miramos si la conexion a la BD es OK
        Dim conex As Integer
        conex = StrComp(Label8.Text, "CONEXION OK", CompareMethod.Text) 'Si devuelve 0 son iguales
        If RadioButton1.Checked Or RadioButton2.Checked Then
            'Si la conexion es Conexion OK y el email ha sido enviado
            If (conex = 0) Then
                'Codigo random
                Dim codigo As String
                Dim codint As Integer
                Randomize()
                codint = CLng(Rnd() * 9000000) + 1000000
                codigo = codint.ToString

                'Email
                Dim emailto As String = TextBox1.Text

                'Datos
                Dim nombre As String = TextBox5.Text
                Dim apellidos As String = TextBox4.Text
                Dim contraseña As String = TextBox2.Text
                Dim repecontra As String = TextBox3.Text
                Dim rol As String
                If RadioButton1.Checked Then
                    rol = "Alumno"
                Else
                    rol = "Profesor"
                End If

                'EnvioEmail
                Dim enviado As Boolean = False
                If (contraseña.Length >= 6) Then
                    If (StrComp(contraseña, repecontra, CompareMethod.Text) = 0) Then
                        If (Not ln.existeEmail(emailto)) Then
                            enviado = ln.enviarEmailRegistro(emailto, codigo)
                            If (enviado) Then
                                'Insertar registro BD
                                Dim insertado As String = ln.insertar(emailto, nombre, apellidos, codint, False, rol, contraseña, -1)
                                Label7.Text = "El email ha sido enviado."
                            Else
                                Label7.Text = "El email no ha podido ser enviado."
                            End If
                        Else
                            Label7.Text = "Ya hay una cuenta asociada al email introducido."
                        End If

                    Else
                        Label7.Text = "Hay que repetir la misma contraseña."
                    End If

                Else
                    Label7.Text = "La contraseña tiene que tener mínimo 6 carácteres."
                End If
            Else
                Label7.Text = "Error. No conexión BD."
            End If
        Else
            Label9.Visible = True
        End If

    End Sub

    Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class