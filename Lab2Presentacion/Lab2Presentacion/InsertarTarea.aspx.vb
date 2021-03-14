
Imports System.Data.SqlClient
Public Class WebForm3
    Inherits System.Web.UI.Page

    Public Shared ln As New LogicaNegocio.LogicaNegocio



    Dim auxi = 

    Dim conClsf = New SqlConnection(auxi)
    Dim dapMbrs As New SqlDataAdapter()
    Dim dstMbrs As New DataSet
    Dim tblMbrs As New DataTable
    Dim rowMbrs As DataRow






    Protected Sub Page_UnLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ln.cerrarconexion()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim result As String
        result = ln.conectar()

    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click




        Dim rowMbrs As DataRow = tblMbrs.NewRow()

        Dim codigo = TextBox10.Text

        Dim descripcion = TextBox2.Text

        Dim asignatura = DropDownList3.SelectedValue

        Dim tipo = DropDownList1.SelectedValue

        Dim horas = TextBox4.Text

        Dim aux = Session.Contents("seleccion")


        dapMbrs = New SqlDataAdapter("SELECT * from TareasGenericas where CodAsig= '" + aux + "'  ", CType(conClsf, SqlConnection))


        Dim bldMbrs2 As New SqlCommandBuilder(dapMbrs)
        dapMbrs.Fill(dstMbrs, "tareas")
        tblMbrs = dstMbrs.Tables("tareas")

        rowMbrs = tblMbrs.NewRow

        rowMbrs("Codigo") = codigo
        rowMbrs("Descripcion") = descripcion
        rowMbrs("CodAsig") = asignatura
        rowMbrs("HEstimadas") = horas
        rowMbrs("Explotacion") = 0
        rowMbrs("TipoTarea") = tipo

        tblMbrs.Rows.Add(rowMbrs)


        dapMbrs.Update(dstMbrs, "tareas")
        dstMbrs.AcceptChanges()


        'Dim conex As Integer



        'conex = StrComp(Label4.Text, "CONEXION OK", CompareMethod.Text) 'Si devuelve 0 son iguales

        'Label3.Text = conex


        'If (conex = 0) Then
        'Label2.Text = "entramos"

        'Dim insertado As String = ln.insertarA(codigo, descripcion, asignatura, horas, 0, tipo)
        'Label2.Text = insertado
        'End If




    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect(“TareasProfesor.aspx")
    End Sub

    Protected Sub SqlDataSource1_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting

    End Sub

    Protected Sub SqlDataSource2_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource2.Selecting

    End Sub
End Class