<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center><h1>教师信息管理系统</h1><br /><br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AddEditTea.aspx">添加教师信息</asp:HyperLink><br />
        <br />
        请输入姓名：<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="查询" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" Width="800px" 
            AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound" 
            DataKeyNames="id" onrowdeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="编号" />
                <asp:BoundField DataField="teacherId" HeaderText="工号" />
                <asp:BoundField DataField="teacherName" HeaderText="姓名" />
                <asp:BoundField DataField="sex" HeaderText="性别" />
                <asp:BoundField DataField="birthday" DataFormatString="{0:yyyy-MM-dd}" 
                    HeaderText="出生日期" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:HyperLinkField DataNavigateUrlFields="id" 
                    DataNavigateUrlFormatString="AddEditTea.aspx?id={0}" HeaderText="修改" 
                    Text="编辑" />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

    </center>
    </div>
    </form>
</body>
</html>
