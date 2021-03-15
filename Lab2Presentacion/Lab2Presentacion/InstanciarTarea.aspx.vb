Imports System.Data.SqlClient

Public Class InstanciarTarea
    Inherits System.Web.UI.Page
    Dim DataSet
    Dim dataAdapter
    Dim h As Int32
    Dim dt As New DataTable
    Public Shared ln As New LogicaNegocio.LogicaNegocio

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Dim email As String = Request.QueryString("mbr")
            Dim tarea As String = Request.QueryString("tarea")
            Dim horas As String = Request.QueryString("horas")
            h = Convert.ToInt32(horas)

            TextBox1.Text = email
            TextBox2.Text = tarea
            TextBox3.Text = h

            DataSet = Session("dataSet")
            dataAdapter = Session("dataAdapter")
            dt = DataSet.Tables("EstudiantesTareas")


            'For Each dataRow In DataSet.Tables("EstudiantesTareas").Rows
            'dt.Rows.Add(dataRow("Email"), dataRow("CodTarea"), dataRow("HEstimadas"), dataRow("HReales"))
            'Next
            GridView1.DataSource = dt
            GridView1.DataBind()
        Else
            Dim email As String = Request.QueryString("mbr")
            Dim tarea As String = Request.QueryString("tarea")
            Dim horas As String = Request.QueryString("horas")
            h = Convert.ToInt32(horas)

            TextBox1.Text = email
            TextBox2.Text = tarea
            TextBox3.Text = h


            dt.Columns.Add("Email")
            dt.Columns.Add("CodTarea")
            dt.Columns.Add("HEstimadas")
            dt.Columns.Add("HReales")
            Dim dataRow As DataRow
            DataSet = Session("dataSet")
            dataAdapter = Session("dataAdapter")
            dt = DataSet.Tables("EstudiantesTareas")
            'For Each dataRow In DataSet.Tables("EstudiantesTareas").Rows
            'dt.Rows.Add(dataRow("Email"), dataRow("CodTarea"), dataRow("HEstimadas"), dataRow("HReales"))
            'Next
            GridView1.DataSource = dt
            GridView1.DataBind()
            Session("dataSet") = DataSet
            Session("dataAdapter") = dataAdapter

        End If

    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("TareasAlumno.aspx")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim rowMbrs As DataRow = dt.NewRow()

            rowMbrs("Email") = TextBox1.Text
            rowMbrs("CodTarea") = TextBox2.Text
            rowMbrs("HEstimadas") = h
            rowMbrs("HReales") = Convert.ToInt32(TextBox4.Text)

            dt.Rows.Add(rowMbrs)
            GridView1.DataSource = dt
            GridView1.DataBind()
            dataAdapter.Update(DataSet, "EstudiantesTareas")
            DataSet.AcceptChanges()
            Session("dataSet") = DataSet
            Session("dataAdapter") = dataAdapter
            Button1.Enabled = False
            Label1.Text = "Se ha actualizado la BD correctamente."
            Label1.Visible = True
        Catch ex As Exception
            Label1.Text = "Error! No se ha actualizado la BD."
            Label1.Visible = True
        End Try

    End Sub
End Class
