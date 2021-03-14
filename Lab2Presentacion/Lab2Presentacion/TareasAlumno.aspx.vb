Imports System.Data
Imports System.Data.SqlClient

Public Class TareasAlumno
    Inherits System.Web.UI.Page
    Public Shared ln As New LogicaNegocio.LogicaNegocio
    Public Shared dataSet As New DataSet
    Public Shared dataAdapter As New SqlDataAdapter()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            dataSet = Session("dataSet")
            dataAdapter = Session("dataAdapter")
        Else
            Dim aux = ln.asignaturasAlumno(Session("email"))

            dataSet = aux.ds
            dataAdapter = aux.da

            DropDownList1.DataTextField = dataSet.Tables("Asignaturas").Columns("codigoasig").ToString()
            DropDownList1.DataValueField = dataSet.Tables("Asignaturas").Columns("codigoasig").ToString()
            DropDownList1.DataSource = dataSet.Tables("Asignaturas")
            DropDownList1.DataBind()
            Dim asginatura = DropDownList1.SelectedValue
            Dim dt As New DataTable
            dt.Columns.Add("Codigo")
            dt.Columns.Add("Desc.")
            dt.Columns.Add("Horas")
            dt.Columns.Add("Tipo")
            Dim dataRow As DataRow

            For Each dataRow In dataSet.Tables("TareasGenericas").Rows
                If StrComp(dataRow("CodAsig"), asginatura, CompareMethod.Text) = 0 Then
                    dt.Rows.Add(dataRow("Codigo"), dataRow("Descripcion"), dataRow("HEstimadas"), dataRow("TipoTarea"))
                End If
            Next
            GridView1.DataSource = dt
            GridView1.DataBind()
            ln.actualizarDsDa(dataSet, dataAdapter)
            Session("dataSet") = dataSet
            Session("dataAdapter") = dataAdapter
        End If

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        Debug.WriteLine("Cambio")
        Dim asginatura = DropDownList1.SelectedValue
        Dim dt As New DataTable
        dt.Columns.Add("Codigo")
        dt.Columns.Add("Desc.")
        dt.Columns.Add("Horas")
        dt.Columns.Add("Tipo")
        Dim dataRow As DataRow

        For Each dataRow In dataSet.Tables("TareasGenericas").Rows
            If StrComp(dataRow("CodAsig"), asginatura, CompareMethod.Text) = 0 Then
                dt.Rows.Add(dataRow("Codigo"), dataRow("Descripcion"), dataRow("HEstimadas"), dataRow("TipoTarea"))
            End If
        Next
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect(“Inicio.aspx")
    End Sub



    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        'Determine the RowIndex of the Row whose Button was clicked.
        Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
        'Reference the GridView Row.
        Dim row As GridViewRow = GridView1.Rows(rowIndex)

        Response.Redirect(“https://localhost:44346/InstanciarTarea.aspx?mbr=" + Session("email") + "&tarea=" + row.Cells(1).Text + "&horas=" + row.Cells(3).Text + "")

        'Fetch value of Name.
        'Dim name As String = TryCast(row.FindControl("txtName"), TextBox).Text

        'Fetch value of Country.
        'Dim country As String = row.Cells(1).Text

        'ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Name: " & name & "\nCountry: " & country + "');", True)
    End Sub

End Class