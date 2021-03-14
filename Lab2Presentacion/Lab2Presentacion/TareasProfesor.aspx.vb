
Imports System.Data.SqlClient
Public Class WebForm2
    Inherits System.Web.UI.Page

    Dim aux = 


    Dim conClsf = New SqlConnection(aux)

    Dim dstMbrs As New DataSet
    Dim dapMbrs As New SqlDataAdapter()
    Dim tblMbrs As New DataTable
    Dim rowMbrs As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Page.IsPostBack Then
            GridView1.DataBind()
            Session("seleccion") = DropDownList1.SelectedValue
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged


    End Sub

    Protected Sub SqlDataSource2_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource2.Selecting

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect(“InsertarTarea.aspx")
    End Sub
End Class