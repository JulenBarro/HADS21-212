<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InsertarTarea.aspx.vb" Inherits="Lab2Presentacion.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <section style="background-color:lightgray;">
           
        <div  style="text-align:center;">
            
            <h2>PROFESOR</h2>
            
            <h2>GESTION DE TAREAS GENERICAS</h2>
        </div>
        </section>

        <table >
            <tr>
                <td>
                    <h5>Codigo</h5>
                </td>

                <td>
                    
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                    
                </td>
            </tr>

             <tr>
                <td>
                    <h5>Descripcion</h5>
                </td>

                <td>
                    
                    <asp:TextBox ID="TextBox2" runat="server" Height="50px" Width="800px"></asp:TextBox>
                    
                </td>
            </tr>

             <tr>
                <td>
                    <h5>Asignatura</h5>
                </td>

                <td>
                    
                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource2" DataTextField="codigo" DataValueField="codigo">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-212ConnectionString %>" SelectCommand="SELECT DISTINCT [codigo] FROM [Asignaturas]">
                    </asp:SqlDataSource>
                    
                </td>
            </tr>

             <tr>
                <td>
                    <h5>Horas estimadas</h5>
                </td>

                <td>
                    
                    <asp:TextBox ID="TextBox4" runat="server" Width="80px"></asp:TextBox>
                    
                </td>
            </tr>

             <tr>
                <td>
                    <h5>Tipo tarea</h5>
                </td>

                <td>
                    
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="TipoTarea" DataValueField="TipoTarea">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS21-212ConnectionString %>" SelectCommand="SELECT DISTINCT [TipoTarea] FROM [TareasGenericas]"></asp:SqlDataSource>
                    
                </td>
            </tr>
        </table>
         <br />
         <br />
         <br />
         <br />
         <asp:Button ID="Button1" runat="server" Height="45px" Text="Añadir tarea" Width="104px" />
         <br />
         <asp:Button ID="Button2" runat="server" Text="Ver tareas" />
         <br />
         <br />
         <br />
    </form>
</body>
</html>
